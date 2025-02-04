﻿using Shouldly;
using Microsoft.CodeAnalysis;
using System.Linq;
using System;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;
using Microsoft.CodeAnalysis.CSharp;

namespace DTOMaker.MemBlocks.Tests
{
    public class PolymorphismTests
    {
        private readonly string inputSource =
            """
                using DTOMaker.Models;
                using DTOMaker.Models.MemBlocks;
                namespace MyOrg.Models
                {
                    [Entity] [Id("Polygon")][Layout(LayoutMethod.Linear)]
                    public interface IPolygon { }

                    [Entity] [Id("Triangle")][Layout(LayoutMethod.Linear)] 
                    public interface ITriangle : IPolygon { }

                    [Entity] [Id("Equilateral")][Layout(LayoutMethod.Linear)] 
                    public interface IEquilateral : ITriangle
                    {
                        [Member(1)] double Length { get; set; }
                    }

                    [Entity] [Id("RightTriangle")][Layout(LayoutMethod.Linear)] 
                    public interface IRightTriangle : ITriangle
                    {
                        [Member(1)] double Length { get; set; }
                        [Member(2)] double Height { get; set; }
                    }

                    [Entity] [Id("Quadrilateral")][Layout(LayoutMethod.Linear)] 
                    public interface IQuadrilateral : IPolygon { }

                    [Entity] [Id("Square")][Layout(LayoutMethod.Linear)] 
                    public interface ISquare : IQuadrilateral
                    {
                        [Member(1)] double Length { get; set; }
                    }

                    [Entity] [Id("Rectangle")][Layout(LayoutMethod.Linear)] 
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
            source.HintName.ShouldBe("MyOrg.Models.Equilateral.MemBlocks.g.cs");
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
            source.HintName.ShouldBe("MyOrg.Models.Polygon.MemBlocks.g.cs");
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
            source.HintName.ShouldBe("MyOrg.Models.Quadrilateral.MemBlocks.g.cs");
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
            source.HintName.ShouldBe("MyOrg.Models.Rectangle.MemBlocks.g.cs");
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
            source.HintName.ShouldBe("MyOrg.Models.RightTriangle.MemBlocks.g.cs");
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
            source.HintName.ShouldBe("MyOrg.Models.Square.MemBlocks.g.cs");
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
            source.HintName.ShouldBe("MyOrg.Models.Triangle.MemBlocks.g.cs");
            string outputCode = string.Join(Environment.NewLine, source.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }
    }
}