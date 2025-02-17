﻿using Shouldly;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Linq;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace DTOMaker.CSPoco.Tests
{
    public class PolymorphismTests
    {
        private readonly string inputSource =
            """
                using DTOMaker.Models;
                namespace MyOrg.Models
                {
                    [Entity] [Id("35274af9-5245-4366-be3a-1d0c23343436")]
                    public interface IPolygon { }

                    [Entity] [Id("ab43cde1-e7e3-45ee-a61d-ebf361c75d20")] 
                    public interface ITriangle : IPolygon { }

                    [Entity] [Id("5759ed59-eac7-4eb9-8fb7-3eb466bdb4a3")] 
                    public interface IEquilateral : ITriangle
                    {
                        [Member(1)] double Length { get; set; }
                    }

                    [Entity] [Id("9ea51512-7118-47ab-9ac1-0daa4c68bc87")] 
                    public interface IRightTriangle : ITriangle
                    {
                        [Member(1)] double Length { get; set; }
                        [Member(2)] double Height { get; set; }
                    }

                    [Entity] [Id("0b524606-ede1-4f9e-ae7d-34abbe67c911")] 
                    public interface IQuadrilateral : IPolygon { }

                    [Entity] [Id("931d0721-74be-41d3-bfb2-c5e8301162cf")] 
                    public interface ISquare : IQuadrilateral
                    {
                        [Member(1)] double Length { get; set; }
                    }

                    [Entity] [Id("8c866b2c-9500-4ebe-ac4f-7b0fc402fbee")] 
                    public interface IRectangle : IQuadrilateral
                    {
                        [Member(1)] double Length { get; set; }
                        [Member(2)] double Height { get; set; }
                    }
                }
                """;

        [Fact]
        public async Task Polymorphic02_Equilateral()
        {
            var generatorResult = GeneratorTestHelper.RunSourceGenerator(inputSource, LanguageVersion.LatestMajor);
            generatorResult.Exception.ShouldBeNull();
            generatorResult.Diagnostics.ShouldBeEmpty();
            generatorResult.GeneratedSources.Length.ShouldBe(7);
            GeneratedSourceResult source = generatorResult.GeneratedSources[0];
            source.HintName.ShouldBe("MyOrg.Models.Equilateral.CSPoco.g.cs");
            string outputCode = string.Join(Environment.NewLine, source.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }

        [Fact]
        public async Task Polymorphic03_Polygon()
        {
            var generatorResult = GeneratorTestHelper.RunSourceGenerator(inputSource, LanguageVersion.LatestMajor);
            generatorResult.Exception.ShouldBeNull();
            generatorResult.Diagnostics.ShouldBeEmpty();
            generatorResult.GeneratedSources.Length.ShouldBe(7);
            GeneratedSourceResult source = generatorResult.GeneratedSources[1];
            source.HintName.ShouldBe("MyOrg.Models.Polygon.CSPoco.g.cs");
            string outputCode = string.Join(Environment.NewLine, source.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }

        [Fact]
        public async Task Polymorphic04_Quadrilateral()
        {
            var generatorResult = GeneratorTestHelper.RunSourceGenerator(inputSource, LanguageVersion.LatestMajor);
            generatorResult.Exception.ShouldBeNull();
            generatorResult.Diagnostics.ShouldBeEmpty();
            generatorResult.GeneratedSources.Length.ShouldBe(7);
            GeneratedSourceResult source = generatorResult.GeneratedSources[2];
            source.HintName.ShouldBe("MyOrg.Models.Quadrilateral.CSPoco.g.cs");
            string outputCode = string.Join(Environment.NewLine, source.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }

        [Fact]
        public async Task Polymorphic05_Rectangle()
        {
            var generatorResult = GeneratorTestHelper.RunSourceGenerator(inputSource, LanguageVersion.LatestMajor);
            generatorResult.Exception.ShouldBeNull();
            generatorResult.Diagnostics.ShouldBeEmpty();
            generatorResult.GeneratedSources.Length.ShouldBe(7);
            GeneratedSourceResult source = generatorResult.GeneratedSources[3];
            source.HintName.ShouldBe("MyOrg.Models.Rectangle.CSPoco.g.cs");
            string outputCode = string.Join(Environment.NewLine, source.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }

        [Fact]
        public async Task Polymorphic06_RightTriangle()
        {
            var generatorResult = GeneratorTestHelper.RunSourceGenerator(inputSource, LanguageVersion.LatestMajor);
            generatorResult.Exception.ShouldBeNull();
            generatorResult.Diagnostics.ShouldBeEmpty();
            generatorResult.GeneratedSources.Length.ShouldBe(7);
            GeneratedSourceResult source = generatorResult.GeneratedSources[4];
            source.HintName.ShouldBe("MyOrg.Models.RightTriangle.CSPoco.g.cs");
            string outputCode = string.Join(Environment.NewLine, source.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }

        [Fact]
        public async Task Polymorphic07_Square()
        {
            var generatorResult = GeneratorTestHelper.RunSourceGenerator(inputSource, LanguageVersion.LatestMajor);
            generatorResult.Exception.ShouldBeNull();
            generatorResult.Diagnostics.ShouldBeEmpty();
            generatorResult.GeneratedSources.Length.ShouldBe(7);
            GeneratedSourceResult source = generatorResult.GeneratedSources[5];
            source.HintName.ShouldBe("MyOrg.Models.Square.CSPoco.g.cs");
            string outputCode = string.Join(Environment.NewLine, source.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }

        [Fact]
        public async Task Polymorphic08_Triangle()
        {
            var generatorResult = GeneratorTestHelper.RunSourceGenerator(inputSource, LanguageVersion.LatestMajor);
            generatorResult.Exception.ShouldBeNull();
            generatorResult.Diagnostics.ShouldBeEmpty();
            generatorResult.GeneratedSources.Length.ShouldBe(7);
            GeneratedSourceResult source = generatorResult.GeneratedSources[6];
            source.HintName.ShouldBe("MyOrg.Models.Triangle.CSPoco.g.cs");
            string outputCode = string.Join(Environment.NewLine, source.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }
    }
}