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
            if (candidate.Base.TFN.Equals(parent.TFN)) return true;
            return IsDerivedFrom(candidate.Base, parent);
        }

        protected abstract void OnExecute(GeneratorExecutionContext context);
        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxContextReceiver is not SyntaxReceiverBase syntaxReceiver) return;

            // fix entity hierarchy
            var domain = syntaxReceiver.Domain;
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

            // bind closed/open generic entities
            foreach (var entity in entities)
            {
                var eTFN = entity.TFN;
                if (eTFN.IsGeneric && eTFN.IsClosed)
                {
                    var openTFN = eTFN.AsOpenGeneric();
                    if (domain.Entities.TryGetValue(openTFN.FullName, out var openEntity))
                    {
                        // generate id and members if required
                        if (entity.OpenEntity is null)
                        {
                            entity.HasEntityAttribute = true; // implied
                            // todo
                            entity.EntityId = openEntity.EntityId + 1000; // todo
                            //entity.Members = xxx;
                            entity.OpenEntity = openEntity;
                        }
                    }
                    else
                    {
                        // open entity not found!
                        entity.SyntaxErrors.Add(
                            new SyntaxDiagnostic(
                                DiagnosticId.DTOM0011, "Invalid generic entity", DiagnosticCategory.Design, entity.Location, DiagnosticSeverity.Error,
                                $"Cannot find open entity '{openTFN}' for closed entity '{eTFN}'."));
                    }
                }
            }

            // determine derived entities
            foreach (var entity in entities)
            {
                entity.DerivedEntities = domain.Entities.Values
                    .Where(e => IsDerivedFrom(e, entity))
                    .OrderBy(e => e.TFN.FullName)
                    .ToArray();
            }

            // determine entity members
            foreach (var entity in entities)
            {
                foreach (var member in entity.Members.Values)
                {
                    var entity2 = entities.FirstOrDefault(e => e.TFN == member.MemberType);
                    if (entity2 is not null)
                    {
                        member.Kind = MemberKind.Entity;
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
