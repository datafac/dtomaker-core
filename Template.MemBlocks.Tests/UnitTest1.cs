using DataFac.Memory;
using DTOMaker.Runtime.MemBlocks;
using Shouldly;
using System;
using System.Buffers;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable CS0618 // Type or member is obsolete

namespace Template.MemBlocks.Tests
{
    internal sealed class TestEntity : EntityBase
    {
        //##if(false) {
        //private const int T_ClassHeight_ = 2;
        //private const int T_BlockLength_ = 1024;
        //private const bool T_MemberObsoleteIsError_ = false;
        //private const long T_BlockStructureCode_ = 0x0A62;
        //private static readonly Guid T_EntityGuid_ = new Guid("341c6631-30ba-482b-b580-7c1c2c9ff182");
        //##}
        private static readonly long _structureBits = 0x0051;
        private const int ClassHeight = 1;
        private const int BlockLength = 32;
        private readonly Memory<byte> _writableLocalBlock;
        private readonly ReadOnlyMemory<byte> _readonlyLocalBlock;

        public new const string EntityId = "T_EntityId_";
        private static readonly Guid _entityGuid = new Guid("8bb1290a-9336-4371-8dad-fccd8d9c4494");
        private static readonly BlockHeader _header = BlockHeader.CreateNew(_structureBits, _entityGuid);

        protected override int OnGetClassHeight() => ClassHeight;
        protected override ReadOnlySequenceBuilder<byte> OnSequenceBuilder(ReadOnlySequenceBuilder<byte> builder) => base.OnSequenceBuilder(builder).Append(_readonlyLocalBlock);
        protected override string OnGetEntityId() => _entityGuid.ToString("D");
        public TestEntity() : base(_header)
        {
            _readonlyLocalBlock = _writableLocalBlock = new byte[BlockLength];
        }
    }
    public class EntityBaseTests
    {
        [Fact]
        public void ParseBlockHeader()
        {
            BlockB064 outgoing = default;
            // signature
            outgoing.A.A.A.A.A.A.ByteValue = (byte)'|';
            outgoing.A.A.A.A.A.B.ByteValue = (byte)'_';
            outgoing.A.A.A.A.B.A.ByteValue = (byte)1;
            outgoing.A.A.A.A.B.B.ByteValue = (byte)0;
            // structure
            outgoing.A.A.B.Int64ValueLE = 0x61;
            // entityid
            outgoing.A.B.GuidValueLE = new Guid("aa1e2d7b-fcb5-4739-9624-f6a648815251");

            Memory<byte> buffer = new byte[64];
            bool written = outgoing.TryWrite(buffer.Span);
            written.ShouldBeTrue();

            BlockHeader incoming = BlockHeader.ParseFrom(buffer);
            incoming.SignatureBits.ShouldBe(89980L);
            incoming.StructureBits.ShouldBe(0x61);
            incoming.EntityGuid.ToString("D").ShouldBe("aa1e2d7b-fcb5-4739-9624-f6a648815251");
        }

        [Fact]
        public async Task BlockHeaderIsConstant()
        {
            using var dataStore = new DataFac.Storage.Testing.TestDataStore();
            var orig = new TestEntity();
            await orig.Pack(dataStore);
            orig.Freeze();
            var buffer = orig.GetBuffer().Compact();
            buffer.Length.ShouldBe(96);

            buffer.Span[0].ShouldBe((byte)'|');  // marker byte 0
            buffer.Span[1].ShouldBe((byte)'_');  // marker byte 1
            buffer.Span[2].ShouldBe((byte)1);    // major version
            buffer.Span[3].ShouldBe((byte)0);    // minor version

            BlockHeader parsed = BlockHeader.ParseFrom(buffer);
            parsed.SignatureBits.ShouldBe(89980L);
            parsed.StructureBits.ShouldBe(0x51);
            parsed.EntityGuid.ToString("D").ShouldBe("8bb1290a-9336-4371-8dad-fccd8d9c4494");
        }
    }

    public class RoundtripTests
    {
        [Fact]

        public async Task RoundtripDTO()
        {
            Octets smallBinary = new Octets(new byte[] { 1, 2, 3, 4, 5, 6, 7 });
            Octets largeBinary = new Octets(Enumerable.Range(0, 256).Select(i => (byte)i).ToArray());

            using var dataStore = new DataFac.Storage.Testing.TestDataStore();

            var orig = new T_NameSpace_.MemBlocks.T_EntityName_();
            orig.BaseField1 = 789;
            orig.T_ScalarMemberName_ = 123;
            orig.T_VectorMemberName_ = new int[] { 1, 2, 3 };
            orig.T_RequiredEntityMemberName_ = new T_MemberTypeNameSpace_.MemBlocks.T_MemberTypeName_() { Field1 = 123 };
            orig.T_RequiredFixLenBinaryMemberName_ = smallBinary;
            orig.T_RequiredVarLenBinaryMemberName_ = largeBinary;
            orig.T_NullableFixLenBinaryMemberName_ = null;
            orig.T_NullableVarLenBinaryMemberName_ = smallBinary;
            await orig.Pack(dataStore);
            orig.Freeze();

            var buffers = orig.GetBuffer();

            var copy = T_NameSpace_.MemBlocks.T_EntityName_.CreateFrom(buffers);
            copy.IsFrozen.ShouldBeTrue();
            await copy.Unpack(dataStore, 0);
            copy.BaseField1.ShouldBe(orig.BaseField1);
            copy.T_ScalarMemberName_.ShouldBe(orig.T_ScalarMemberName_);
            copy.T_VectorMemberName_.Span.SequenceEqual(orig.T_VectorMemberName_.Span).ShouldBeTrue();
            copy.T_RequiredEntityMemberName_.ShouldNotBeNull();
            copy.T_RequiredFixLenBinaryMemberName_.ShouldBe(orig.T_RequiredFixLenBinaryMemberName_);
            copy.T_RequiredVarLenBinaryMemberName_.ShouldBe(orig.T_RequiredVarLenBinaryMemberName_);
            copy.T_NullableFixLenBinaryMemberName_.ShouldBe(orig.T_NullableFixLenBinaryMemberName_);
            copy.T_NullableVarLenBinaryMemberName_.ShouldBe(orig.T_NullableVarLenBinaryMemberName_);
            await copy.T_RequiredEntityMemberName_.Unpack(dataStore, 0);
            copy.T_RequiredEntityMemberName_!.Field1.ShouldBe(orig.T_RequiredEntityMemberName_.Field1);
        }
    }
}