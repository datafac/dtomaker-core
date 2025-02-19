﻿using Shouldly;
using Microsoft.CodeAnalysis;
using System.Linq;
using Xunit;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;
using System.Threading.Tasks;
using System;
using VerifyXunit;

namespace DTOMaker.MemBlocks.Tests
{
    public class RecursiveGraphTests
    {
        private readonly string models =
            """
            using System;
            using DTOMaker.Models;
            using DTOMaker.Models.MemBlocks;
            namespace MyOrg.Models
            {
                [Entity][Layout(LayoutMethod.Linear)]
                [Id("01234567-89ab-cdef-0123-456789abcdef")]
                public interface INode
                {
                    [Member(1)][StrLen(16)] String Key { get; set; }
                }

                [Entity][Layout(LayoutMethod.Linear)]
                [Id("01234567-89ab-cdef-0201-456789abcdef")]
                public interface IStringNode : INode
                {
                    [Member(1)][StrLen(256)] String Value { get; set; }
                }

                [Entity][Layout(LayoutMethod.Linear)]
                [Id("01234567-89ab-cdef-0202-456789abcdef")]
                public interface INumericNode : INode
                {
                }

                [Entity][Layout(LayoutMethod.Linear)]
                [Id("01234567-89ab-cdef-0203-456789abcdef")]
                public interface IInt64Node : INumericNode
                {
                    [Member(1)] Int64 Value { get; set; }
                }

                [Entity][Layout(LayoutMethod.Linear)]
                [Id("01234567-89ab-cdef-0204-456789abcdef")]
                public interface IDoubleNode : INumericNode
                {
                    [Member(1)] Double Value { get; set; }
                }

                [Entity][Layout(LayoutMethod.Linear)]
                [Id("01234567-89ab-cdef-0205-456789abcdef")]
                public interface IBooleanNode : INode
                {
                    [Member(1)] Boolean Value { get; set; }
                }

                [Entity][Layout(LayoutMethod.Linear)]
                [Id("01234567-89ab-cdef-0206-456789abcdef")]
                public interface ITree
                {
                    [Member(1)] ITree? Left { get; set; }
                    [Member(2)] ITree? Right { get; set; }
                    [Member(3)] INode? Node { get; set; }
                }
            }
            
            """;

        [Fact]
        public void RecursiveGraph00_GeneratedSourcesLengthShouldBe7()
        {
            var generatorResult = GeneratorTestHelper.RunSourceGenerator(models, LanguageVersion.LatestMajor);
            generatorResult.Exception.ShouldBeNull();
            generatorResult.Diagnostics.Where(d => d.Severity == DiagnosticSeverity.Info).ShouldBeEmpty();
            generatorResult.Diagnostics.Where(d => d.Severity == DiagnosticSeverity.Warning).ShouldBeEmpty();
            generatorResult.Diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error).ShouldBeEmpty();

            // custom generation checks
            generatorResult.GeneratedSources.Length.ShouldBe(7);
            generatorResult.GeneratedSources[0].HintName.ShouldBe("MyOrg.Models.BooleanNode.MemBlocks.g.cs");
            generatorResult.GeneratedSources[1].HintName.ShouldBe("MyOrg.Models.DoubleNode.MemBlocks.g.cs");
            generatorResult.GeneratedSources[2].HintName.ShouldBe("MyOrg.Models.Int64Node.MemBlocks.g.cs");
            generatorResult.GeneratedSources[3].HintName.ShouldBe("MyOrg.Models.Node.MemBlocks.g.cs");
            generatorResult.GeneratedSources[4].HintName.ShouldBe("MyOrg.Models.NumericNode.MemBlocks.g.cs");
            generatorResult.GeneratedSources[5].HintName.ShouldBe("MyOrg.Models.StringNode.MemBlocks.g.cs");
            generatorResult.GeneratedSources[6].HintName.ShouldBe("MyOrg.Models.Tree.MemBlocks.g.cs");
        }

        [Fact]
        public async Task RecursiveGraph01_VerifyGeneratedSource0()
        {
            var generatorResult = GeneratorTestHelper.RunSourceGenerator(models, LanguageVersion.LatestMajor);

            // custom generation checks
            var source = generatorResult.GeneratedSources[0];
            string outputCode = string.Join(Environment.NewLine, source.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }

        [Fact]
        public async Task RecursiveGraph01_VerifyGeneratedSource1()
        {
            var generatorResult = GeneratorTestHelper.RunSourceGenerator(models, LanguageVersion.LatestMajor);

            // custom generation checks
            var source = generatorResult.GeneratedSources[1];
            string outputCode = string.Join(Environment.NewLine, source.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }

        [Fact]
        public async Task RecursiveGraph01_VerifyGeneratedSource2()
        {
            var generatorResult = GeneratorTestHelper.RunSourceGenerator(models, LanguageVersion.LatestMajor);

            // custom generation checks
            var source = generatorResult.GeneratedSources[2];
            string outputCode = string.Join(Environment.NewLine, source.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }

        [Fact]
        public async Task RecursiveGraph01_VerifyGeneratedSource3()
        {
            var generatorResult = GeneratorTestHelper.RunSourceGenerator(models, LanguageVersion.LatestMajor);

            // custom generation checks
            var source = generatorResult.GeneratedSources[3];
            string outputCode = string.Join(Environment.NewLine, source.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }

        [Fact]
        public async Task RecursiveGraph01_VerifyGeneratedSource4()
        {
            var generatorResult = GeneratorTestHelper.RunSourceGenerator(models, LanguageVersion.LatestMajor);

            // custom generation checks
            var source = generatorResult.GeneratedSources[4];
            string outputCode = string.Join(Environment.NewLine, source.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }

        [Fact]
        public async Task RecursiveGraph01_VerifyGeneratedSource5()
        {
            var generatorResult = GeneratorTestHelper.RunSourceGenerator(models, LanguageVersion.LatestMajor);

            // custom generation checks
            var source = generatorResult.GeneratedSources[5];
            string outputCode = string.Join(Environment.NewLine, source.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }

        [Fact]
        public async Task RecursiveGraph01_VerifyGeneratedSource6()
        {
            var generatorResult = GeneratorTestHelper.RunSourceGenerator(models, LanguageVersion.LatestMajor);

            // custom generation checks
            var source = generatorResult.GeneratedSources[6];
            string outputCode = string.Join(Environment.NewLine, source.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }

    }
}