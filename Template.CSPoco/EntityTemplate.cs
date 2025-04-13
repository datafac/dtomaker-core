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
using DataFac.Memory;
using DTOMaker.Runtime;
using DTOMaker.Runtime.CSPoco;
using System;

//##if (false) {
using T_MemberType_ = System.Int32;
namespace T_MemberTypeNameSpace_
{
    public interface IT_MemberTypeIntfName_ { }
}
namespace T_MemberTypeNameSpace_.CSPoco
{
    public class T_MemberTypeImplName_ : EntityBase, IT_MemberTypeIntfName_
    {
        protected override int OnGetEntityId() => 3;

        private static T_MemberTypeImplName_ CreateEmpty()
        {
            var empty = new T_MemberTypeImplName_();
            empty.Freeze();
            return empty;
        }
        private static readonly T_MemberTypeImplName_ _empty = CreateEmpty();
        public static new T_MemberTypeImplName_ Empty => _empty;

        public static T_MemberTypeImplName_ CreateFrom(IT_MemberTypeIntfName_ source) => throw new NotImplementedException();
        public T_MemberTypeImplName_() { }
        public T_MemberTypeImplName_(IT_MemberTypeIntfName_ source) { }
        protected override IFreezable OnPartCopy() => throw new NotImplementedException();
    }
}
namespace T_BaseNameSpace_
{
    public interface IT_BaseName_ { }
}
namespace T_BaseNameSpace_.CSPoco
{
    public class T_BaseName_ : EntityBase, IT_BaseName_, IEquatable<T_BaseName_>
    {
        protected override int OnGetEntityId() => 2;

        private static T_BaseName_ CreateEmpty()
        {
            var empty = new T_BaseName_();
            empty.Freeze();
            return empty;
        }
        private static readonly T_BaseName_ _empty = CreateEmpty();
        public static new T_BaseName_ Empty => _empty;

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
    public interface IT_EntityIntfName_ : T_BaseNameSpace_.IT_BaseName_
    {
        T_MemberType_? T_NullableScalarMemberName_ { get; }
        T_MemberType_ T_RequiredScalarMemberName_ { get; }
        ReadOnlyMemory<T_MemberType_> T_VectorMemberName_ { get; }
        T_MemberTypeNameSpace_.IT_MemberTypeIntfName_? T_NullableEntityMemberName_ { get; }
        T_MemberTypeNameSpace_.IT_MemberTypeIntfName_ T_RequiredEntityMemberName_ { get; }
        Octets? T_NullableBinaryMemberName_ { get; }
        Octets T_RequiredBinaryMemberName_ { get; }
        string? T_NullableStringMemberName_ { get; }
        string T_RequiredStringMemberName_ { get; }
    }
}
//##}
namespace T_NameSpace_.CSPoco
{
    //##if (false) {
    //##}
    public partial class T_EntityImplName_ : T_BaseNameSpace_.CSPoco.T_BaseName_, IT_EntityIntfName_, IEquatable<T_EntityImplName_>
    {
        // Derived entities: T_DerivedEntityCount_
        //##foreach (var derived in entity.DerivedEntities) {
        //##using var _ = NewScope(derived);
        // - T_EntityImplName_
        //##}
        //##if (false) {
        private const string T_MemberObsoleteMessage_ = null;
        private const bool T_MemberObsoleteIsError_ = false;
        private const int T_MemberDefaultValue_ = 0;
        private const int T_EntityId_ = 1;
        //##}

        protected override int OnGetEntityId() => T_EntityId_;

        private static T_EntityImplName_ CreateEmpty()
        {
            var empty = new T_EntityImplName_();
            empty.Freeze();
            return empty;
        }
        private static readonly T_EntityImplName_ _empty = CreateEmpty();
        public static new T_EntityImplName_ Empty => _empty;

        public new static T_EntityImplName_ CreateFrom(T_EntityImplName_ source)
        {
            if (source.IsFrozen) return source;
            return source switch
            {
                //##foreach(var derived in entity.DerivedEntities.OrderByDescending(e => e.ClassHeight)) {
                //##using var _ = NewScope(derived);
                T_NameSpace_.CSPoco.T_EntityImplName_ source2 => new T_NameSpace_.CSPoco.T_EntityImplName_(source2),
                //##}
                _ => new T_NameSpace_.CSPoco.T_EntityImplName_(source)
            };
        }

        public new static T_EntityImplName_ CreateFrom(T_NameSpace_.IT_EntityIntfName_ source)
        {
            if (source is T_EntityImplName_ concrete && concrete.IsFrozen) return concrete;
            return source switch
            {
                //##foreach(var derived in entity.DerivedEntities.OrderByDescending(e => e.ClassHeight)) {
                //##using var _ = NewScope(derived);
                T_NameSpace_.IT_EntityIntfName_ source2 => new T_NameSpace_.CSPoco.T_EntityImplName_(source2),
                //##}
                _ => new T_NameSpace_.CSPoco.T_EntityImplName_(source)
            };
        }

        protected override void OnFreeze()
        {
            base.OnFreeze();
            //##foreach (var member in entity.Members) {
            //##using var _ = NewScope(member);
            //##switch(member.Kind) {
            //##case MemberKind.Native:
            //##break;
            //##case MemberKind.Vector:
            //##break;
            //##case MemberKind.Entity:
            //##if (member.IsNullable) {
            _T_NullableEntityMemberName_?.Freeze();
            //##} else {
            _T_RequiredEntityMemberName_.Freeze();
            //##}
            //##break;
            //##case MemberKind.Binary:
            //##break;
            //##case MemberKind.String:
            //##break;
            //##default:
            //##Emit($"#error Implementation for MemberKind '{member.Kind}' is missing");
            //##break;
            //##} // switch
            //##}
        }

        protected override IFreezable OnPartCopy() => new T_EntityImplName_(this);

        public T_EntityImplName_() { }
        public T_EntityImplName_(IT_EntityIntfName_ source) : base(source)
        {
            //##foreach (var member in entity.Members) {
            //##using var _ = NewScope(member);
            //##switch(member.Kind) {
            //##case MemberKind.Native:
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
            _T_NullableEntityMemberName_ = source.T_NullableEntityMemberName_ is null ? null : T_MemberTypeNameSpace_.CSPoco.T_MemberTypeImplName_.CreateFrom(source.T_NullableEntityMemberName_);
            //##} else {
            _T_RequiredEntityMemberName_ = T_MemberTypeNameSpace_.CSPoco.T_MemberTypeImplName_.CreateFrom(source.T_RequiredEntityMemberName_);
            //##}
            //##break;
            //##case MemberKind.Binary:
            //##if (member.IsNullable) {
            _T_NullableBinaryMemberName_ = source.T_NullableBinaryMemberName_;
            //##} else {
            _T_RequiredBinaryMemberName_ = source.T_RequiredBinaryMemberName_;
            //##}
            //##break;
            //##case MemberKind.String:
            //##if (member.IsNullable) {
            _T_NullableStringMemberName_ = source.T_NullableStringMemberName_;
            //##} else {
            _T_RequiredStringMemberName_ = source.T_RequiredStringMemberName_;
            //##}
            //##break;
            //##default:
            //##Emit($"#error Implementation for MemberKind '{member.Kind}' is missing");
            //##break;
            //##} // switch
            //##} // foreach
        }

        //##foreach (var member in entity.Members) {
        //##using var _ = NewScope(member);
        //##switch(member.Kind) {
        //##case MemberKind.Native:
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
        //##break;
        //##case MemberKind.Vector:
        private ReadOnlyMemory<T_MemberType_> _T_VectorMemberName_;
        //##if (member.IsObsolete) {
        [Obsolete("T_MemberObsoleteMessage_", T_MemberObsoleteIsError_)]
        //##}
        public ReadOnlyMemory<T_MemberType_> T_VectorMemberName_
        {
            get => _T_VectorMemberName_;
            set => _T_VectorMemberName_ = IfNotFrozen(ref value);
        }
        //##break;
        //##case MemberKind.Entity:
        //##if (member.IsNullable) {
        private T_MemberTypeNameSpace_.CSPoco.T_MemberTypeImplName_? _T_NullableEntityMemberName_;
        public T_MemberTypeNameSpace_.CSPoco.T_MemberTypeImplName_? T_NullableEntityMemberName_
        {
            get => _T_NullableEntityMemberName_;
            set => _T_NullableEntityMemberName_ = IfNotFrozen(ref value);
        }
        T_MemberTypeNameSpace_.IT_MemberTypeIntfName_? IT_EntityIntfName_.T_NullableEntityMemberName_ => _T_NullableEntityMemberName_;
        //##} else {
        private T_MemberTypeNameSpace_.CSPoco.T_MemberTypeImplName_ _T_RequiredEntityMemberName_ = T_MemberTypeNameSpace_.CSPoco.T_MemberTypeImplName_.Empty;
        public T_MemberTypeNameSpace_.CSPoco.T_MemberTypeImplName_ T_RequiredEntityMemberName_
        {
            get => _T_RequiredEntityMemberName_;
            set => _T_RequiredEntityMemberName_ = IfNotFrozen(ref value);
        }
        T_MemberTypeNameSpace_.IT_MemberTypeIntfName_ IT_EntityIntfName_.T_RequiredEntityMemberName_ => _T_RequiredEntityMemberName_;
        //##}
        //##break;
        //##case MemberKind.Binary:
        //##if (member.IsNullable) {
        private Octets? _T_NullableBinaryMemberName_;
        public Octets? T_NullableBinaryMemberName_
        {
            get => _T_NullableBinaryMemberName_;
            set => _T_NullableBinaryMemberName_ = IfNotFrozen(ref value);
        }
        //##} else {
        private Octets _T_RequiredBinaryMemberName_ = Octets.Empty;
        public Octets T_RequiredBinaryMemberName_
        {
            get => _T_RequiredBinaryMemberName_;
            set => _T_RequiredBinaryMemberName_ = IfNotFrozen(ref value);
        }
        //##}
        //##break;
        //##case MemberKind.String:
        //##if (member.IsNullable) {
        private string? _T_NullableStringMemberName_;
        public string? T_NullableStringMemberName_
        {
            get => _T_NullableStringMemberName_;
            set => _T_NullableStringMemberName_ = IfNotFrozen(ref value);
        }
        //##} else {
        private string _T_RequiredStringMemberName_ = string.Empty;
        public string T_RequiredStringMemberName_
        {
            get => _T_RequiredStringMemberName_;
            set => _T_RequiredStringMemberName_ = IfNotFrozen(ref value);
        }
        //##}
        //##break;
        //##default:
        //##Emit($"#error Implementation for MemberKind '{member.Kind}' is missing");
        //##break;
        //##} // switch

        //##}

        public bool Equals(T_EntityImplName_? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            if (!base.Equals(other)) return false;
            //##foreach (var member in entity.Members) {
            //##using var _ = NewScope(member);
            //##switch(member.Kind) {
            //##case MemberKind.Native:
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
            //##case MemberKind.Binary:
            //##if (member.IsNullable) {
            if (_T_NullableBinaryMemberName_ != other.T_NullableBinaryMemberName_) return false;
            //##} else {
            if (_T_RequiredBinaryMemberName_ != other.T_RequiredBinaryMemberName_) return false;
            //##}
            //##break;
            //##case MemberKind.String:
            //##if (member.IsNullable) {
            if (_T_NullableStringMemberName_ != other.T_NullableStringMemberName_) return false;
            //##} else {
            if (_T_RequiredStringMemberName_ != other.T_RequiredStringMemberName_) return false;
            //##}
            //##break;
            //##default:
            //##Emit($"#error Implementation for MemberKind '{member.Kind}' is missing");
            //##break;
            //##} // switch
            //##}
            return true;
        }

        public override bool Equals(object? obj) => obj is T_EntityImplName_ other && Equals(other);
        public static bool operator ==(T_EntityImplName_? left, T_EntityImplName_? right) => left is not null ? left.Equals(right) : (right is null);
        public static bool operator !=(T_EntityImplName_? left, T_EntityImplName_? right) => left is not null ? !left.Equals(right) : (right is not null);

        private int CalcHashCode()
        {
            HashCode result = new HashCode();
            result.Add(base.GetHashCode());
            //##foreach (var member in entity.Members) {
            //##using var _ = NewScope(member);
            //##switch(member.Kind) {
            //##case MemberKind.Native:
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
            result.Add(_T_NullableEntityMemberName_);
            //##} else {
            result.Add(_T_RequiredEntityMemberName_);
            //##}
            //##break;
            //##case MemberKind.Binary:
            //##if (member.IsNullable) {
            result.Add(_T_NullableBinaryMemberName_);
            //##} else {
            result.Add(_T_RequiredBinaryMemberName_);
            //##}
            //##break;
            //##case MemberKind.String:
            //##if (member.IsNullable) {
            result.Add(_T_NullableStringMemberName_);
            //##} else {
            result.Add(_T_RequiredStringMemberName_);
            //##}
            //##break;
            //##default:
            //##Emit($"#error Implementation for MemberKind '{member.Kind}' is missing");
            //##break;
            //##} // switch
            //##}
            return result.ToHashCode();
        }

        private int? _hashCode;
        public override int GetHashCode()
        {
            if (!IsFrozen) return CalcHashCode();
            if (_hashCode.HasValue) return _hashCode.Value;
            _hashCode = CalcHashCode();
            return _hashCode.Value;
        }

    }
}