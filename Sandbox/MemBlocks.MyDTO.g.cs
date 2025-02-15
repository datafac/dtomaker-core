﻿// <auto-generated>
// This file was generated by DTOMaker.MemBlocks.
// NuGet: https://www.nuget.org/packages/DTOMaker.MemBlocks
// Warning: Changes made to this file will be lost if re-generated.
// </auto-generated>
#pragma warning disable CS0109 // Member does not hide an inherited member; new keyword is not required
#nullable enable
using System;
using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using DataFac.Memory;
using DTOMaker.Runtime;
using DTOMaker.Runtime.MemBlocks;
using DataFac.Storage;

namespace MyOrg.Models.MemBlocks
{
    public partial class MyDTO : DTOMaker.Runtime.MemBlocks.EntityBase, IMyDTO, IEquatable<MyDTO>
    {
        // Derived entities: 0

        private const long BlockSignatureCode = 89980L;
        private const long BlockStructureCode = 129L;
        private const int ClassHeight = 1;
        private const int BlockOffset = 64;
        private const int BlockLength = 256;
        private readonly Memory<byte> _writableLocalBlock;
        private readonly ReadOnlyMemory<byte> _readonlyLocalBlock;

        public new const string EntityId = "81bd408d-c10a-4fc2-81e1-4517b4e199bb";
        private static readonly Guid EntityGuid = new Guid("81bd408d-c10a-4fc2-81e1-4517b4e199bb");
        private static readonly BlockStructure _structure = new BlockStructure(BlockSignatureCode, BlockStructureCode, EntityGuid);

        public new static MyDTO CreateFrom(MyDTO source)
        {
            if (source.IsFrozen) return source;
            return source switch
            {
                _ => new MyOrg.Models.MemBlocks.MyDTO(source)
            };
        }

        public new static MyDTO CreateFrom(MyOrg.Models.IMyDTO source)
        {
            if (source is MyDTO concrete && concrete.IsFrozen) return concrete;
            return source switch
            {
                _ => new MyOrg.Models.MemBlocks.MyDTO(source)
            };
        }

        public new static MyDTO CreateFrom(ReadOnlyMemory<byte> buffer)
        {
            BlockStructure thatStructure = new BlockStructure(buffer.Span);
            string entityIdStr = thatStructure.EntityGuid.ToString("D");
            return entityIdStr switch
            {
                _ => new MyOrg.Models.MemBlocks.MyDTO(buffer)
            };
        }

        protected override string OnGetEntityId() => EntityId;
        protected override int OnGetClassHeight() => ClassHeight;

        protected override IFreezable OnPartCopy() => new MyDTO(this);

        protected override void OnFreeze()
        {
            base.OnFreeze();
            _Other1?.Freeze();
        }

        protected override async ValueTask OnPack(IDataStore dataStore)
        {
            await base.OnPack(dataStore);
            await Other1_Pack(dataStore);
            await Field1_Pack(dataStore);
            await Field2_Pack(dataStore);
        }

        protected override async ValueTask OnUnpack(IDataStore dataStore, int depth)
        {
            await base.OnUnpack(dataStore, depth);
            await Other1_Unpack(dataStore, depth);
            await Field1_Unpack(dataStore, depth);
            await Field2_Unpack(dataStore, depth);
        }

        // -------------------- field map -----------------------------
        //  Seq.  Off.  Len.  N.    Type    End.  Name
        //  ----  ----  ----  ----  ------- ----  -------
        //     1     0    64        Other   LE    Other1
        //     2    64    64        Octets  LE    Field1
        //     3   128    64        Octets  LE    Field2
        // ------------------------------------------------------------

        protected MyDTO(BlockStructure structure) : base(structure)
        {
            _readonlyLocalBlock = _writableLocalBlock = _writableTotalBlock.Slice(BlockOffset, BlockLength);
        }

        public MyDTO() : base(_structure)
        {
            _readonlyLocalBlock = _writableLocalBlock = _writableTotalBlock.Slice(BlockOffset, BlockLength);
        }

        protected MyDTO(BlockStructure structure, MyDTO source) : base(structure, source)
        {
            _readonlyLocalBlock = _writableLocalBlock = _writableTotalBlock.Slice(BlockOffset, BlockLength);
        }

        public MyDTO(MyDTO source) : base(_structure, source)
        {
            _readonlyLocalBlock = _writableLocalBlock = _writableTotalBlock.Slice(BlockOffset, BlockLength);
        }

        protected MyDTO(BlockStructure structure, IMyDTO source) : base(structure, source)
        {
            _readonlyLocalBlock = _writableLocalBlock = _writableTotalBlock.Slice(BlockOffset, BlockLength);
            _Other1 = source.Other1 is null ? null : MyOrg.Models.MemBlocks.Other.CreateFrom(source.Other1);
            _Field1 = source.Field1;
            _Field2 = source.Field2;
        }

        public MyDTO(IMyDTO source) : base(_structure, source)
        {
            _readonlyLocalBlock = _writableLocalBlock = _writableTotalBlock.Slice(BlockOffset, BlockLength);
            _Other1 = source.Other1 is null ? null : MyOrg.Models.MemBlocks.Other.CreateFrom(source.Other1);
            _Field1 = source.Field1;
            _Field2 = source.Field2;
        }

        protected MyDTO(BlockStructure structure, ReadOnlyMemory<byte> buffer) : base(structure, buffer)
        {
            _readonlyLocalBlock = _readonlyTotalBlock.Slice(BlockOffset, BlockLength);
            _writableLocalBlock = Memory<byte>.Empty;
        }
        public MyDTO(ReadOnlyMemory<byte> buffer) : base(_structure, buffer)
        {
            _readonlyLocalBlock = _readonlyTotalBlock.Slice(BlockOffset, BlockLength);
            _writableLocalBlock = Memory<byte>.Empty;
        }

        private async ValueTask Other1_Pack(IDataStore dataStore)
        {
            BlobIdV1 blobId = default;
            if (_Other1 is not null)
            {
                await _Other1.Pack(dataStore);
                var buffer = _Other1.GetBuffer();
                var blob = BlobData.UnsafeWrap(buffer);
                blobId = await dataStore.PutBlob(blob);
            }
            Codec_BlobId_NE.WriteToSpan(_writableLocalBlock.Slice(0, 64).Span, blobId);
        }
        private async ValueTask Other1_Unpack(IDataStore dataStore, int depth)
        {
            _Other1 = null;
            BlobIdV1 blobId = Codec_BlobId_NE.ReadFromSpan(_readonlyLocalBlock.Slice(0, 64).Span);
            if (!blobId.IsEmpty)
            {
                BlobData? blob = await dataStore.GetBlob(blobId);
                if (blob is null) throw new InvalidDataException($"Blob not found: {blobId}");
                _Other1 = MyOrg.Models.MemBlocks.Other.CreateFrom(blob.Value.Memory);
                await _Other1.Unpack(dataStore, depth - 1);
            }
        }
        private MyOrg.Models.MemBlocks.Other? _Other1;
        public MyOrg.Models.MemBlocks.Other? Other1
        {
            get => IfUnpacked(_Other1);
            set => _Other1 = IfNotFrozen(value);
        }
        MyOrg.Models.IOther? IMyDTO.Other1
        {
            get => IfUnpacked(_Other1);
            set => _Other1 = IfNotFrozen(value is null ? null : MyOrg.Models.MemBlocks.Other.CreateFrom(value));
        }

        private async ValueTask Field1_Pack(IDataStore dataStore)
        {
            BlobIdV1 blobId = default;
            var buffer = _Field1.Memory;
            var blob = BlobData.UnsafeWrap(buffer);
            blobId = await dataStore.PutBlob(blob);
            Codec_BlobId_NE.WriteToSpan(_writableLocalBlock.Slice(64, 64).Span, blobId);
        }
        private async ValueTask Field1_Unpack(IDataStore dataStore, int depth)
        {
            _Field1 = Octets.Empty;
            BlobIdV1 blobId = Codec_BlobId_NE.ReadFromSpan(_readonlyLocalBlock.Slice(64, 64).Span);
            if (!blobId.IsEmpty)
            {
                BlobData? blob = await dataStore.GetBlob(blobId);
                if (blob is null) throw new InvalidDataException($"Blob not found: {blobId}");
                _Field1 = Octets.UnsafeWrap(blob.Value.Memory);
            }
        }
        private Octets _Field1 = Octets.Empty;
        public Octets Field1
        {
            get => IfUnpacked(_Field1);
            set => _Field1 = IfNotFrozen(value);
        }

        private async ValueTask Field2_Pack(IDataStore dataStore)
        {
            BlobIdV1 blobId = default;
            if (_Field2 is not null)
            {
                var buffer = _Field2.Memory;
                var blob = BlobData.UnsafeWrap(buffer);
                blobId = await dataStore.PutBlob(blob);
            }
            Codec_BlobId_NE.WriteToSpan(_writableLocalBlock.Slice(128, 64).Span, blobId);
        }
        private async ValueTask Field2_Unpack(IDataStore dataStore, int depth)
        {
            _Field2 = null;
            BlobIdV1 blobId = Codec_BlobId_NE.ReadFromSpan(_readonlyLocalBlock.Slice(128, 64).Span);
            if (!blobId.IsEmpty)
            {
                BlobData? blob = await dataStore.GetBlob(blobId);
                if (blob is null) throw new InvalidDataException($"Blob not found: {blobId}");
                _Field2 = Octets.UnsafeWrap(blob.Value.Memory);
            }
        }
        private Octets? _Field2;
        public Octets? Field2
        {
            get => IfUnpacked(_Field2);
            set => _Field2 = IfNotFrozen(value);
        }


        public bool Equals(MyDTO? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            if (!_readonlyTotalBlock.Span.SequenceEqual(other._readonlyTotalBlock.Span)) return false;
            return true;
        }
        public override bool Equals(object? obj) => obj is MyDTO other && Equals(other);
        public override int GetHashCode() => base.GetHashCode();
        public static bool operator ==(MyDTO? left, MyDTO? right) => left is not null ? left.Equals(right) : (right is null);
        public static bool operator !=(MyDTO? left, MyDTO? right) => left is not null ? !left.Equals(right) : (right is not null);

    }
}
