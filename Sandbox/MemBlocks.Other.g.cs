﻿// <auto-generated>
// This file was generated by DTOMaker.MemBlocks.
// NuGet: https://www.nuget.org/packages/DTOMaker.MemBlocks
// Warning: Changes made to this file will be lost if re-generated.
// </auto-generated>
#pragma warning disable CS0109 // Member does not hide an inherited member; new keyword is not required
#nullable enable
using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DataFac.Memory;
using DataFac.Storage;
using DTOMaker.Runtime;
using DTOMaker.Runtime.MemBlocks;

namespace MyOrg.Models.MemBlocks
{
    public partial class Other : DTOMaker.Runtime.MemBlocks.EntityBase, IOther, IEquatable<Other>
    {
        // Derived entities: 0

        private const long BlockStructureCode = 81L;
        private const int ClassHeight = 1;
        private const int EntityId = 0;
        private const int BlockLength = 16;
        private readonly Memory<byte> _writableLocalBlock;
        private readonly ReadOnlyMemory<byte> _readonlyLocalBlock;

        private static readonly BlockHeader _header = BlockHeader.CreateNew(EntityId, BlockStructureCode);

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

        public new static Other CreateFrom(ReadOnlySequence<byte> buffers)
        {
            ReadOnlyMemory<byte> buffer = buffers.Slice(0, Constants.HeaderSize).Compact();
            BlockHeader header = BlockHeader.ParseFrom(buffer);
            return header.EntityId switch
            {
                _ => new MyOrg.Models.MemBlocks.Other(buffers)
            };
        }

        protected override int OnGetEntityId() => EntityId;
        protected override int OnGetClassHeight() => ClassHeight;
        protected override ReadOnlySequenceBuilder<byte> OnSequenceBuilder(ReadOnlySequenceBuilder<byte> builder) => base.OnSequenceBuilder(builder).Append(_readonlyLocalBlock);
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

        protected Other(BlockHeader header) : base(header)
        {
            _readonlyLocalBlock = _writableLocalBlock = new byte[BlockLength];
        }
        public Other() : base(_header)
        {
            _readonlyLocalBlock = _writableLocalBlock = new byte[BlockLength];
        }

        protected Other(BlockHeader header, Other source) : base(header, source)
        {
            _readonlyLocalBlock = _writableLocalBlock = new byte[BlockLength];
        }
        public Other(Other source) : base(_header, source)
        {
            _readonlyLocalBlock = _writableLocalBlock = new byte[BlockLength];
        }

        protected Other(BlockHeader header, IOther source) : base(header, source)
        {
            _readonlyLocalBlock = _writableLocalBlock = new byte[BlockLength];
            this.Value1 = source.Value1;
            this.Value2 = source.Value2;
        }

        public Other(IOther source) : base(_header, source)
        {
            _readonlyLocalBlock = _writableLocalBlock = new byte[BlockLength];
            this.Value1 = source.Value1;
            this.Value2 = source.Value2;
        }

        protected Other(BlockHeader header, SourceBlocks sourceBlocks) : base(header, sourceBlocks)
        {
            var sourceBlock = sourceBlocks.Blocks.Span[ClassHeight];
            if (sourceBlock.Length < BlockLength)
            {
                // source too small - allocate new
                Memory<byte> memory = new byte[BlockLength];
                sourceBlock.CopyTo(memory);
                _readonlyLocalBlock = memory;
            }
            else
            {
                _readonlyLocalBlock = sourceBlock;
            }
            _writableLocalBlock = Memory<byte>.Empty;
        }
        public Other(ReadOnlySequence<byte> buffers) : this(_header, SourceBlocks.ParseFrom(buffers))
        {
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
            if (!base.Equals(other)) return false;
            if (!_readonlyLocalBlock.Span.SequenceEqual(other._readonlyLocalBlock.Span)) return false;
            return true;
        }
        public override bool Equals(object? obj) => obj is Other other && Equals(other);
        public override int GetHashCode() => base.GetHashCode();
        public static bool operator ==(Other? left, Other? right) => left is not null ? left.Equals(right) : (right is null);
        public static bool operator !=(Other? left, Other? right) => left is not null ? !left.Equals(right) : (right is not null);

    }
}
