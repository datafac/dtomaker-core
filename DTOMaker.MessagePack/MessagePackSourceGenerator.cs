﻿using DTOMaker.Gentime;
using Microsoft.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace DTOMaker.MessagePack
{
    [Generator(LanguageNames.CSharp)]
    public class MessagePackSourceGenerator : SourceGeneratorBase
    {
        protected override void OnInitialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new MessagePackSyntaxReceiver());
        }

        private void EmitDiagnostics(GeneratorExecutionContext context, TargetBase target)
        {
            // todo fix msg ids
            foreach (var diagnostic in target.SyntaxErrors)
            {
                // report diagnostic
                context.ReportDiagnostic(
                    Diagnostic.Create(
                        new DiagnosticDescriptor(diagnostic.Id, diagnostic.Title, diagnostic.Message,
                            diagnostic.Category, diagnostic.Severity, true), diagnostic.Location));
            }
            foreach (var diagnostic in target.ValidationErrors())
            {
                // report diagnostic
                context.ReportDiagnostic(
                    Diagnostic.Create(
                        new DiagnosticDescriptor(diagnostic.Id, diagnostic.Title, diagnostic.Message,
                            diagnostic.Category, diagnostic.Severity, true), diagnostic.Location));
            }
        }

        protected override void OnExecute(GeneratorExecutionContext context)
        {
            if (context.SyntaxContextReceiver is not MessagePackSyntaxReceiver syntaxReceiver) return;

            var assembly = Assembly.GetExecutingAssembly();
            var language = Language_CSharp.Instance;
            var factory = new MessagePackScopeFactory();

            foreach (var domain in syntaxReceiver.Domains.Values)
            {
                EmitDiagnostics(context, domain);

                var domainScope = new MessagePackModelScopeDomain(ModelScopeEmpty.Instance, factory, language, domain);

                // emit entity base
                {
                    string sourceText = GenerateSourceText(language, domainScope, assembly, "DTOMaker.MessagePack.DomainTemplate.cs");
                    context.AddSource(
                        $"{domain.Name}.EntityBase.MessagePack.g.cs",
                        sourceText);
                }

                // emit each entity
                foreach (var entity in domain.Entities.Values.OrderBy(e => e.Name))
                {
                    EmitDiagnostics(context, entity);
                    foreach (var member in entity.Members.Values.OrderBy(m => m.Sequence))
                    {
                        EmitDiagnostics(context, member);
                    }

                    var entityScope = factory.CreateEntity(domainScope, factory, language, entity);
                    string sourceText = GenerateSourceText(language, entityScope, assembly, "DTOMaker.MessagePack.EntityTemplate.cs");
                    context.AddSource(
                        $"{domain.Name}.{entity.Name}.MessagePack.g.cs",
                        sourceText);
                }
            }
        }
    }
}