﻿// <auto-generated>
// This file was generated by DTOMaker.CSPoco.
// NuGet: https://www.nuget.org/packages/DTOMaker.CSPoco
// Warning: Changes made to this file will be lost if re-generated.
// </auto-generated>
#pragma warning disable CS0109 // Member does not hide an inherited member; new keyword is not required
#nullable enable
using DataFac.Memory;
using DTOMaker.Runtime;
using DTOMaker.Runtime.CSPoco;
using System;

namespace MyOrg.Models.CSPoco
{
    public partial class Other : DTOMaker.Runtime.CSPoco.EntityBase, IOther, IEquatable<Other>
    {
        // Derived entities: 0

        public new const string EntityId = "MyOrg.Models.Other";

        private static Other CreateEmpty()
        {
            var empty = new Other();
            empty.Freeze();
            return empty;
        }
        private static readonly Other _empty = CreateEmpty();
        public static Other Empty => _empty;

        public new static Other CreateFrom(Other source)
        {
            if (source.IsFrozen) return source;
            return source switch
            {
                _ => new MyOrg.Models.CSPoco.Other(source)
            };
        }

        public new static Other CreateFrom(MyOrg.Models.IOther source)
        {
            if (source is Other concrete && concrete.IsFrozen) return concrete;
            return source switch
            {
                _ => new MyOrg.Models.CSPoco.Other(source)
            };
        }

        protected override string OnGetEntityId() => EntityId;

        protected override void OnFreeze()
        {
            base.OnFreeze();
        }

        protected override IFreezable OnPartCopy() => new Other(this);

        public Other() { }
        public Other(IOther source) : base(source)
        {
            _Value1 = source.Value1;
            _Value2 = source.Value2;
        }

        private Int64 _Value1 = default;
        public Int64 Value1
        {
            get => _Value1;
            set => _Value1 = IfNotFrozen(ref value);
        }

        private Int64 _Value2 = default;
        public Int64 Value2
        {
            get => _Value2;
            set => _Value2 = IfNotFrozen(ref value);
        }


        public bool Equals(Other? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            if (!base.Equals(other)) return false;
            if (_Value1 != other.Value1) return false;
            if (_Value2 != other.Value2) return false;
            return true;
        }

        public override bool Equals(object? obj) => obj is Other other && Equals(other);
        public static bool operator ==(Other? left, Other? right) => left is not null ? left.Equals(right) : (right is null);
        public static bool operator !=(Other? left, Other? right) => left is not null ? !left.Equals(right) : (right is not null);

        private int CalcHashCode()
        {
            HashCode result = new HashCode();
            result.Add(base.GetHashCode());
            result.Add(_Value1);
            result.Add(_Value2);
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
