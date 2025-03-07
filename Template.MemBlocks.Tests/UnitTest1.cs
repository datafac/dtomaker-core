using DataFac.Memory;
using DTOMaker.Runtime.MemBlocks;
using Shouldly;
using System;
using System.Buffers;
using System.Linq;
using System.Text;
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
        //##}
        private static readonly long _structureBits = 0x0051;
        private const int ClassHeight = 1;
        private const int EntityId = 4;
        private const int BlockLength = 32;
        private readonly Memory<byte> _writableLocalBlock;
        private readonly ReadOnlyMemory<byte> _readonlyLocalBlock;

        private static readonly BlockHeader _header = BlockHeader.CreateNew(EntityId, _structureBits);

        protected override int OnGetClassHeight() => ClassHeight;
        protected override ReadOnlySequenceBuilder<byte> OnSequenceBuilder(ReadOnlySequenceBuilder<byte> builder) => base.OnSequenceBuilder(builder).Append(_readonlyLocalBlock);
        protected override int OnGetEntityId() => EntityId;
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
            BlockB016 outgoing = default;
            // signature
            outgoing.A.A.A.A.ByteValue = (byte)'|';
            outgoing.A.A.A.B.ByteValue = (byte)'_';
            outgoing.A.A.B.A.ByteValue = (byte)1;
            outgoing.A.A.B.B.ByteValue = (byte)1;
            // entity id
            outgoing.A.B.A.Int16ValueLE = 4;
            // structure
            outgoing.B.Int64ValueLE = 0x61;

            Memory<byte> buffer = new byte[Constants.HeaderSize];
            bool written = outgoing.TryWrite(buffer.Span);
            written.ShouldBeTrue();

            BlockHeader incoming = BlockHeader.ParseFrom(buffer);
            incoming.SignatureBits.ShouldBe(0x01015f7c);
            incoming.StructureBits.ShouldBe(0x61);
            incoming.EntityId.ShouldBe(4);
        }

        [Fact]
        public async Task BlockHeaderIsConstant()
        {
            using var dataStore = new DataFac.Storage.Testing.TestDataStore();
            var orig = new TestEntity();
            await orig.Pack(dataStore);
            orig.Freeze();
            var buffer = orig.GetBuffers().Compact();
            buffer.Length.ShouldBe(48);

            buffer.Span[0].ShouldBe((byte)'|');  // marker byte 0
            buffer.Span[1].ShouldBe((byte)'_');  // marker byte 1
            buffer.Span[2].ShouldBe((byte)1);    // major version
            buffer.Span[3].ShouldBe((byte)1);    // minor version

            BlockHeader parsed = BlockHeader.ParseFrom(buffer);
            parsed.SignatureBits.ShouldBe(0x01015f7c);
            parsed.StructureBits.ShouldBe(0x51);
            parsed.EntityId.ShouldBe(4);
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

            var buffers = orig.GetBuffers();

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