using System;
using System.Linq;
using DTOMaker.Gentime;
namespace DTOMaker.MemBlocks;
#pragma warning disable CS0162 // Unreachable code detected
public sealed class EntityGenerator : EntityGeneratorBase
{
    public EntityGenerator(ILanguage language) : base(language) { }
    protected override void OnGenerate(ModelScopeEntity entity)
    {
Emit("// <auto-generated>");
Emit("// This file was generated by DTOMaker.MemBlocks.");
Emit("// NuGet: https://www.nuget.org/packages/DTOMaker.MemBlocks");
Emit("// Warning: Changes made to this file will be lost if re-generated.");
Emit("// </auto-generated>");
if(false) {
Emit("#pragma warning disable CS0618 // Type or member is obsolete");
Emit("#pragma warning disable CS0162 // Unreachable code detected");
}
Emit("#pragma warning disable CS0109 // Member does not hide an inherited member; new keyword is not required");
Emit("#nullable enable");
Emit("using System;");
Emit("using System.Runtime.CompilerServices;");
Emit("using System.Runtime.InteropServices;");
Emit("using DataFac.Memory;");
Emit("using DTOMaker.Runtime;");
Emit("using DTOMaker.Runtime.MemBlocks;");
if(false) {
Emit("using T_MemberType_ = System.Int32;");
Emit("namespace DataFac.Memory");
Emit("{");
Emit("    public static class Codec_T_MemberType__T_MemberBELE_");
Emit("    {");
Emit("        public static T_MemberType_ ReadFromSpan(ReadOnlySpan<byte> source) => Codec_Int32_LE.ReadFromSpan(source);");
Emit("        public static void WriteToSpan(Span<byte> source, T_MemberType_ value) => Codec_Int32_LE.WriteToSpan(source, value);");
Emit("    }");
Emit("}");
Emit("namespace T_MemberTypeNameSpace_");
Emit("{");
Emit("    public interface IT_MemberTypeName_ { }");
Emit("}");
Emit("namespace T_MemberTypeNameSpace_.MemBlocks");
Emit("{");
Emit("    public class T_MemberTypeName_ : EntityBase, IT_MemberTypeName_");
Emit("    {");
Emit("        private static readonly T_MemberTypeName_ _empty = new T_MemberTypeName_();");
Emit("        public static T_MemberTypeName_ Empty => _empty;");
Emit("        public static T_MemberTypeName_ CreateFrom(IT_MemberTypeName_ source) => throw new NotImplementedException();");
Emit("        public T_MemberTypeName_() { }");
Emit("        public T_MemberTypeName_(IT_MemberTypeName_ source) { }");
Emit("        protected override IFreezable OnPartCopy() => throw new NotImplementedException();");
Emit("        protected override string OnGetEntityId() => \"T_MemberTypeName_\";");
Emit("        protected override int OnGetClassHeight() => throw new NotImplementedException();");
Emit("    }");
Emit("}");
Emit("namespace T_BaseNameSpace_.MemBlocks");
Emit("{");
Emit("    public interface IT_BaseName_");
Emit("    {");
Emit("        T_MemberType_ BaseField1 { get; set; }");
Emit("    }");
Emit("    public class T_BaseName_ : EntityBase, IT_BaseName_, IEquatable<T_BaseName_>");
Emit("    {");
Emit("        private const int ClassHeight = 1;");
Emit("        private const int BlockLength = 64;");
Emit("        private readonly Memory<byte> _writableBlock;");
Emit("        private readonly ReadOnlyMemory<byte> _readonlyBlock;");
Emit("");
Emit("        public new const string EntityId = \"T_BaseName_\";");
Emit("");
Emit("        protected override string OnGetEntityId() => \"_undefined_\";");
Emit("        protected override int OnGetClassHeight() => ClassHeight;");
Emit("        protected override void OnGetBuffers(ReadOnlyMemory<byte>[] buffers)");
Emit("        {");
Emit("            base.OnGetBuffers(buffers);");
Emit("            var block = IsFrozen ? _readonlyBlock : _writableBlock.ToArray();");
Emit("            buffers[ClassHeight - 1] = block;");
Emit("        }");
Emit("        protected override void OnLoadBuffers(ReadOnlyMemory<ReadOnlyMemory<byte>> buffers)");
Emit("        {");
Emit("            base.OnLoadBuffers(buffers);");
Emit("            ReadOnlyMemory<byte> source = buffers.Span[ClassHeight - 1];");
Emit("            if (source.Length > BlockLength)");
Emit("            {");
Emit("                source.Slice(0, BlockLength).CopyTo(_writableBlock);");
Emit("            }");
Emit("            else");
Emit("            {");
Emit("                source.CopyTo(_writableBlock);");
Emit("            }");
Emit("        }");
Emit("");
Emit("        public T_BaseName_()");
Emit("        {");
Emit("            _readonlyBlock = _writableBlock = new byte[BlockLength];");
Emit("        }");
Emit("");
Emit("        public T_BaseName_(T_BaseName_ source) : base(source)");
Emit("        {");
Emit("            _writableBlock = source._writableBlock.ToArray();");
Emit("            _readonlyBlock = _writableBlock;");
Emit("        }");
Emit("");
Emit("        public T_BaseName_(IT_BaseName_ source) : base(source)");
Emit("        {");
Emit("            _readonlyBlock = _writableBlock = new byte[BlockLength];");
Emit("            this.BaseField1 = source.BaseField1;");
Emit("        }");
Emit("");
Emit("        public T_BaseName_(ReadOnlyMemory<ReadOnlyMemory<byte>> buffers) : base(buffers)");
Emit("        {");
Emit("            ReadOnlyMemory<byte> source = buffers.Span[ClassHeight - 1];");
Emit("            if (source.Length > BlockLength)");
Emit("            {");
Emit("                _readonlyBlock = source.Slice(0, BlockLength);");
Emit("            }");
Emit("            else");
Emit("            {");
Emit("                // forced copy as source is too short");
Emit("                Memory<byte> memory = new byte[BlockLength];");
Emit("                source.Span.CopyTo(memory.Span);");
Emit("                _readonlyBlock = memory;");
Emit("            }");
Emit("            _writableBlock = Memory<byte>.Empty;");
Emit("        }");
Emit("");
Emit("        private const int T_FieldOffset_ = 4;");
Emit("        private const int T_FieldLength_ = 4;");
Emit("");
Emit("        public T_MemberType_ BaseField1");
Emit("        {");
Emit("            get");
Emit("            {");
Emit("                return (T_MemberType_)Codec_T_MemberType__T_MemberBELE_.ReadFromSpan(_readonlyBlock.Slice(T_FieldOffset_, T_FieldLength_).Span);");
Emit("            }");
Emit("");
Emit("            set");
Emit("            {");
Emit("                ThrowIfFrozen();");
Emit("                Codec_T_MemberType__T_MemberBELE_.WriteToSpan(_writableBlock.Slice(T_FieldOffset_, T_FieldLength_).Span, value);");
Emit("            }");
Emit("        }");
Emit("");
Emit("        public bool Equals(T_BaseName_? other)");
Emit("        {");
Emit("            if (ReferenceEquals(this, other)) return true;");
Emit("            if (other is null) return false;");
Emit("            if (!base.Equals(other)) return false;");
Emit("            if (!_readonlyBlock.Span.SequenceEqual(other._readonlyBlock.Span)) return false;");
Emit("            return true;");
Emit("        }");
Emit("        public override bool Equals(object? obj) => obj is T_BaseName_ other && Equals(other);");
Emit("        public override int GetHashCode() => base.GetHashCode();");
Emit("    }");
Emit("}");
Emit("namespace T_NameSpace_");
Emit("{");
Emit("    public interface IT_EntityName_ : T_BaseNameSpace_.MemBlocks.IT_BaseName_");
Emit("    {");
Emit("        T_MemberType_ T_ScalarMemberName_ { get; set; }");
Emit("        ReadOnlyMemory<T_MemberType_> T_VectorMemberName_ { get; set; }");
Emit("        T_MemberTypeNameSpace_.IT_MemberTypeName_? T_NullableEntityMemberName_ { get; set; }");
Emit("        T_MemberTypeNameSpace_.IT_MemberTypeName_ T_RequiredEntityMemberName_ { get; set; }");
Emit("    }");
Emit("}");
}
Emit("namespace T_NameSpace_.MemBlocks");
Emit("{");
Emit("    public partial class T_EntityName_ : T_BaseNameSpace_.MemBlocks.T_BaseName_, IT_EntityName_, IEquatable<T_EntityName_>");
Emit("    {");
Emit("        // Derived entities: T_DerivedEntityCount_");
        foreach(var derived in entity.DerivedEntities) {
        using var _ = NewScope(derived);
Emit("        // - T_EntityName_");
        }
Emit("");
        if(false) {
Emit("        private const int T_ClassHeight_ = 2;");
Emit("        private const int T_BlockLength_ = 128;");
Emit("        private const bool T_MemberObsoleteIsError_ = false;");
        }
Emit("        private const int ClassHeight = T_ClassHeight_;");
Emit("        private const int BlockLength = T_BlockLength_;");
Emit("        private readonly Memory<byte> _writableBlock;");
Emit("        private readonly ReadOnlyMemory<byte> _readonlyBlock;");
Emit("");
Emit("        public new const string EntityId = \"T_EntityId_\";");
Emit("");
Emit("        public new static T_EntityName_ CreateFrom(T_EntityName_ source)");
Emit("        {");
Emit("            if (source.IsFrozen) return source;");
Emit("            return source switch");
Emit("            {");
                foreach(var derived in entity.DerivedEntities.OrderByDescending(e => e.ClassHeight)) {
                using var _ = NewScope(derived);
Emit("                T_NameSpace_.MemBlocks.T_EntityName_ source2 => new T_NameSpace_.MemBlocks.T_EntityName_(source2),");
                }
Emit("                _ => new T_NameSpace_.MemBlocks.T_EntityName_(source)");
Emit("            };");
Emit("        }");
Emit("");
Emit("        public new static T_EntityName_ CreateFrom(T_NameSpace_.IT_EntityName_ source)");
Emit("        {");
Emit("            if (source is T_EntityName_ concrete && concrete.IsFrozen) return concrete;");
Emit("            return source switch");
Emit("            {");
                foreach(var derived in entity.DerivedEntities.OrderByDescending(e => e.ClassHeight)) {
                using var _ = NewScope(derived);
Emit("                T_NameSpace_.IT_EntityName_ source2 => new T_NameSpace_.MemBlocks.T_EntityName_(source2),");
                }
Emit("                _ => new T_NameSpace_.MemBlocks.T_EntityName_(source)");
Emit("            };");
Emit("        }");
Emit("");
Emit("        public new static T_EntityName_ CreateFrom(string entityId, ReadOnlyMemory<ReadOnlyMemory<byte>> buffers)");
Emit("        {");
Emit("            return entityId switch");
Emit("            {");
                foreach(var derived in entity.DerivedEntities) {
                using var _ = NewScope(derived);
Emit("                T_NameSpace_.MemBlocks.T_EntityName_.EntityId => new T_NameSpace_.MemBlocks.T_EntityName_(buffers),");
                }
Emit("                _ => throw new ArgumentOutOfRangeException(nameof(entityId), entityId, null)");
Emit("            };");
Emit("        }");
Emit("");
Emit("        protected override string OnGetEntityId() => EntityId;");
Emit("        protected override int OnGetClassHeight() => ClassHeight;");
Emit("        protected override void OnGetBuffers(ReadOnlyMemory<byte>[] buffers)");
Emit("        {");
Emit("            base.OnGetBuffers(buffers);");
Emit("            var block = IsFrozen ? _readonlyBlock : _writableBlock.ToArray();");
Emit("            buffers[ClassHeight - 1] = block;");
Emit("        }");
Emit("        protected override void OnLoadBuffers(ReadOnlyMemory<ReadOnlyMemory<byte>> buffers)");
Emit("        {");
Emit("            base.OnLoadBuffers(buffers);");
Emit("            ReadOnlyMemory<byte> source = buffers.Span[ClassHeight - 1];");
Emit("            if (source.Length > BlockLength)");
Emit("            {");
Emit("                source.Slice(0, BlockLength).CopyTo(_writableBlock);");
Emit("            }");
Emit("            else");
Emit("            {");
Emit("                source.CopyTo(_writableBlock);");
Emit("            }");
Emit("        }");
Emit("");
Emit("        // -------------------- field map -----------------------------");
Emit("        //  Seq.  Off.  Len.  N.    Type    End.  Name");
Emit("        //  ----  ----  ----  ----  ------- ----  -------");
        foreach(var member in entity.Members) {
        using var _ = NewScope(member);
Emit("        //  T_MemberSequenceR4_  T_FieldOffsetR4_  T_FieldLengthR4_  T_ArrayLengthR4_  T_MemberTypeL7_ T_MemberBELE_    T_MemberName_");
        }
Emit("        // ------------------------------------------------------------");
Emit("");
Emit("        public T_EntityName_()");
Emit("        {");
Emit("            _readonlyBlock = _writableBlock = new byte[BlockLength];");
Emit("        }");
Emit("");
Emit("        public T_EntityName_(T_EntityName_ source) : base(source)");
Emit("        {");
Emit("            _writableBlock = source._readonlyBlock.ToArray();");
Emit("            _readonlyBlock = _writableBlock;");
Emit("        }");
Emit("");
Emit("        public T_EntityName_(IT_EntityName_ source) : base(source)");
Emit("        {");
Emit("            _readonlyBlock = _writableBlock = new byte[BlockLength];");
            foreach(var member in entity.Members) {
            using var _ = NewScope(member);
            if(member.IsVector) {
Emit("            this.T_VectorMemberName_ = source.T_VectorMemberName_;");
            } else {
Emit("            this.T_ScalarMemberName_ = source.T_ScalarMemberName_;");
            }
            }
Emit("        }");
Emit("");
Emit("        public T_EntityName_(ReadOnlyMemory<ReadOnlyMemory<byte>> buffers) : base(buffers)");
Emit("        {");
Emit("            ReadOnlyMemory<byte> source = buffers.Span[ClassHeight - 1];");
Emit("            if (source.Length >= BlockLength)");
Emit("            {");
Emit("                _readonlyBlock = source.Slice(0, BlockLength);");
Emit("            }");
Emit("            else");
Emit("            {");
Emit("                // forced copy as source is too short");
Emit("                Memory<byte> memory = new byte[BlockLength];");
Emit("                source.Span.CopyTo(memory.Span);");
Emit("                _readonlyBlock = memory;");
Emit("            }");
Emit("            _writableBlock = Memory<byte>.Empty;");
Emit("        }");
Emit("");
        if(false) {
Emit("        private const int T_FieldOffset_ = 32;");
Emit("        private const int T_FieldLength_ = 8;");
Emit("        private const bool T_IsBigEndian_ = false;");
Emit("        private const int T_ArrayLength_ = 4;");
        }
        foreach(var member in entity.Members) {
        using var _ = NewScope(member);
        if(member.IsObsolete) {
Emit("        [Obsolete(\"T_MemberObsoleteMessage_\", T_MemberObsoleteIsError_)]");
        }
        if(member.IsVector) {
Emit("        public ReadOnlyMemory<T_MemberType_> T_VectorMemberName_");
Emit("        {");
Emit("            get");
Emit("            {");
Emit("                var sourceSpan = _readonlyBlock.Slice(T_FieldOffset_, T_FieldLength_ * T_ArrayLength_).Span;");
                if(member.FieldLength == 1) {
Emit("                return MemoryMarshal.Cast<byte, T_MemberType_>(sourceSpan).ToArray(); // todo alloc!");
                } else {
Emit("                if (BitConverter.IsLittleEndian != T_IsBigEndian_)");
Emit("                {");
Emit("                    // endian match");
Emit("                    return MemoryMarshal.Cast<byte, T_MemberType_>(sourceSpan).ToArray(); // todo alloc!");
Emit("                }");
Emit("                else");
Emit("                {");
Emit("                    // endian mismatch - decode each element");
Emit("                    var target = new T_MemberType_[T_ArrayLength_]; // todo alloc!");
Emit("                    Span<T_MemberType_> targetSpan = target.AsSpan();");
Emit("                    for (int i = 0; i < T_ArrayLength_; i++)");
Emit("                    {");
Emit("                        var elementSpan = sourceSpan.Slice(T_FieldLength_ * i, T_FieldLength_);");
Emit("                        targetSpan[i] = Codec_T_MemberType__T_MemberBELE_.ReadFromSpan(elementSpan);");
Emit("                    }");
Emit("                    return target;");
Emit("                }");
                }
Emit("            }");
Emit("");
Emit("            set");
Emit("            {");
Emit("                ThrowIfFrozen();");
Emit("                var targetSpan = _writableBlock.Slice(T_FieldOffset_, T_FieldLength_ * T_ArrayLength_).Span;");
Emit("                targetSpan.Clear();");
                if(member.FieldLength == 1) {
Emit("                value.Span.CopyTo(MemoryMarshal.Cast<byte, T_MemberType_>(targetSpan));");
                } else {
Emit("                if (BitConverter.IsLittleEndian != T_IsBigEndian_)");
Emit("                {");
Emit("                    // endian match");
Emit("                    value.Span.CopyTo(MemoryMarshal.Cast<byte, T_MemberType_>(targetSpan));");
Emit("                }");
Emit("                else");
Emit("                {");
Emit("                    // endian mismatch - encode each element");
Emit("                    var sourceSpan = value.Span;");
Emit("                    for (int i = 0; i < sourceSpan.Length; i++)");
Emit("                    {");
Emit("                        var elementSpan = targetSpan.Slice(T_FieldLength_ * i, T_FieldLength_);");
Emit("                        Codec_T_MemberType__T_MemberBELE_.WriteToSpan(elementSpan, sourceSpan[i]);");
Emit("                    }");
Emit("                }");
                }
Emit("            }");
Emit("        }");
Emit("");
        } else if (member.IsEntity) {
        if (member.IsNullable) {
Emit("        private T_MemberTypeNameSpace_.MemBlocks.T_MemberTypeName_? _T_NullableEntityMemberName_;");
Emit("        public T_MemberTypeNameSpace_.MemBlocks.T_MemberTypeName_? T_NullableEntityMemberName_");
Emit("        {");
Emit("            get => _T_NullableEntityMemberName_;");
Emit("            set");
Emit("            {");
Emit("                ThrowIfFrozen();");
Emit("                _T_NullableEntityMemberName_ = value;");
Emit("            }");
Emit("        }");
Emit("        T_MemberTypeNameSpace_.IT_MemberTypeName_? IT_EntityName_.T_NullableEntityMemberName_");
Emit("        {");
Emit("            get => _T_NullableEntityMemberName_;");
Emit("            set");
Emit("            {");
Emit("                ThrowIfFrozen();");
Emit("                _T_NullableEntityMemberName_ = value is null ? null : T_MemberTypeNameSpace_.MemBlocks.T_MemberTypeName_.CreateFrom(value);");
Emit("            }");
Emit("        }");
        } else {
Emit("        private T_MemberTypeNameSpace_.MemBlocks.T_MemberTypeName_ _T_RequiredEntityMemberName_ = T_MemberTypeNameSpace_.MemBlocks.T_MemberTypeName_.Empty;");
Emit("        public T_MemberTypeNameSpace_.MemBlocks.T_MemberTypeName_ T_RequiredEntityMemberName_");
Emit("        {");
Emit("            get => _T_RequiredEntityMemberName_;");
Emit("            set");
Emit("            {");
Emit("                ThrowIfFrozen();");
Emit("                _T_RequiredEntityMemberName_ = value;");
Emit("            }");
Emit("        }");
Emit("        T_MemberTypeNameSpace_.IT_MemberTypeName_ IT_EntityName_.T_RequiredEntityMemberName_");
Emit("        {");
Emit("            get => _T_RequiredEntityMemberName_;");
Emit("            set");
Emit("            {");
Emit("                ThrowIfFrozen();");
Emit("                _T_RequiredEntityMemberName_ = T_MemberTypeNameSpace_.MemBlocks.T_MemberTypeName_.CreateFrom(value);");
Emit("            }");
Emit("        }");
        }
        } else {
Emit("        public T_MemberType_ T_ScalarMemberName_");
Emit("        {");
Emit("            get");
Emit("            {");
Emit("                return Codec_T_MemberType__T_MemberBELE_.ReadFromSpan(_readonlyBlock.Slice(T_FieldOffset_, T_FieldLength_).Span);");
Emit("            }");
Emit("");
Emit("            set");
Emit("            {");
Emit("                ThrowIfFrozen();");
Emit("                Codec_T_MemberType__T_MemberBELE_.WriteToSpan(_writableBlock.Slice(T_FieldOffset_, T_FieldLength_).Span, value);");
Emit("            }");
Emit("        }");
Emit("");
        }
        }
Emit("");
Emit("        public bool Equals(T_EntityName_? other)");
Emit("        {");
Emit("            if (ReferenceEquals(this, other)) return true;");
Emit("            if (other is null) return false;");
Emit("            if (!base.Equals(other)) return false;");
Emit("            if (!_readonlyBlock.Span.SequenceEqual(other._readonlyBlock.Span)) return false;");
Emit("            return true;");
Emit("        }");
Emit("");
Emit("        public override bool Equals(object? obj) => obj is T_EntityName_ other && Equals(other);");
Emit("        public static bool operator ==(T_EntityName_? left, T_EntityName_? right) => left is not null ? left.Equals(right) : (right is null);");
Emit("        public static bool operator !=(T_EntityName_? left, T_EntityName_? right) => left is not null ? !left.Equals(right) : (right is not null);");
Emit("");
Emit("        private int CalcHashCode()");
Emit("        {");
Emit("            HashCode result = new HashCode();");
Emit("            result.Add(base.GetHashCode());");
Emit("#if NET8_0_OR_GREATER");
Emit("            result.AddBytes(_readonlyBlock.Span);");
Emit("#else");
Emit("            var byteSpan = _readonlyBlock.Span;");
Emit("            result.Add(byteSpan.Length);");
Emit("            for (int i = 0; i < byteSpan.Length; i++)");
Emit("            {");
Emit("                result.Add(byteSpan[i]);");
Emit("            }");
Emit("#endif");
Emit("            return result.ToHashCode();");
Emit("        }");
Emit("");
Emit("        private int? _hashCode;");
Emit("        public override int GetHashCode()");
Emit("        {");
Emit("            if (_hashCode.HasValue) return _hashCode.Value;");
Emit("            if (!IsFrozen) return CalcHashCode();");
Emit("            _hashCode = CalcHashCode();");
Emit("            return _hashCode.Value;");
Emit("        }");
Emit("");
Emit("    }");
Emit("}");
    }
}
