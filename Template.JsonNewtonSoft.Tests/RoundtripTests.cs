using Newtonsoft.Json;
using Shouldly;
using System;
using System.Linq;
using T_NameSpace_.JsonNewtonSoft;
using Xunit;

#pragma warning disable CS0618 // Type or member is obsolete

namespace Template.JsonNewtonSoft.Tests
{
    public class RoundtripTests
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            TypeNameHandling = TypeNameHandling.Auto,
        };

        [Fact]
        public void Roundtrip01AsEntity()
        {
            byte[] smallBinary = new byte[] { 1, 2, 3, 4, 5, 6, 7 };
            byte[] largeBinary = Enumerable.Range(0, 256).Select(i => (byte)i).ToArray();

            var orig = new T_EntityImplName_();
            orig.BaseField1 = 321;
            orig.T_RequiredScalarMemberName_ = 123;
            orig.T_VectorMemberName_ = new int[] { 1, 2, 3 };
            //todo orig.T_RequiredEntityMemberName_ = new T_MemberTypeNameSpace_.JsonNewtonSoft.T_MemberTypeImplName_() { Field1 = 456L };
            orig.T_RequiredBinaryMemberName_ = largeBinary;
            orig.T_NullableBinaryMemberName_ = smallBinary;
            orig.Freeze();

            string buffer = JsonConvert.SerializeObject(orig, typeof(T_EntityImplName_), settings);
            var copy = JsonConvert.DeserializeObject<T_EntityImplName_>(buffer, settings);

            copy.ShouldNotBeNull();
            copy.Freeze();
            copy.IsFrozen.ShouldBeTrue();
            copy.BaseField1!.ShouldBe(orig.BaseField1);
            copy.T_RequiredScalarMemberName_.ShouldBe(orig.T_RequiredScalarMemberName_);
            copy.T_VectorMemberName_.AsSpan().SequenceEqual(orig.T_VectorMemberName_.AsSpan()).ShouldBeTrue();
            copy.T_RequiredBinaryMemberName_.AsSpan().SequenceEqual(orig.T_RequiredBinaryMemberName_.AsSpan()).ShouldBeTrue();
            copy.ShouldBe(orig);
            copy.GetHashCode().ShouldBe(orig.GetHashCode());
        }

        [Fact]
        public void Roundtrip03AsBase()
        {
            byte[] smallBinary = new byte[] { 1, 2, 3, 4, 5, 6, 7 };
            byte[] largeBinary = Enumerable.Range(0, 256).Select(i => (byte)i).ToArray();

            var orig = new T_EntityImplName_();
            orig.BaseField1 = 321;
            orig.T_RequiredScalarMemberName_ = 123;
            orig.T_VectorMemberName_ = new int[] { 1, 2, 3 };
            orig.T_RequiredBinaryMemberName_ = largeBinary;
            orig.T_NullableBinaryMemberName_ = smallBinary;
            orig.Freeze();

            string buffer = JsonConvert.SerializeObject(orig, typeof(T_BaseNameSpace_.JsonNewtonSoft.T_BaseName_), settings);
            var recd = JsonConvert.DeserializeObject<T_BaseNameSpace_.JsonNewtonSoft.T_BaseName_>(buffer, settings);

            recd.ShouldNotBeNull();
            recd.ShouldBeOfType<T_EntityImplName_>();
            recd.Freeze();
            var copy = recd as T_EntityImplName_;
            copy.ShouldNotBeNull();
            copy!.IsFrozen.ShouldBeTrue();
            copy.BaseField1!.ShouldBe(orig.BaseField1);
            copy.T_RequiredScalarMemberName_.ShouldBe(orig.T_RequiredScalarMemberName_);
            copy.T_VectorMemberName_.AsSpan().SequenceEqual(orig.T_VectorMemberName_.AsSpan()).ShouldBeTrue();
            copy.T_RequiredBinaryMemberName_.AsSpan().SequenceEqual(orig.T_RequiredBinaryMemberName_.AsSpan()).ShouldBeTrue();
            copy.ShouldBe(orig);
            copy.GetHashCode().ShouldBe(orig.GetHashCode());
        }
    }
}