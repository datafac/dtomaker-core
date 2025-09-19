using Shouldly;
using System;
using System.Threading.Tasks;
using VerifyXunit;

namespace DTOMaker.Runtime.Tests
{
    public class VerifyTests
    {
        [Fact]
        public async Task RunVerifyChecks()
        {
            await VerifyChecks.Run();
        }

        /// <summary>
        /// We can't upgrade greater than 4.12.0 because it introduces a ban on
        /// ISourceGenerator in favor of IIncrementalGenerator. This would require a major
        /// rewrite of the source generators .
        /// </summary>
        [Fact]
        public void EnsureCorrectVersion_CodeAnalysis_LEQ_4_12_0()
        {
            Version? version = typeof(Microsoft.CodeAnalysis.CSharp.LanguageVersion).Assembly.GetName().Version;
            version.ShouldNotBeNull();
            version.Major.ShouldBe(4);
            version.Minor.ShouldBe(12);
            version.Build.ShouldBe(0);
            (version <= new Version(4, 12, 0, 0)).ShouldBeTrue();
        }

        /// <summary>
        /// We can't upgrade greater than 0.15.0 because it introduces a dependency on
        /// Microsoft.CodeAnalysis 4.14 which bans use of ISourceGenerator in favor of
        /// IIncrementalGenerator. This would require a major rewrite of the source generator.
        /// </summary>
        [Fact]
        public void EnsureCorrectVersion_BenchmarkDotNet_LEQ_0_15_0()
        {
            Version? version = typeof(BenchmarkDotNet.Jobs.RuntimeMoniker).Assembly.GetName().Version;
            version.ShouldNotBeNull();
            version.Major.ShouldBe(0);
            version.Minor.ShouldBe(15);
            version.Build.ShouldBe(0);
            (version <= new Version(0, 15, 0, 0)).ShouldBeTrue();
        }
    }
}
