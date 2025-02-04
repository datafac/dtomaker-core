using Shouldly;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

#pragma warning disable CS0618 // Type or member is obsolete

namespace Template.MemBlocks.Tests
{
    public class ReadOnlyMemoryTests
    {
        [Fact]
        public void RoundtripReadOnlySequence()
        {
            string orig = "The quick brown fox jumps over the lazy dog.";

            // encode
            ImmutableArray<ReadOnlyMemory<byte>> buffers = ImmutableArray<ReadOnlyMemory<byte>>.Empty
                .AddRange(orig.Split(' ').Select(w => new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes(w))));

            // decode
            string copy = string.Join(" ", buffers.Select(b => Encoding.UTF8.GetString(b.ToArray())));

            // assert
            copy.ShouldBe(orig);
        }
    }
    public class UnitTest1
    {
        [Fact]

        public async Task RoundtripDTO()
        {
            using var dataStore = new DataFac.Storage.Testing.TestDataStore();

            var orig = new T_NameSpace_.MemBlocks.T_EntityName_();
            orig.BaseField1 = 789;
            orig.T_ScalarMemberName_ = 123;
            orig.T_VectorMemberName_ = new int[] { 1, 2, 3 };
            orig.T_RequiredEntityMemberName_ = new T_MemberTypeNameSpace_.MemBlocks.T_MemberTypeName_() { Field1 = 123 };
            await orig.Pack(dataStore);
            orig.Freeze();

            var buffer = orig.GetBuffer();

            var copy = T_NameSpace_.MemBlocks.T_EntityName_.CreateFrom(buffer);
            copy.IsFrozen.ShouldBeTrue();
            await copy.Unpack(dataStore, 0);
            copy.BaseField1.ShouldBe(orig.BaseField1);
            copy.T_ScalarMemberName_.ShouldBe(orig.T_ScalarMemberName_);
            copy.T_VectorMemberName_.Span.SequenceEqual(orig.T_VectorMemberName_.Span).ShouldBeTrue();
            copy.T_RequiredEntityMemberName_.ShouldNotBeNull();
            await copy.T_RequiredEntityMemberName_.Unpack(dataStore, 0);
            copy.T_RequiredEntityMemberName_!.Field1.ShouldBe(orig.T_RequiredEntityMemberName_.Field1);
        }
    }
}