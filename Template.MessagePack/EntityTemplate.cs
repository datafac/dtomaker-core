﻿// <auto-generated>
// This file was generated by DTOMaker.MessagePack.
// NuGet: https://www.nuget.org/packages/DTOMaker.MessagePack
// Warning: Changes made to this file will be lost if re-generated.
// </auto-generated>
//##if(false) {
#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS0162 // Unreachable code detected
//##}
#pragma warning disable CS0109 // Member does not hide an inherited member; new keyword is not required
#nullable enable
using DTOMaker.Runtime;
using DTOMaker.Runtime.MessagePack;
using MessagePack;
using System;

//##if (false) {
using T_MemberType_ = System.Int32;
namespace T_MemberTypeNameSpace_
{
    public interface IT_MemberTypeName_ { }
}
namespace T_MemberTypeNameSpace_.MessagePack
{
    public class T_MemberTypeName_ : EntityBase, IT_MemberTypeName_
    {
        private static readonly T_MemberTypeName_ _empty = new T_MemberTypeName_();
        public static T_MemberTypeName_ Empty => _empty;
        public static T_MemberTypeName_ CreateFrom(IT_MemberTypeName_ source) => throw new NotImplementedException();
        public T_MemberTypeName_() { }
        public T_MemberTypeName_(IT_MemberTypeName_ source) { }
        protected override IFreezable OnPartCopy() => throw new NotImplementedException();
        protected override string OnGetEntityId() => "T_MemberTypeName_";
    }
}
namespace T_BaseNameSpace_.MessagePack
{
    public interface IT_BaseName_ { }
    [MessagePackObject]
    [Union(T_NameSpace_.MessagePack.T_ConcreteEntityName_.EntityKey, typeof(T_NameSpace_.MessagePack.T_ConcreteEntityName_))]
    public abstract class T_BaseName_ : EntityBase, IT_BaseName_, IEquatable<T_BaseName_>
    {
        public new const int EntityKey = 1;

        public T_BaseName_() { }
        public T_BaseName_(IT_BaseName_ source) : base(source) { }

        protected override void OnFreeze() => base.OnFreeze();
        protected override IFreezable OnPartCopy() => throw new NotImplementedException();

        [Key(1)] public T_MemberType_ BaseField1 { get; set; }

        public bool Equals(T_BaseName_? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            if (!base.Equals(other)) return false;
            return true;
        }
        public override bool Equals(object? obj) => obj is T_BaseName_ other && Equals(other);
        public override int GetHashCode() => base.GetHashCode();
    }
}
namespace T_NameSpace_
{
    public interface IT_EntityName_ : T_BaseNameSpace_.MessagePack.IT_BaseName_
    {
        T_MemberType_? T_NullableScalarMemberName_ { get; set; }
        T_MemberType_ T_RequiredScalarMemberName_ { get; set; }
        ReadOnlyMemory<T_MemberType_> T_VectorMemberName_ { get; set; }
        T_MemberTypeNameSpace_.IT_MemberTypeName_? T_NullableEntityMemberName_ { get; set; }
        T_MemberTypeNameSpace_.IT_MemberTypeName_ T_RequiredEntityMemberName_ { get; set; }
    }
}
//##}
namespace T_NameSpace_.MessagePack
{
    [MessagePackObject]
    //##foreach (var derived in entity.DerivedEntities) {
    //##using var _ = NewScope(derived);
    //##if (derived.DerivedEntityCount == 0) {
    [Union(T_ConcreteEntityName_.EntityKey, typeof(T_ConcreteEntityName_))]
    //##}
    //##}
    //##if (entity.DerivedEntityCount > 0) {
    public abstract partial class T_AbstractEntityName_ : T_BaseNameSpace_.MessagePack.T_BaseName_, IT_EntityName_, IEquatable<T_AbstractEntityName_>
    {
        // Derived entities: T_DerivedEntityCount_
        //##foreach (var derived in entity.DerivedEntities) {
        //##using var _ = NewScope(derived);
        //##if (derived.DerivedEntityCount == 0) {
        // - T_EntityName_
        //##} else {
        // - T_EntityName_ (abstract)
        //##}
        //##}
        //##if (false) {
        private const string T_MemberObsoleteMessage_ = null;
        private const bool T_MemberObsoleteIsError_ = false;
        private const int T_EntityKey_ = 2;
        private const int T_MemberKeyOffset_ = 10;
        private const int T_NullableScalarMemberKey_ = T_MemberKeyOffset_ + 1;
        private const int T_RequiredScalarMemberKey_ = T_MemberKeyOffset_ + 2;
        private const int T_VectorMemberKey_ = T_MemberKeyOffset_ + 3;
        private const int T_NullableEntityMemberKey_ = T_MemberKeyOffset_ + 4;
        private const int T_RequiredEntityMemberKey_ = T_MemberKeyOffset_ + 5;
        private const int T_MemberDefaultValue_ = 0;
        //##}

        public new const int EntityKey = T_EntityKey_;

        public new static T_ConcreteEntityName_ CreateFrom(T_ConcreteEntityName_ source)
        {
            if (source.IsFrozen) return source;
            return source switch
            {
                //##foreach(var derived in entity.DerivedEntities.OrderByDescending(e => e.ClassHeight)) {
                //##using var _ = NewScope(derived);
                //##if (derived.DerivedEntityCount == 0) {
                T_NameSpace_.MessagePack.T_ConcreteEntityName_ source2 => new T_NameSpace_.MessagePack.T_ConcreteEntityName_(source2),
                //##}
                //##}
                _ => throw new ArgumentException($"Unexpected type: {source.GetType().Name}", nameof(source))
            };
        }

        public new static T_ConcreteEntityName_ CreateFrom(T_NameSpace_.IT_EntityName_ source)
        {
            if (source is T_ConcreteEntityName_ concrete && concrete.IsFrozen) return concrete;
            return source switch
            {
                //##foreach(var derived in entity.DerivedEntities.OrderByDescending(e => e.ClassHeight)) {
                //##using var _ = NewScope(derived);
                //##if (derived.DerivedEntityCount == 0) {
                T_NameSpace_.IT_EntityName_ source2 => new T_NameSpace_.MessagePack.T_ConcreteEntityName_(source2),
                //##}
                //##}
                _ => throw new ArgumentException($"Unexpected type: {source.GetType().Name}", nameof(source))
            };
        }

        public new static T_ConcreteEntityName_ CreateFrom(int entityKey, ReadOnlyMemory<byte> buffer)
        {
            return entityKey switch
            {
                //##foreach (var derived in entity.DerivedEntities) {
                //##using var _ = NewScope(derived);
                //##if (derived.DerivedEntityCount == 0) {
                T_NameSpace_.MessagePack.T_ConcreteEntityName_.EntityKey => MessagePackSerializer.Deserialize<T_NameSpace_.MessagePack.T_ConcreteEntityName_>(buffer, out var _),
                //##}
                //##}
                _ => throw new ArgumentOutOfRangeException(nameof(entityKey), entityKey, null)
            };
        }

        protected override string OnGetEntityId() => EntityKey.ToString();

        protected override void OnFreeze()
        {
            base.OnFreeze();
            //##foreach (var member in entity.Members) {
            //##using var _ = NewScope(member);
            //##if (member.IsEntity) {
            //##if (member.IsNullable) {
            _T_NullableEntityMemberName_?.Freeze();
            //##} else {
            _T_RequiredEntityMemberName_.Freeze();
            //##}
            //##}
            //##}
        }

        protected T_AbstractEntityName_() { }

        protected T_AbstractEntityName_(T_AbstractEntityName_ source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            //##foreach (var member in entity.Members) {
            //##using var _ = NewScope(member);
            //##switch(member.Kind) {
            //##case MemberKind.Scalar:
            //##if (member.IsNullable) {
            _T_NullableScalarMemberName_ = source._T_NullableScalarMemberName_;
            //##} else {
            _T_RequiredScalarMemberName_ = source._T_RequiredScalarMemberName_;
            //##}
            //##break;
            //##case MemberKind.Vector:
            _T_VectorMemberName_ = source._T_VectorMemberName_;
            //##break;
            //##case MemberKind.Entity:
            //##if (member.IsNullable) {
            _T_NullableEntityMemberName_ = source._T_NullableEntityMemberName_ is null ? null : T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_.CreateFrom(source._T_NullableEntityMemberName_);
            //##} else {
            _T_RequiredEntityMemberName_ = T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_.CreateFrom(source._T_RequiredEntityMemberName_);
            //##}
            //##break;
            //##default:
            //##Emit($"#error Implementation for MemberKind '{member.Kind}' is missing");
            //##break;
            //##} // switch
            //##}
        }

        public T_AbstractEntityName_(IT_EntityName_ source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            //##foreach (var member in entity.Members) {
            //##using var _ = NewScope(member);
            //##switch(member.Kind) {
            //##case MemberKind.Scalar:
            //##if (member.IsNullable) {
            _T_NullableScalarMemberName_ = source.T_NullableScalarMemberName_;
            //##} else {
            _T_RequiredScalarMemberName_ = source.T_RequiredScalarMemberName_;
            //##}
            //##break;
            //##case MemberKind.Vector:
            _T_VectorMemberName_ = source.T_VectorMemberName_;
            //##break;
            //##case MemberKind.Entity:
            //##if (member.IsNullable) {
            _T_NullableEntityMemberName_ = source.T_NullableEntityMemberName_ is null ? null : T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_.CreateFrom(source.T_NullableEntityMemberName_);
            //##} else {
            _T_RequiredEntityMemberName_ = T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_.CreateFrom(source.T_RequiredEntityMemberName_);
            //##}
            //##break;
            //##default:
            //##Emit($"#error Implementation for MemberKind '{member.Kind}' is missing");
            //##break;
            //##} // switch
            //##}
        }

        //##foreach (var member in entity.Members) {
        //##using var _ = NewScope(member);
        //##switch(member.Kind) {
        //##case MemberKind.Scalar:
        //##if (member.IsNullable) {
        [IgnoreMember]
        private T_MemberType_? _T_NullableScalarMemberName_;
        //##if (member.IsObsolete) {
        [Obsolete("T_MemberObsoleteMessage_", T_MemberObsoleteIsError_)]
        //##}
        [Key(T_NullableScalarMemberKey_)]
        public T_MemberType_? T_NullableScalarMemberName_
        {
            get => _T_NullableScalarMemberName_;
            set => _T_NullableScalarMemberName_ = IfNotFrozen(value);
        }
        //##} else {
        [IgnoreMember]
        private T_MemberType_ _T_RequiredScalarMemberName_ = T_MemberDefaultValue_;
        //##if (member.IsObsolete) {
        [Obsolete("T_MemberObsoleteMessage_", T_MemberObsoleteIsError_)]
        //##}
        [Key(T_RequiredScalarMemberKey_)]
        public T_MemberType_ T_RequiredScalarMemberName_
        {
            get => _T_RequiredScalarMemberName_;
            set => _T_RequiredScalarMemberName_ = IfNotFrozen(value);
        }
        //##}
        //##break;
        //##case MemberKind.Vector:
        [IgnoreMember]
        private ReadOnlyMemory<T_MemberType_> _T_VectorMemberName_;
        //##if (member.IsObsolete) {
        [Obsolete("T_MemberObsoleteMessage_", T_MemberObsoleteIsError_)]
        //##}
        [Key(T_VectorMemberKey_)]
        public ReadOnlyMemory<T_MemberType_> T_VectorMemberName_
        {
            get => _T_VectorMemberName_;
            set => _T_VectorMemberName_ = IfNotFrozen(value);
        }
        //##break;
        //##case MemberKind.Entity:
        //##if (member.IsNullable) {
        [IgnoreMember]
        private T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_? _T_NullableEntityMemberName_;
        [Key(T_NullableEntityMemberKey_)]
        public T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_? T_NullableEntityMemberName_
        {
            get => _T_NullableEntityMemberName_;
            set => _T_NullableEntityMemberName_ = IfNotFrozen(value);
        }
        T_MemberTypeNameSpace_.IT_MemberTypeName_? IT_EntityName_.T_NullableEntityMemberName_
        {
            get => _T_NullableEntityMemberName_;
            set
            {
                ThrowIfFrozen();
                _T_NullableEntityMemberName_ = value is null ? null : T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_.CreateFrom(value);
            }
        }
        //##} else {
        [IgnoreMember]
        private T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_ _T_RequiredEntityMemberName_ = T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_.Empty;
        [Key(T_RequiredEntityMemberKey_)]
        public T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_ T_RequiredEntityMemberName_
        {
            get => _T_RequiredEntityMemberName_;
            set => _T_RequiredEntityMemberName_ = IfNotFrozen(value);
        }
        T_MemberTypeNameSpace_.IT_MemberTypeName_ IT_EntityName_.T_RequiredEntityMemberName_
        {
            get => _T_RequiredEntityMemberName_;
            set
            {
                ThrowIfFrozen();
                _T_RequiredEntityMemberName_ = T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_.CreateFrom(value);
            }
        }
        //##}
        //##break;
        //##default:
        //##Emit($"#error Implementation for MemberKind '{member.Kind}' is missing");
        //##break;
        //##} // switch

        //##}

        public bool Equals(T_AbstractEntityName_? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            if (!base.Equals(other)) return false;
            //##foreach (var member in entity.Members) {
            //##using var _ = NewScope(member);
            //##switch(member.Kind) {
            //##case MemberKind.Scalar:
            //##if (member.IsNullable) {
            if (_T_NullableScalarMemberName_ != other.T_NullableScalarMemberName_) return false;
            //##} else {
            if (_T_RequiredScalarMemberName_ != other.T_RequiredScalarMemberName_) return false;
            //##}
            //##break;
            //##case MemberKind.Vector:
            if (!_T_VectorMemberName_.Span.SequenceEqual(other.T_VectorMemberName_.Span)) return false;
            //##break;
            //##case MemberKind.Entity:
            //##if (member.IsNullable) {
            if (_T_NullableEntityMemberName_ != other.T_NullableEntityMemberName_) return false;
            //##} else {
            if (_T_RequiredEntityMemberName_ != other.T_RequiredEntityMemberName_) return false;
            //##}
            //##break;
            //##default:
            //##Emit($"#error Implementation for MemberKind '{member.Kind}' is missing");
            //##break;
            //##} // switch
            //##}
            return true;
        }

        public override bool Equals(object? obj) => obj is T_AbstractEntityName_ other && Equals(other);
        public static bool operator ==(T_AbstractEntityName_? left, T_AbstractEntityName_? right) => left is not null ? left.Equals(right) : (right is null);
        public static bool operator !=(T_AbstractEntityName_? left, T_AbstractEntityName_? right) => left is not null ? !left.Equals(right) : (right is not null);

        private int CalcHashCode()
        {
            HashCode result = new HashCode();
            result.Add(base.GetHashCode());
            //##foreach (var member in entity.Members) {
            //##using var _ = NewScope(member);
            //##switch(member.Kind) {
            //##case MemberKind.Scalar:
            //##if (member.IsNullable) {
            result.Add(_T_NullableScalarMemberName_);
            //##} else {
            result.Add(_T_RequiredScalarMemberName_);
            //##}
            //##break;
            //##case MemberKind.Vector:
            result.Add(_T_VectorMemberName_.Length);
            for (int i = 0; i < _T_VectorMemberName_.Length; i++)
            {
                result.Add(_T_VectorMemberName_.Span[i]);
            }
            //##break;
            //##case MemberKind.Entity:
            //##if (member.IsNullable) {
            result.Add(_T_NullableEntityMemberName_?.GetHashCode() ?? 0);
            //##} else {
            result.Add(_T_RequiredEntityMemberName_.GetHashCode());
            //##}
            //##break;
            //##default:
            //##Emit($"#error Implementation for MemberKind '{member.Kind}' is missing");
            //##break;
            //##} // switch
            //##}
            return result.ToHashCode();
        }

        [IgnoreMember]
        private int? _hashCode;
        public override int GetHashCode()
        {
            if (_hashCode.HasValue) return _hashCode.Value;
            if (!IsFrozen) return CalcHashCode();
            _hashCode = CalcHashCode();
            return _hashCode.Value;
        }

    }
    //##} else {
    public sealed partial class T_ConcreteEntityName_ : T_BaseNameSpace_.MessagePack.T_BaseName_, IT_EntityName_, IEquatable<T_ConcreteEntityName_>
    {
        //##if (false) {
        private const string T_MemberObsoleteMessage_ = null;
        private const bool T_MemberObsoleteIsError_ = false;
        private const int T_EntityKey_ = 2;
        private const int T_MemberKeyOffset_ = 10;
        private const int T_NullableScalarMemberKey_ = T_MemberKeyOffset_ + 1;
        private const int T_RequiredScalarMemberKey_ = T_MemberKeyOffset_ + 2;
        private const int T_VectorMemberKey_ = T_MemberKeyOffset_ + 3;
        private const int T_NullableEntityMemberKey_ = T_MemberKeyOffset_ + 4;
        private const int T_RequiredEntityMemberKey_ = T_MemberKeyOffset_ + 5;
        private const int T_MemberDefaultValue_ = 0;
        //##}

        public new const int EntityKey = T_EntityKey_;

        private static T_ConcreteEntityName_ CreateEmpty()
        {
            var empty = new T_ConcreteEntityName_();
            empty.Freeze();
            return empty;
        }
        private static readonly T_ConcreteEntityName_ _empty = CreateEmpty();
        public static T_ConcreteEntityName_ Empty => _empty;

        public new static T_ConcreteEntityName_ CreateFrom(T_ConcreteEntityName_ source)
        {
            if (source.IsFrozen)
                return source;
            else
                return new T_ConcreteEntityName_(source);
        }

        public new static T_ConcreteEntityName_ CreateFrom(T_NameSpace_.IT_EntityName_ source)
        {
            if (source is T_ConcreteEntityName_ concrete && concrete.IsFrozen)
                return concrete;
            else
                return new T_ConcreteEntityName_(source);
        }

        public new static T_ConcreteEntityName_ CreateFrom(int entityKey, ReadOnlyMemory<byte> buffer)
        {
            if (entityKey == T_NameSpace_.MessagePack.T_ConcreteEntityName_.EntityKey)
                return MessagePackSerializer.Deserialize<T_NameSpace_.MessagePack.T_ConcreteEntityName_>(buffer, out var _);
            else
                throw new ArgumentOutOfRangeException(nameof(entityKey), entityKey, null);
        }

        protected override string OnGetEntityId() => EntityKey.ToString();

        protected override void OnFreeze()
        {
            base.OnFreeze();
            //##foreach (var member in entity.Members) {
            //##using var _ = NewScope(member);
            //##if (member.IsEntity) {
            //##if (member.IsNullable) {
            _T_NullableEntityMemberName_?.Freeze();
            //##} else {
            _T_RequiredEntityMemberName_.Freeze();
            //##}
            //##}
            //##}
        }

        protected override IFreezable OnPartCopy() => new T_ConcreteEntityName_(this);

        [SerializationConstructor]
        public T_ConcreteEntityName_() { }

        public T_ConcreteEntityName_(T_ConcreteEntityName_ source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            //##foreach (var member in entity.Members) {
            //##using var _ = NewScope(member);
            //##switch(member.Kind) {
            //##case MemberKind.Scalar:
            //##if (member.IsNullable) {
            _T_NullableScalarMemberName_ = source._T_NullableScalarMemberName_;
            //##} else {
            _T_RequiredScalarMemberName_ = source._T_RequiredScalarMemberName_;
            //##}
            //##break;
            //##case MemberKind.Vector:
            _T_VectorMemberName_ = source._T_VectorMemberName_;
            //##break;
            //##case MemberKind.Entity:
            //##if (member.IsNullable) {
            _T_NullableEntityMemberName_ = source._T_NullableEntityMemberName_ is null ? null : T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_.CreateFrom(source._T_NullableEntityMemberName_);
            //##} else {
            _T_RequiredEntityMemberName_ = T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_.CreateFrom(source._T_RequiredEntityMemberName_);
            //##}
            //##break;
            //##default:
            //##Emit($"#error Implementation for MemberKind '{member.Kind}' is missing");
            //##break;
            //##} // switch
            //##}
        }

        public T_ConcreteEntityName_(IT_EntityName_ source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            //##foreach (var member in entity.Members) {
            //##using var _ = NewScope(member);
            //##switch(member.Kind) {
            //##case MemberKind.Scalar:
            //##if (member.IsNullable) {
            _T_NullableScalarMemberName_ = source.T_NullableScalarMemberName_;
            //##} else {
            _T_RequiredScalarMemberName_ = source.T_RequiredScalarMemberName_;
            //##}
            //##break;
            //##case MemberKind.Vector:
            _T_VectorMemberName_ = source.T_VectorMemberName_;
            //##break;
            //##case MemberKind.Entity:
            //##if (member.IsNullable) {
            _T_NullableEntityMemberName_ = source.T_NullableEntityMemberName_ is null ? null : T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_.CreateFrom(source.T_NullableEntityMemberName_);
            //##} else {
            _T_RequiredEntityMemberName_ = T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_.CreateFrom(source.T_RequiredEntityMemberName_);
            //##}
            //##break;
            //##default:
            //##Emit($"#error Implementation for MemberKind '{member.Kind}' is missing");
            //##break;
            //##} // switch
            //##}
        }

        //##foreach (var member in entity.Members) {
        //##using var _ = NewScope(member);
        //##switch(member.Kind) {
        //##case MemberKind.Scalar:
        //##if (member.IsNullable) {
        [IgnoreMember]
        private T_MemberType_? _T_NullableScalarMemberName_;
        //##if (member.IsObsolete) {
        [Obsolete("T_MemberObsoleteMessage_", T_MemberObsoleteIsError_)]
        //##}
        [Key(T_NullableScalarMemberKey_)]
        public T_MemberType_? T_NullableScalarMemberName_
        {
            get => _T_NullableScalarMemberName_;
            set => _T_NullableScalarMemberName_ = IfNotFrozen(value);
        }
        //##} else {
        [IgnoreMember]
        private T_MemberType_ _T_RequiredScalarMemberName_ = T_MemberDefaultValue_;
        //##if (member.IsObsolete) {
        [Obsolete("T_MemberObsoleteMessage_", T_MemberObsoleteIsError_)]
        //##}
        [Key(T_RequiredScalarMemberKey_)]
        public T_MemberType_ T_RequiredScalarMemberName_
        {
            get => _T_RequiredScalarMemberName_;
            set => _T_RequiredScalarMemberName_ = IfNotFrozen(value);
        }
        //##}
        //##break;
        //##case MemberKind.Vector:
        [IgnoreMember]
        private ReadOnlyMemory<T_MemberType_> _T_VectorMemberName_;
        //##if (member.IsObsolete) {
        [Obsolete("T_MemberObsoleteMessage_", T_MemberObsoleteIsError_)]
        //##}
        [Key(T_VectorMemberKey_)]
        public ReadOnlyMemory<T_MemberType_> T_VectorMemberName_
        {
            get => _T_VectorMemberName_;
            set => _T_VectorMemberName_ = IfNotFrozen(value);
        }
        //##break;
        //##case MemberKind.Entity:
        //##if (member.IsNullable) {
        [IgnoreMember]
        private T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_? _T_NullableEntityMemberName_;
        [Key(T_NullableEntityMemberKey_)]
        public T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_? T_NullableEntityMemberName_
        {
            get => _T_NullableEntityMemberName_;
            set => _T_NullableEntityMemberName_ = IfNotFrozen(value);
        }
        T_MemberTypeNameSpace_.IT_MemberTypeName_? IT_EntityName_.T_NullableEntityMemberName_
        {
            get => _T_NullableEntityMemberName_;
            set
            {
                ThrowIfFrozen();
                _T_NullableEntityMemberName_ = value is null ? null : T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_.CreateFrom(value);
            }
        }
        //##} else {
        [IgnoreMember]
        private T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_ _T_RequiredEntityMemberName_ = T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_.Empty;
        [Key(T_RequiredEntityMemberKey_)]
        public T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_ T_RequiredEntityMemberName_
        {
            get => _T_RequiredEntityMemberName_;
            set => _T_RequiredEntityMemberName_ = IfNotFrozen(value);
        }
        T_MemberTypeNameSpace_.IT_MemberTypeName_ IT_EntityName_.T_RequiredEntityMemberName_
        {
            get => _T_RequiredEntityMemberName_;
            set
            {
                ThrowIfFrozen();
                _T_RequiredEntityMemberName_ = T_MemberTypeNameSpace_.MessagePack.T_MemberTypeName_.CreateFrom(value);
            }
        }
        //##}
        //##break;
        //##default:
        //##Emit($"#error Implementation for MemberKind '{member.Kind}' is missing");
        //##break;
        //##} // switch

        //##}

        public bool Equals(T_ConcreteEntityName_? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            if (!base.Equals(other)) return false;
            //##foreach (var member in entity.Members) {
            //##using var _ = NewScope(member);
            //##switch(member.Kind) {
            //##case MemberKind.Scalar:
            //##if (member.IsNullable) {
            if (_T_NullableScalarMemberName_ != other.T_NullableScalarMemberName_) return false;
            //##} else {
            if (_T_RequiredScalarMemberName_ != other.T_RequiredScalarMemberName_) return false;
            //##}
            //##break;
            //##case MemberKind.Vector:
            if (!_T_VectorMemberName_.Span.SequenceEqual(other.T_VectorMemberName_.Span)) return false;
            //##break;
            //##case MemberKind.Entity:
            //##if (member.IsNullable) {
            if (_T_NullableEntityMemberName_ != other.T_NullableEntityMemberName_) return false;
            //##} else {
            if (_T_RequiredEntityMemberName_ != other.T_RequiredEntityMemberName_) return false;
            //##}
            //##break;
            //##default:
            //##Emit($"#error Implementation for MemberKind '{member.Kind}' is missing");
            //##break;
            //##} // switch
            //##}
            return true;
        }

        public override bool Equals(object? obj) => obj is T_ConcreteEntityName_ other && Equals(other);
        public static bool operator ==(T_ConcreteEntityName_? left, T_ConcreteEntityName_? right) => left is not null ? left.Equals(right) : (right is null);
        public static bool operator !=(T_ConcreteEntityName_? left, T_ConcreteEntityName_? right) => left is not null ? !left.Equals(right) : (right is not null);

        private int CalcHashCode()
        {
            HashCode result = new HashCode();
            result.Add(base.GetHashCode());
            //##foreach (var member in entity.Members) {
            //##using var _ = NewScope(member);
            //##switch(member.Kind) {
            //##case MemberKind.Scalar:
            //##if (member.IsNullable) {
            result.Add(_T_NullableScalarMemberName_);
            //##} else {
            result.Add(_T_RequiredScalarMemberName_);
            //##}
            //##break;
            //##case MemberKind.Vector:
            result.Add(_T_VectorMemberName_.Length);
            for (int i = 0; i < _T_VectorMemberName_.Length; i++)
            {
                result.Add(_T_VectorMemberName_.Span[i]);
            }
            //##break;
            //##case MemberKind.Entity:
            //##if (member.IsNullable) {
            result.Add(_T_NullableEntityMemberName_?.GetHashCode() ?? 0);
            //##} else {
            result.Add(_T_RequiredEntityMemberName_.GetHashCode());
            //##}
            //##break;
            //##default:
            //##Emit($"#error Implementation for MemberKind '{member.Kind}' is missing");
            //##break;
            //##} // switch
            //##}
            return result.ToHashCode();
        }

        [IgnoreMember]
        private int? _hashCode;
        public override int GetHashCode()
        {
            if (_hashCode.HasValue) return _hashCode.Value;
            if (!IsFrozen) return CalcHashCode();
            _hashCode = CalcHashCode();
            return _hashCode.Value;
        }

    }
    //##}
}