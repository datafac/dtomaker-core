﻿using FluentAssertions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace DTOMaker.MessagePack.Tests
{
    public class RecursiveGraphTests
    {
        private readonly string models =
            """
            using System;
            using DTOMaker.Models;
            using DTOMaker.Models.MessagePack;
            namespace MyOrg.Models
            {
                [Entity][EntityKey(1)]
                public interface INode
                {
                    [Member(1)] String Key { get; set; }
                }

                [Entity][EntityKey(2)]
                public interface IStringNode : INode
                {
                    [Member(1)] String Value { get; set; }
                }

                [Entity][EntityKey(3)]
                public interface INumericNode : INode
                {
                }

                [Entity][EntityKey(4)]
                public interface IInt64Node : INumericNode
                {
                    [Member(1)] Int64 Value { get; set; }
                }

                [Entity][EntityKey(5)]
                public interface IDoubleNode : INumericNode
                {
                    [Member(1)] Double Value { get; set; }
                }

                [Entity][EntityKey(6)]
                public interface IBooleanNode : INode
                {
                    [Member(1)] Boolean Value { get; set; }
                }

                [Entity][EntityKey(10)]
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
            generatorResult.Exception.Should().BeNull();
            generatorResult.Diagnostics.Where(d => d.Severity == DiagnosticSeverity.Info).Should().BeEmpty();
            generatorResult.Diagnostics.Where(d => d.Severity == DiagnosticSeverity.Warning).Should().BeEmpty();
            generatorResult.Diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error).Should().BeEmpty();

            // custom generation checks
            generatorResult.GeneratedSources.Length.Should().Be(7);
            generatorResult.GeneratedSources[0].HintName.Should().Be("MyOrg.Models.BooleanNode.MessagePack.g.cs");
            generatorResult.GeneratedSources[1].HintName.Should().Be("MyOrg.Models.DoubleNode.MessagePack.g.cs");
            generatorResult.GeneratedSources[2].HintName.Should().Be("MyOrg.Models.Int64Node.MessagePack.g.cs");
            generatorResult.GeneratedSources[3].HintName.Should().Be("MyOrg.Models.Node.MessagePack.g.cs");
            generatorResult.GeneratedSources[4].HintName.Should().Be("MyOrg.Models.NumericNode.MessagePack.g.cs");
            generatorResult.GeneratedSources[5].HintName.Should().Be("MyOrg.Models.StringNode.MessagePack.g.cs");
            generatorResult.GeneratedSources[6].HintName.Should().Be("MyOrg.Models.Tree.MessagePack.g.cs");
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