using DataFac.Memory;
using MessagePack;
using MyOrg.Models;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Sandbox.Tests
{
    public class RoundtripTests
    {
        [Fact]
        public void Octets_Conversion()
        {
            ReadOnlySpan<byte> data = stackalloc byte[5] { 1, 2, 3, 4, 5 };

            {
                ReadOnlyMemory<byte> memory = new ReadOnlyMemory<byte>(data.ToArray());
                Octets octets = Octets.UnsafeWrap(memory);
                octets.ShouldNotBeNull();
            }
            {
                ReadOnlyMemory<byte> memory = new ReadOnlyMemory<byte>(data.ToArray());
                Octets? octets = Octets.UnsafeWrap(memory);
                octets.ShouldNotBeNull();
            }
            {
                ReadOnlyMemory<byte>? memory = new ReadOnlyMemory<byte>(data.ToArray());
                Octets? octets = memory is null ? null : Octets.UnsafeWrap(memory.Value);
                octets.ShouldNotBeNull();
            }
            {
                ReadOnlyMemory<byte>? memory = null;
                Octets? octets = memory is null ? null : Octets.UnsafeWrap(memory.Value);
                octets.ShouldBeNull();
            }
        }

        //[Fact]
        //public async Task Roundtrip_Octets_MemBlocks()
        //{
        //    var orig = new MyOrg.Models.CSPoco.MyDTO()
        //    {
        //        Other1 = new MyOrg.Models.CSPoco.Other() { Value1 = 1, Value2 = 2 },
        //        Field1 = Octets.UnsafeWrap(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
        //        Field2 = null,
        //    };
        //    orig.Freeze();

        //    IMyDTO iorig = orig;
        //    iorig.Field1.ShouldNotBeNull();
        //    iorig.Field2.ShouldBeNull();

        //    using var dataStore = new DataFac.Storage.Testing.TestDataStore();

        //    var send = new MyOrg.Models.MemBlocks.MyDTO(orig);
        //    await send.Pack(dataStore);

        //    var buffer = send.GetBuffer();

        //    var recv = MyOrg.Models.MemBlocks.MyDTO.CreateFrom(buffer);
        //    await recv.UnpackAll(dataStore);

        //    recv.Equals(send).ShouldBeTrue();
        //    (recv.Other1 == send.Other1).ShouldBeTrue();
        //    (recv.Field1 == send.Field1).ShouldBeTrue();
        //    (recv.Field2 == send.Field2).ShouldBeTrue();

        //    var copy = new MyOrg.Models.CSPoco.MyDTO(recv);
        //    copy.Freeze();

        //    copy.Equals(orig).ShouldBeTrue();
        //    (copy == orig).ShouldBeTrue();
        //    (copy.Other1 == orig.Other1).ShouldBeTrue();
        //    (copy.Field1 == orig.Field1).ShouldBeTrue();
        //    (copy.Field2 == orig.Field2).ShouldBeTrue();
        //}

        [Fact]
        public void Roundtrip_Octets_MessagePack()
        {
            var orig = new MyOrg.Models.CSPoco.MyDTO()
            {
                Other1 = new MyOrg.Models.CSPoco.Other() { Value1 = 1, Value2 = 2 },
                Field1 = Octets.UnsafeWrap(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }),
                Field2 = null,
            };
            orig.Freeze();

            IMyDTO iorig = orig;
            iorig.Field1.ShouldNotBeNull();
            iorig.Field2.ShouldBeNull();

            var sender = new MyOrg.Models.MessagePack.MyDTO(orig);
            sender.Freeze();

            IMyDTO isend = sender;
            isend.Field1.ShouldNotBeNull();
            isend.Field2.ShouldBeNull();

            var buffer = MessagePackSerializer.Serialize(sender);

            var recver = MessagePackSerializer.Deserialize<MyOrg.Models.MessagePack.MyDTO>(buffer);
            recver.Freeze();

            IMyDTO irecv = recver;
            irecv.Field1.ShouldNotBeNull();
            irecv.Field2.ShouldBeNull();

            recver.Equals(sender).ShouldBeTrue();
            irecv.Field1.Equals(isend.Field1).ShouldBeTrue();

            var copy = new MyOrg.Models.CSPoco.MyDTO(recver);
            copy.Freeze();

            copy.Equals(orig).ShouldBeTrue();
            (copy == orig).ShouldBeTrue();
            (copy.Other1 == orig.Other1).ShouldBeTrue();
            (copy.Field1 == orig.Field1).ShouldBeTrue();
            (copy.Field2 == orig.Field2).ShouldBeTrue();
        }
    }
}