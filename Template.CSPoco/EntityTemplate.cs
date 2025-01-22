﻿// <auto-generated>
// This file was generated by DTOMaker.CSPoco.
// NuGet: https://www.nuget.org/packages/DTOMaker.CSPoco
// Warning: Changes made to this file will be lost if re-generated.
// </auto-generated>
//##if(false) {
#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS0162 // Unreachable code detected
//##}
#pragma warning disable CS0109 // Member does not hide an inherited member; new keyword is not required
#nullable enable
using DTOMaker.Runtime;
using DTOMaker.Runtime.CSPoco;
using System;

//##if (false) {
using T_MemberType_ = System.Int32;
namespace T_MemberTypeNameSpace_
{
    public interface IT_MemberTypeName_ { }
}
namespace T_MemberTypeNameSpace_.CSPoco
{
    public class T_MemberTypeName_ : EntityBase, IT_MemberTypeName_
    {
        private static readonly T_MemberTypeName_ _empty = new T_MemberTypeName_();
        public static T_MemberTypeName_ Empty => _empty;
        public T_MemberTypeName_() { }
        public T_MemberTypeName_(IT_MemberTypeName_ source) { }
        protected override IFreezable OnPartCopy() => throw new NotImplementedException();
        protected override string OnGetEntityId() => "T_MemberTypeName_";
    }
}
namespace T_BaseNameSpace_
{
    public interface IT_BaseName_ { }
}
namespace T_BaseNameSpace_.CSPoco
{
    public abstract class T_BaseName_ : EntityBase, IT_BaseName_, IEquatable<T_BaseName_>
    {
        public T_BaseName_() { }
        public T_BaseName_(IT_BaseName_ source) : base(source) { }

        protected override void OnFreeze() => base.OnFreeze();
        protected override IFreezable OnPartCopy() => throw new NotImplementedException();

        public T_MemberType_ BaseField1 { get; set; }

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
    public interface IT_EntityName_ : T_BaseNameSpace_.IT_BaseName_
    {
        T_MemberType_? T_NullableScalarMemberName_ { get; set; }
        T_MemberType_ T_RequiredScalarMemberName_ { get; set; }
        ReadOnlyMemory<T_MemberType_> T_VectorMemberName_ { get; set; }
        T_MemberTypeNameSpace_.IT_MemberTypeName_? T_NullableEntityMemberName_ { get; set; }
        T_MemberTypeNameSpace_.IT_MemberTypeName_ T_RequiredEntityMemberName_ { get; set; }
    }
}
//##}
namespace T_NameSpace_.CSPoco
{
    //##if (false) {
    //##}
    public partial class T_EntityName_ : T_BaseNameSpace_.CSPoco.T_BaseName_, IT_EntityName_, IEquatable<T_EntityName_>
    {
        // Derived entities: T_DerivedEntityCount_
        //##foreach (var derived in entity.DerivedEntities) {
        //##using var _ = NewScope(derived);
        // - T_EntityName_
        //##}
        //##if (false) {
        private const string T_MemberObsoleteMessage_ = null;
        private const bool T_MemberObsoleteIsError_ = false;
        private const int T_MemberDefaultValue_ = 0;
        //##}

        public new const string EntityId = "T_EntityId_";

        public new static T_EntityName_ CreateFrom(T_NameSpace_.IT_EntityName_ source)
        {
            return source switch
            {
                //##foreach(var derived in entity.DerivedEntities) {
                //##using var _ = NewScope(derived);
                T_NameSpace_.IT_EntityName_ source2 => new T_NameSpace_.CSPoco.T_EntityName_(source2),
                //##}
                _ => throw new ArgumentException($"Unexpected type: {source.GetType().Name}", nameof(source))
            };
        }

        protected override string OnGetEntityId() => EntityId;

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

        protected override IFreezable OnPartCopy() => new T_EntityName_(this);

        public T_EntityName_() { }
        public T_EntityName_(IT_EntityName_ source) : base(source)
        {
            //##foreach (var member in entity.Members) {
            //##using var _ = NewScope(member);
            //##if (member.IsVector) {
            _T_VectorMemberName_ = source.T_VectorMemberName_;
            //##} else if (member.IsEntity) {
            //##if (member.IsNullable) {
            _T_NullableEntityMemberName_ = source.T_NullableEntityMemberName_ is null ? null : new T_MemberTypeNameSpace_.CSPoco.T_MemberTypeName_(source.T_NullableEntityMemberName_);
            //##} else {
            _T_RequiredEntityMemberName_ = new T_MemberTypeNameSpace_.CSPoco.T_MemberTypeName_(source.T_RequiredEntityMemberName_);
            //##}
            //##} else {
            //##if (member.IsNullable) {
            _T_NullableScalarMemberName_ = source.T_NullableScalarMemberName_;
            //##} else {
            _T_RequiredScalarMemberName_ = source.T_RequiredScalarMemberName_;
            //##}
            //##}
            //##}
        }

        //##foreach (var member in entity.Members) {
        //##using var _ = NewScope(member);
        //##if (member.IsVector) {
        private ReadOnlyMemory<T_MemberType_> _T_VectorMemberName_;
        //##if (member.IsObsolete) {
        [Obsolete("T_MemberObsoleteMessage_", T_MemberObsoleteIsError_)]
        //##}
        public ReadOnlyMemory<T_MemberType_> T_VectorMemberName_
        {
            get => _T_VectorMemberName_;
            set => _T_VectorMemberName_ = IfNotFrozen(ref value);
        }
        //##} else if (member.IsEntity) {
        //##if (member.IsNullable) {
        private T_MemberTypeNameSpace_.CSPoco.T_MemberTypeName_? _T_NullableEntityMemberName_;
        public T_MemberTypeNameSpace_.CSPoco.T_MemberTypeName_? T_NullableEntityMemberName_
        {
            get => _T_NullableEntityMemberName_;
            set => _T_NullableEntityMemberName_ = IfNotFrozen(ref value);
        }
        T_MemberTypeNameSpace_.IT_MemberTypeName_? IT_EntityName_.T_NullableEntityMemberName_
        {
            get => _T_NullableEntityMemberName_;
            set
            {
                ThrowIfFrozen();
                _T_NullableEntityMemberName_ = value is null ? null : new T_MemberTypeNameSpace_.CSPoco.T_MemberTypeName_(value);
            }
        }
        //##} else {
        private T_MemberTypeNameSpace_.CSPoco.T_MemberTypeName_ _T_RequiredEntityMemberName_ = T_MemberTypeNameSpace_.CSPoco.T_MemberTypeName_.Empty;
        public T_MemberTypeNameSpace_.CSPoco.T_MemberTypeName_ T_RequiredEntityMemberName_
        {
            get => _T_RequiredEntityMemberName_;
            set => _T_RequiredEntityMemberName_ = IfNotFrozen(ref value);
        }
        T_MemberTypeNameSpace_.IT_MemberTypeName_ IT_EntityName_.T_RequiredEntityMemberName_
        {
            get => _T_RequiredEntityMemberName_;
            set
            {
                ThrowIfFrozen();
                _T_RequiredEntityMemberName_ = new T_MemberTypeNameSpace_.CSPoco.T_MemberTypeName_(value);
            }
        }
        //##}
        //##} else {
        //##if (member.IsNullable) {
        private T_MemberType_? _T_NullableScalarMemberName_;
        //##} else {
        private T_MemberType_ _T_RequiredScalarMemberName_ = T_MemberDefaultValue_;
        //##}
        //##if (member.IsObsolete) {
        [Obsolete("T_MemberObsoleteMessage_", T_MemberObsoleteIsError_)]
        //##}
        //##if (member.IsNullable) {
        public T_MemberType_? T_NullableScalarMemberName_
        {
            get => _T_NullableScalarMemberName_;
            set => _T_NullableScalarMemberName_ = IfNotFrozen(ref value);
        }
        //##} else {
        public T_MemberType_ T_RequiredScalarMemberName_
        {
            get => _T_RequiredScalarMemberName_;
            set => _T_RequiredScalarMemberName_ = IfNotFrozen(ref value);
        }
        //##}
        //##}

        //##}

        public bool Equals(T_EntityName_? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            if (!base.Equals(other)) return false;
            //##foreach (var member in entity.Members) {
            //##using var _ = NewScope(member);
            //##if (member.IsVector) {
            if (!_T_VectorMemberName_.Span.SequenceEqual(other.T_VectorMemberName_.Span)) return false;
            //##} else {
            //##if (member.IsNullable) {
            if (_T_NullableScalarMemberName_ != other.T_NullableScalarMemberName_) return false;
            //##} else {
            if (_T_RequiredScalarMemberName_ != other.T_RequiredScalarMemberName_) return false;
            //##}
            //##}
            //##}
            return true;
        }

        public override bool Equals(object? obj) => obj is T_EntityName_ other && Equals(other);
        public static bool operator ==(T_EntityName_? left, T_EntityName_? right) => left is not null ? left.Equals(right) : (right is null);
        public static bool operator !=(T_EntityName_? left, T_EntityName_? right) => left is not null ? !left.Equals(right) : (right is not null);

        private int CalcHashCode()
        {
            HashCode result = new HashCode();
            result.Add(base.GetHashCode());
            //##foreach (var member in entity.Members) {
            //##using var _ = NewScope(member);
            //##if (member.IsVector) {
            result.Add(_T_VectorMemberName_.Length);
            for (int i = 0; i < _T_VectorMemberName_.Length; i++)
            {
                result.Add(_T_VectorMemberName_.Span[i]);
            }
            //##} else {
            //##if (member.IsNullable) {
            result.Add(_T_NullableScalarMemberName_);
            //##} else {
            result.Add(_T_RequiredScalarMemberName_);
            //##}
            //##}
            //##}
            return result.ToHashCode();
        }

        private int? _hashCode;
        public override int GetHashCode()
        {
            if (_hashCode.HasValue) return _hashCode.Value;
            if (!IsFrozen) return CalcHashCode();
            _hashCode = CalcHashCode();
            return _hashCode.Value;
        }

    }
}