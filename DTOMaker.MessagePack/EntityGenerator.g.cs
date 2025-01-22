using System;
using System.Linq;
using DTOMaker.Gentime;
namespace DTOMaker.MessagePack;
#pragma warning disable CS0162 // Unreachable code detected
public sealed class EntityGenerator : EntityGeneratorBase
{
    public EntityGenerator(ILanguage language) : base(language) { }
    protected override void OnGenerate(ModelScopeEntity entity)
    {
Emit("// <auto-generated>");
Emit("// This file was generated by DTOMaker.MessagePack.");
Emit("// NuGet: https://www.nuget.org/packages/DTOMaker.MessagePack");
Emit("// Warning: Changes made to this file will be lost if re-generated.");
Emit("// </auto-generated>");
if(false) {
Emit("#pragma warning disable CS0618 // Type or member is obsolete");
Emit("#pragma warning disable CS0162 // Unreachable code detected");
}
Emit("#pragma warning disable CS0109 // Member does not hide an inherited member; new keyword is not required");
Emit("#nullable enable");
Emit("using DTOMaker.Runtime;");
Emit("using DTOMaker.Runtime.MessagePack;");
Emit("using MessagePack;");
Emit("using System;");
Emit("");
if (false) {
Emit("using T_MemberType_ = System.Int32;");
Emit("namespace T_MemberTypeNameSpace_");
Emit("{");
Emit("    public interface IT_MemberTypeName_ { }");
Emit("}");
Emit("namespace T_MemberTypeNameSpace_.MessagePack");
Emit("{");
Emit("    public class T_MemberTypeName_ : EntityBase, IT_MemberTypeName_");
Emit("    {");
Emit("        private static readonly T_MemberTypeName_ _empty = new T_MemberTypeName_();");
Emit("        public static T_MemberTypeName_ Empty => _empty;");
Emit("        public T_MemberTypeName_() { }");
Emit("        public T_MemberTypeName_(IT_MemberTypeName_ source) { }");
Emit("        protected override IFreezable OnPartCopy() => throw new NotImplementedException();");
Emit("        protected override string OnGetEntityId() => \"T_MemberTypeName_\";");
Emit("    }");
Emit("}");
Emit("namespace T_BaseNameSpace_.MessagePack");
Emit("{");
Emit("    public interface IT_BaseName_ { }");
Emit("    [MessagePackObject]");
Emit("    [Union(T_NameSpace_.MessagePack.T_EntityName_.EntityKey, typeof(T_NameSpace_.MessagePack.T_EntityName_))]");
Emit("    public abstract class T_BaseName_ : EntityBase, IT_BaseName_, IEquatable<T_BaseName_>");
Emit("    {");
Emit("        public new const int EntityKey = 1;");
Emit("");
Emit("        public T_BaseName_() { }");
Emit("        public T_BaseName_(IT_BaseName_ source) : base(source) { }");
Emit("");
Emit("        protected override void OnFreeze() => base.OnFreeze();");
Emit("        protected override IFreezable OnPartCopy() => throw new NotImplementedException();");
Emit("");
Emit("        [Key(1)] public T_MemberType_ BaseField1 { get; set; }");
Emit("");
Emit("        public bool Equals(T_BaseName_? other)");
Emit("        {");
Emit("            if (ReferenceEquals(this, other)) return true;");
Emit("            if (other is null) return false;");
Emit("            if (!base.Equals(other)) return false;");
Emit("            return true;");
Emit("        }");
Emit("        public override bool Equals(object? obj) => obj is T_BaseName_ other && Equals(other);");
Emit("        public override int GetHashCode() => base.GetHashCode();");
Emit("    }");
Emit("}");
Emit("namespace T_NameSpace_");
Emit("{");
Emit("    public interface IT_EntityName_ : T_BaseNameSpace_.MessagePack.IT_BaseName_");
Emit("    {");
Emit("        T_MemberType_? T_NullableScalarMemberName_ { get; set; }");
Emit("        T_MemberType_ T_RequiredScalarMemberName_ { get; set; }");
Emit("        ReadOnlyMemory<T_MemberType_> T_VectorMemberName_ { get; set; }");
Emit("        T_MemberTypeNameSpace_.IT_MemberTypeName_? T_NullableEntityMemberName_ { get; set; }");
Emit("        T_MemberTypeNameSpace_.IT_MemberTypeName_ T_RequiredEntityMemberName_ { get; set; }");
Emit("    }");
Emit("}");
}
Emit("namespace T_NameSpace_.MessagePack");
Emit("{");
Emit("    [MessagePackObject]");
    foreach (var derived in entity.DerivedEntities) {
    using var _ = NewScope(derived);
    if (derived.DerivedEntityCount == 0) {
Emit("    [Union(T_EntityName_.EntityKey, typeof(T_EntityName_))]");
    }
    }
    if (entity.DerivedEntityCount > 0) {
Emit("    public abstract partial class T_EntityName2_ { }");
    }
Emit("    public partial class T_EntityName_ : T_BaseNameSpace_.MessagePack.T_BaseName_, IT_EntityName_, IEquatable<T_EntityName_>");
Emit("    {");
Emit("        // Derived entities: T_DerivedEntityCount_");
        foreach (var derived in entity.DerivedEntities) {
        using var _ = NewScope(derived);
Emit("        // - T_EntityName_");
        }
        if (false) {
Emit("        private const string T_MemberObsoleteMessage_ = null;");
Emit("        private const bool T_MemberObsoleteIsError_ = false;");
Emit("        private const int T_EntityKey_ = 2;");
Emit("        private const int T_MemberKeyOffset_ = 10;");
Emit("        private const int T_NullableScalarMemberKey_ = T_MemberKeyOffset_ + 1;");
Emit("        private const int T_RequiredScalarMemberKey_ = T_MemberKeyOffset_ + 2;");
Emit("        private const int T_VectorMemberKey_ = T_MemberKeyOffset_ + 3;");
Emit("        private const int T_NullableEntityMemberKey_ = T_MemberKeyOffset_ + 4;");
Emit("        private const int T_RequiredEntityMemberKey_ = T_MemberKeyOffset_ + 5;");
Emit("        private const int T_MemberDefaultValue_ = 0;");
        }
Emit("");
Emit("        public new const int EntityKey = T_EntityKey_;");
Emit("");
Emit("        public new static T_EntityName_ CreateFrom(T_NameSpace_.IT_EntityName_ source)");
Emit("        {");
Emit("            return source switch");
Emit("            {");
                foreach(var derived in entity.DerivedEntities.OrderByDescending(e => e.ClassHeight)) {
                using var _ = NewScope(derived);
Emit("                T_NameSpace_.IT_EntityName_ source2 => new T_NameSpace_.MessagePack.T_EntityName_(source2),");
                }
Emit("                _ => throw new ArgumentException($\"Unexpected type: {source.GetType().Name}\", nameof(source))");
Emit("            };");
Emit("        }");
Emit("");
Emit("        public new static T_EntityName_ CreateFrom(int entityKey, ReadOnlyMemory<byte> buffer)");
Emit("        {");
Emit("            return entityKey switch");
Emit("            {");
                foreach (var derived in entity.DerivedEntities) {
                using var _ = NewScope(derived);
                if (derived.DerivedEntityCount == 0) {
Emit("                T_NameSpace_.MessagePack.T_EntityName_.EntityKey => MessagePackSerializer.Deserialize<T_NameSpace_.MessagePack.T_EntityName_>(buffer, out var _),");
                }
                }
Emit("                _ => throw new ArgumentOutOfRangeException(nameof(entityKey), entityKey, null)");
Emit("            };");
Emit("        }");
Emit("");
Emit("        protected override string OnGetEntityId() => EntityKey.ToString();");
Emit("");
Emit("        protected override void OnFreeze()");
Emit("        {");
Emit("            base.OnFreeze();");
            foreach (var member in entity.Members) {
            using var _ = NewScope(member);
            if (member.IsEntity) {
            if (member.IsNullable) {
Emit("            _T_NullableEntityMemberName_?.Freeze();");
            } else {
Emit("            _T_RequiredEntityMemberName_.Freeze();");
            }
            }
            }
Emit("        }");
Emit("");
        if (entity.DerivedEntityCount == 0) {
Emit("        protected override IFreezable OnPartCopy() => new T_EntityName_(this);");
Emit("");
        }
Emit("        public T_EntityName_() { }");
Emit("        public T_EntityName_(IT_EntityName_ source) : base(source)");
Emit("        {");
            foreach (var member in entity.Members) {
            using var _ = NewScope(member);
            if (member.IsVector) {
Emit("            _T_VectorMemberName_ = source.T_VectorMemberName_;");
            } else if (member.IsEntity) {
            if (member.IsNullable) {
Emit("            _T_NullableEntityMemberName_ = source.T_NullableEntityMemberName_ is null ? null : new T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_(source.T_NullableEntityMemberName_);");
            } else {
Emit("            _T_RequiredEntityMemberName_ = new T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_(source.T_RequiredEntityMemberName_);");
            }
            } else {
            if (member.IsNullable) {
Emit("            _T_NullableScalarMemberName_ = source.T_NullableScalarMemberName_;");
            } else {
Emit("            _T_RequiredScalarMemberName_ = source.T_RequiredScalarMemberName_;");
            }
            }
            }
Emit("        }");
Emit("");
        foreach (var member in entity.Members) {
        using var _ = NewScope(member);
        if (member.IsVector) {
Emit("        [IgnoreMember]");
Emit("        private ReadOnlyMemory<T_MemberType_> _T_VectorMemberName_;");
        if (member.IsObsolete) {
Emit("        [Obsolete(\"T_MemberObsoleteMessage_\", T_MemberObsoleteIsError_)]");
        }
Emit("        [Key(T_VectorMemberKey_)]");
Emit("        public ReadOnlyMemory<T_MemberType_> T_VectorMemberName_");
Emit("        {");
Emit("            get => _T_VectorMemberName_;");
Emit("            set => _T_VectorMemberName_ = IfNotFrozen(ref value);");
Emit("        }");
        } else if (member.IsEntity) {
        if (member.IsNullable) {
Emit("        [IgnoreMember]");
Emit("        private T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_? _T_NullableEntityMemberName_;");
Emit("        [Key(T_NullableEntityMemberKey_)]");
Emit("        public T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_? T_NullableEntityMemberName_");
Emit("        {");
Emit("            get => _T_NullableEntityMemberName_;");
Emit("            set => _T_NullableEntityMemberName_ = IfNotFrozen(ref value);");
Emit("        }");
Emit("        T_MemberTypeNameSpace_.IT_MemberTypeName_? IT_EntityName_.T_NullableEntityMemberName_");
Emit("        {");
Emit("            get => _T_NullableEntityMemberName_;");
Emit("            set");
Emit("            {");
Emit("                ThrowIfFrozen();");
Emit("                _T_NullableEntityMemberName_ = value is null ? null : new T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_(value);");
Emit("            }");
Emit("        }");
        } else {
Emit("        [IgnoreMember]");
Emit("        private T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_ _T_RequiredEntityMemberName_ = T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_.Empty;");
Emit("        [Key(T_RequiredEntityMemberKey_)]");
Emit("        public T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_ T_RequiredEntityMemberName_");
Emit("        {");
Emit("            get => _T_RequiredEntityMemberName_;");
Emit("            set => _T_RequiredEntityMemberName_ = IfNotFrozen(ref value);");
Emit("        }");
Emit("        T_MemberTypeNameSpace_.IT_MemberTypeName_ IT_EntityName_.T_RequiredEntityMemberName_");
Emit("        {");
Emit("            get => _T_RequiredEntityMemberName_;");
Emit("            set");
Emit("            {");
Emit("                ThrowIfFrozen();");
Emit("                _T_RequiredEntityMemberName_ = new T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_(value);");
Emit("            }");
Emit("        }");
        }
        } else {
        if (member.IsNullable) {
Emit("        [IgnoreMember]");
Emit("        private T_MemberType_? _T_NullableScalarMemberName_;");
        } else {
Emit("        [IgnoreMember]");
Emit("        private T_MemberType_ _T_RequiredScalarMemberName_ = T_MemberDefaultValue_;");
        }
        if (member.IsObsolete) {
Emit("        [Obsolete(\"T_MemberObsoleteMessage_\", T_MemberObsoleteIsError_)]");
        }
        if (member.IsNullable) {
Emit("        [Key(T_NullableScalarMemberKey_)]");
Emit("        public T_MemberType_? T_NullableScalarMemberName_");
Emit("        {");
Emit("            get => _T_NullableScalarMemberName_;");
Emit("            set => _T_NullableScalarMemberName_ = IfNotFrozen(ref value);");
Emit("        }");
        } else {
Emit("        [Key(T_RequiredScalarMemberKey_)]");
Emit("        public T_MemberType_ T_RequiredScalarMemberName_");
Emit("        {");
Emit("            get => _T_RequiredScalarMemberName_;");
Emit("            set => _T_RequiredScalarMemberName_ = IfNotFrozen(ref value);");
Emit("        }");
        }
        }
Emit("");
        }
Emit("");
Emit("        public bool Equals(T_EntityName_? other)");
Emit("        {");
Emit("            if (ReferenceEquals(this, other)) return true;");
Emit("            if (other is null) return false;");
Emit("            if (!base.Equals(other)) return false;");
            foreach (var member in entity.Members) {
            using var _ = NewScope(member);
            if (member.IsVector) {
Emit("            if (!_T_VectorMemberName_.Span.SequenceEqual(other.T_VectorMemberName_.Span)) return false;");
            } else {
            if (member.IsNullable) {
Emit("            if (_T_NullableScalarMemberName_ != other.T_NullableScalarMemberName_) return false;");
            } else {
Emit("            if (_T_RequiredScalarMemberName_ != other.T_RequiredScalarMemberName_) return false;");
            }
            }
            }
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
            foreach (var member in entity.Members) {
            using var _ = NewScope(member);
            if (member.IsVector) {
Emit("            result.Add(_T_VectorMemberName_.Length);");
Emit("            for (int i = 0; i < _T_VectorMemberName_.Length; i++)");
Emit("            {");
Emit("                result.Add(_T_VectorMemberName_.Span[i]);");
Emit("            }");
            } else {
            if (member.IsNullable) {
Emit("            result.Add(_T_NullableScalarMemberName_);");
            } else {
Emit("            result.Add(_T_RequiredScalarMemberName_);");
            }
            }
            }
Emit("            return result.ToHashCode();");
Emit("        }");
Emit("");
Emit("        [IgnoreMember]");
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
