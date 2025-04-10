﻿using Microsoft.CodeAnalysis;
using System.Linq;

namespace DTOMaker.Gentime
{
    public abstract class SourceGeneratorBase : ISourceGenerator
    {
        protected abstract void OnInitialize(GeneratorInitializationContext context);
        public void Initialize(GeneratorInitializationContext context) => OnInitialize(context);

        private static bool IsDerivedFrom(TargetEntity candidate, TargetEntity parent)
        {
            if (ReferenceEquals(candidate, parent)) return false;
            if (candidate.Base is null) return false;
            if (candidate.Base.EntityName.Equals(parent.EntityName)) return true;
            return IsDerivedFrom(candidate.Base, parent);
        }

        protected abstract void OnExecute(GeneratorExecutionContext context);
        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxContextReceiver is not SyntaxReceiverBase syntaxReceiver) return;

            // fix entity hierarchy
            var domain = syntaxReceiver.Domain;
            // fix/set entity base
            var entities = domain.Entities.Values.ToArray();
            foreach (var entity in entities)
            {
                if (!entity.BaseName.Equals(TypeFullName.DefaultBase))
                {
                    if (domain.Entities.TryGetValue(entity.BaseName.FullName, out var baseEntity))
                    {
                        entity.Base = baseEntity;
                    }
                    else
                    {
                        // invalid base name!
                        entity.SyntaxErrors.Add(
                            new SyntaxDiagnostic(
                                DiagnosticId.DTOM0008, "Invalid base name", DiagnosticCategory.Design, entity.Location, DiagnosticSeverity.Error,
                                $"Base name '{entity.BaseName}' does not refer to a known entity."));
                    }
                }
            }

            // determine derived entities
            foreach (var entity in entities)
            {
                entity.DerivedEntities = domain.Entities.Values
                    .Where(e => IsDerivedFrom(e, entity))
                    .OrderBy(e => e.EntityName.FullName)
                    .ToArray();
            }

            // determine entity members
            foreach (var entity in entities)
            {
                foreach (var member in entity.Members.Values)
                {
                    var entity2 = entities.FirstOrDefault(e => e.EntityName.WithShortName(sn => "I" + sn) == member.MemberType);
                    if (entity2 is not null)
                    {
                        member.Kind = MemberKind.Entity;
                        member.MemberType = entity2.EntityName;
                    }
                }
            }

            // todo emit metadata as json
            //var metadata = new JsonModel();
            //metadata.Entities = entities
            //    .OrderBy(e => e.EntityId)
            //    .Select(e => e.ToJson())
            //    .ToArray();
            //string jsonText = metadata.ToText();
            //// todo emit json file directly to file system
            //context.AddSource($"Metadata.g.json", jsonText);

            OnExecute(context);
        }
    }
}
