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

//##if(false) {
namespace T_BaseNameSpace_.CSPoco
{
    public interface IT_BaseName_ { }
    public class T_BaseName_ : EntityBase, IT_BaseName_, IEquatable<T_BaseName_>
    {
        public T_BaseName_() { }
        public T_BaseName_(IT_BaseName_ source, bool frozen = false) : base(source, frozen) { }
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
//##}
namespace T_NameSpace_.CSPoco
{
    //##if(false) {
    using T_MemberType_ = System.Int32;
    public interface IT_EntityName_ : T_BaseNameSpace_.CSPoco.IT_BaseName_
    {
        T_MemberType_? T_ScalarNullableMemberName_ { get; set; }
        T_MemberType_ T_ScalarRequiredMemberName_ { get; set; }
        ReadOnlyMemory<T_MemberType_> T_VectorMemberName_ { get; set; }
    }
    //##}
    public partial class T_EntityName_ : T_BaseNameSpace_.CSPoco.T_BaseName_, IT_EntityName_, IEquatable<T_EntityName_>
    {
        // Derived entities: T_DerivedEntityCount_
        //##foreach(var derived in entity.DerivedEntities) {
        //##using var _ = NewScope(derived);
        // - T_EntityName_
        //##}
        //##if(false) {
        private const int T_ScalarNullableMemberSequence_ = 1;
        private const int T_ScalarRequiredMemberSequence_ = 2;
        private const int T_VectorMemberSequence_ = 3;
        private const string T_MemberObsoleteMessage_ = null;
        private const bool T_MemberObsoleteIsError_ = false;
        //##}

        protected override void OnFreeze()
        {
            base.OnFreeze();
            // todo freezable members
        }

        protected override IFreezable OnPartCopy() => new T_EntityName_(this);

        public T_EntityName_() { }
        public T_EntityName_(IT_EntityName_ source, bool frozen = false) : base(source, frozen)
        {
            // todo entity members
            //##foreach(var member in entity.Members) {
            //##using var _ = NewScope(member);
            //##if(member.IsVector) {
            _T_VectorMemberName_ = source.T_VectorMemberName_;
            //##} else {
            //##if(member.IsNullable) {
            _T_ScalarNullableMemberName_ = source.T_ScalarNullableMemberName_;
            //##} else {
            _T_ScalarRequiredMemberName_ = source.T_ScalarRequiredMemberName_;
            //##}
            //##}
            //##}
        }

        //##foreach(var member in entity.Members) {
        //##using var _ = NewScope(member);
        //##if(member.IsVector) {
        private ReadOnlyMemory<T_MemberType_> _T_VectorMemberName_;
        //##if(member.IsObsolete) {
        [Obsolete("T_MemberObsoleteMessage_", T_MemberObsoleteIsError_)]
        //##}
        public ReadOnlyMemory<T_MemberType_> T_VectorMemberName_
        {
            get => _T_VectorMemberName_;
            set => _T_VectorMemberName_ = IfNotFrozen(ref value);
        }

        //##} else {
        //##if(member.IsNullable) {
        private T_MemberType_? _T_ScalarNullableMemberName_;
        //##} else {
        private T_MemberType_ _T_ScalarRequiredMemberName_;
        //##}
        //##if(member.IsObsolete) {
        [Obsolete("T_MemberObsoleteMessage_", T_MemberObsoleteIsError_)]
        //##}
        //##if(member.IsNullable) {
        public T_MemberType_? T_ScalarNullableMemberName_
        {
            get => _T_ScalarNullableMemberName_;
            set => _T_ScalarNullableMemberName_ = IfNotFrozen(ref value);
        }
        //##} else {
        public T_MemberType_ T_ScalarRequiredMemberName_
        {
            get => _T_ScalarRequiredMemberName_;
            set => _T_ScalarRequiredMemberName_ = IfNotFrozen(ref value);
        }
        //##}

        //##}
        //##}

        public bool Equals(T_EntityName_? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            if (!base.Equals(other)) return false;
            //##foreach(var member in entity.Members) {
            //##using var _ = NewScope(member);
            //##if(member.IsVector) {
            if (!_T_VectorMemberName_.Span.SequenceEqual(other.T_VectorMemberName_.Span)) return false;
            //##} else {
            //##if(member.IsNullable) {
            if (_T_ScalarNullableMemberName_ != other.T_ScalarNullableMemberName_) return false;
            //##} else {
            if (_T_ScalarRequiredMemberName_ != other.T_ScalarRequiredMemberName_) return false;
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
            //##foreach(var member in entity.Members) {
            //##using var _ = NewScope(member);
            //##if(member.IsVector) {
            result.Add(_T_VectorMemberName_.Length);
            for (int i = 0; i < _T_VectorMemberName_.Length; i++)
            {
                result.Add(_T_VectorMemberName_.Span[i]);
            }
            //##} else {
            //##if(member.IsNullable) {
            result.Add(_T_ScalarNullableMemberName_);
            //##} else {
            result.Add(_T_ScalarRequiredMemberName_);
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
