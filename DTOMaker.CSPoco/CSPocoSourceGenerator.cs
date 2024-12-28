﻿using DTOMaker.Gentime;
using Microsoft.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace DTOMaker.CSPoco
{
    [Generator(LanguageNames.CSharp)]
    public class CSPocoSourceGenerator : SourceGeneratorBase
    {
        protected override void OnInitialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new CSPocoSyntaxReceiver());
        }

        private void EmitDiagnostics(GeneratorExecutionContext context, TargetBase target)
        {
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
            if (context.SyntaxContextReceiver is not CSPocoSyntaxReceiver syntaxReceiver) return;

            var assembly = Assembly.GetExecutingAssembly();
            var language = Language_CSharp.Instance;
            var factory = new CSPocoScopeFactory();

            var domain = syntaxReceiver.Domain;
            EmitDiagnostics(context, domain);

            var domainScope = new CSPocoModelScopeDomain(ModelScopeEmpty.Instance, factory, language, domain);

            // emit entity base
            {
                string sourceText = GenerateSourceText(language, domainScope, assembly, "DTOMaker.CSPoco.DomainTemplate.cs");
                context.AddSource(
                    $"{EntityFQN.DefaultBase.FullName}.CSPoco.g.cs",
                    sourceText);
            }

            // emit each entity
            foreach (var entity in domain.Entities.Values.OrderBy(e => e.EntityName.FullName))
            {
                EmitDiagnostics(context, entity);
                foreach (var member in entity.Members.Values.OrderBy(m => m.Sequence))
                {
                    EmitDiagnostics(context, member);
                }

                var entityScope = factory.CreateEntity(domainScope, factory, language, entity);
                string sourceText = GenerateSourceText(language, entityScope, assembly, "DTOMaker.CSPoco.EntityTemplate.cs");
                context.AddSource(
                    $"{entity.EntityName.FullName}.CSPoco.g.cs",
                    sourceText);
            }
        }
    }
}
