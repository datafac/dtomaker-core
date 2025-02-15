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
    public partial class Other : DTOMaker.Runtime.MemBlocks.EntityBase, IOther, IEquatable<Other>
    {
        // Derived entities: 0

        private const long BlockSignatureCode = 89980L;
        private const long BlockStructureCode = 65L;
        private const int ClassHeight = 1;
        private const int BlockOffset = 64;
        private const int BlockLength = 16;
        private readonly Memory<byte> _writableLocalBlock;
        private readonly ReadOnlyMemory<byte> _readonlyLocalBlock;

        public new const string EntityId = "46b4cf1e-d1f9-48ac-af8e-4c8b4d40b077";
        private static readonly Guid EntityGuid = new Guid("46b4cf1e-d1f9-48ac-af8e-4c8b4d40b077");
        private static readonly BlockStructure _structure = new BlockStructure(BlockSignatureCode, BlockStructureCode, EntityGuid);

        public new static Other CreateFrom(Other source)
        {
            if (source.IsFrozen) return source;
            return source switch
            {
                _ => new MyOrg.Models.MemBlocks.Other(source)
            };
        }

        public new static Other CreateFrom(MyOrg.Models.IOther source)
        {
            if (source is Other concrete && concrete.IsFrozen) return concrete;
            return source switch
            {
                _ => new MyOrg.Models.MemBlocks.Other(source)
            };
        }

        public new static Other CreateFrom(ReadOnlyMemory<byte> buffer)
        {
            BlockStructure thatStructure = new BlockStructure(buffer.Span);
            string entityIdStr = thatStructure.EntityGuid.ToString("D");
            return entityIdStr switch
            {
                _ => new MyOrg.Models.MemBlocks.Other(buffer)
            };
        }

        protected override string OnGetEntityId() => EntityId;
        protected override int OnGetClassHeight() => ClassHeight;

        protected override IFreezable OnPartCopy() => new Other(this);

        protected override void OnFreeze()
        {
            base.OnFreeze();
        }

        protected override async ValueTask OnPack(IDataStore dataStore)
        {
            await base.OnPack(dataStore);
        }

        protected override async ValueTask OnUnpack(IDataStore dataStore, int depth)
        {
            await base.OnUnpack(dataStore, depth);
        }

        // -------------------- field map -----------------------------
        //  Seq.  Off.  Len.  N.    Type    End.  Name
        //  ----  ----  ----  ----  ------- ----  -------
        //     1     0     8        Int64   LE    Value1
        //     2     8     8        Int64   LE    Value2
        // ------------------------------------------------------------

        protected Other(BlockStructure structure) : base(structure)
        {
            _readonlyLocalBlock = _writableLocalBlock = _writableTotalBlock.Slice(BlockOffset, BlockLength);
        }

        public Other() : base(_structure)
        {
            _readonlyLocalBlock = _writableLocalBlock = _writableTotalBlock.Slice(BlockOffset, BlockLength);
        }

        protected Other(BlockStructure structure, Other source) : base(structure, source)
        {
            _readonlyLocalBlock = _writableLocalBlock = _writableTotalBlock.Slice(BlockOffset, BlockLength);
        }

        public Other(Other source) : base(_structure, source)
        {
            _readonlyLocalBlock = _writableLocalBlock = _writableTotalBlock.Slice(BlockOffset, BlockLength);
        }

        protected Other(BlockStructure structure, IOther source) : base(structure, source)
        {
            _readonlyLocalBlock = _writableLocalBlock = _writableTotalBlock.Slice(BlockOffset, BlockLength);
            this.Value1 = source.Value1;
            this.Value2 = source.Value2;
        }

        public Other(IOther source) : base(_structure, source)
        {
            _readonlyLocalBlock = _writableLocalBlock = _writableTotalBlock.Slice(BlockOffset, BlockLength);
            this.Value1 = source.Value1;
            this.Value2 = source.Value2;
        }

        protected Other(BlockStructure structure, ReadOnlyMemory<byte> buffer) : base(structure, buffer)
        {
            _readonlyLocalBlock = _readonlyTotalBlock.Slice(BlockOffset, BlockLength);
            _writableLocalBlock = Memory<byte>.Empty;
        }
        public Other(ReadOnlyMemory<byte> buffer) : base(_structure, buffer)
        {
            _readonlyLocalBlock = _readonlyTotalBlock.Slice(BlockOffset, BlockLength);
            _writableLocalBlock = Memory<byte>.Empty;
        }

        public Int64 Value1
        {
            get => Codec_Int64_LE.ReadFromSpan(_readonlyLocalBlock.Slice(0, 8).Span);
            set => Codec_Int64_LE.WriteToSpan(_writableLocalBlock.Slice(0, 8).Span, IfNotFrozen(value));
        }

        public Int64 Value2
        {
            get => Codec_Int64_LE.ReadFromSpan(_readonlyLocalBlock.Slice(8, 8).Span);
            set => Codec_Int64_LE.WriteToSpan(_writableLocalBlock.Slice(8, 8).Span, IfNotFrozen(value));
        }


        public bool Equals(Other? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            if (!_readonlyTotalBlock.Span.SequenceEqual(other._readonlyTotalBlock.Span)) return false;
            return true;
        }
        public override bool Equals(object? obj) => obj is Other other && Equals(other);
        public override int GetHashCode() => base.GetHashCode();
        public static bool operator ==(Other? left, Other? right) => left is not null ? left.Equals(right) : (right is null);
        public static bool operator !=(Other? left, Other? right) => left is not null ? !left.Equals(right) : (right is not null);

    }
}
