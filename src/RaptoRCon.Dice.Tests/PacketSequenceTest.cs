using System;
using System.Collections;
using System.Text;
using Xunit;

namespace RaptoRCon.Dice.Tests
{
    public class PacketSequenceTest
    {
        #region ctor
        
        [Fact]
        public void ctorValues_WithDefaultParameters_ReturnsInstance()
        {
            var id = (uint) 123;
            var origin = PacketOrigin.Client;
            var type = PacketType.Request;

            var packetSequence = new PacketSequence(id, type, origin);

            Assert.NotNull(packetSequence);
            Assert.Equal(id, packetSequence.Id);
            Assert.Equal(origin, packetSequence.Origin);
        }

        [Fact]
        public void ctorValues_WithDefaultParameters_IsImplementationOfIPacketSequence()
        {
            var id = (uint)123;
            var origin = PacketOrigin.Client;
            var type = PacketType.Request;

            var packetSequence = new PacketSequence(id, type, origin);

            Assert.IsAssignableFrom<IPacketSequence>(packetSequence);
        }

        [Fact]
        public void ctorBytes_WithNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new PacketSequence(null));
        }

        [Fact]
        public void ctorBytes_WithByteArrayLenth5_ThrowsArgumentNullException()
        {
            var bytes = Encoding.Default.GetBytes("12345");
            Assert.Equal(5, bytes.Length);

            Assert.Throws<ArgumentOutOfRangeException>(() => new PacketSequence(bytes));
        }

        [Fact]
        public void ctorBytes_WithByteArrayLenth3_ThrowsArgumentNullException()
        {
            var bytes = Encoding.Default.GetBytes("123");
            Assert.Equal(3, bytes.Length);

            Assert.Throws<ArgumentOutOfRangeException>(() => new PacketSequence(bytes));
        }

        [Fact]
        public void ctorBytes_ByteArrayAllBitsFalse_Id0()
        {
            var bitArray = new BitArray(4 * 8, false);
            var bytes = new byte[4];
            bitArray.CopyTo(bytes, 0);

            var instance = new PacketSequence(bytes);
            Assert.NotNull(instance);

            Assert.Equal((uint) 0, instance.Id);
        }

        [Fact]
        public void ctorBytes_ByteArrayAllBitsTrue_Id1073741823()
        {
            var bitArray = new BitArray(4 * 8, true);
            var bytes = new byte[4];
            bitArray.CopyTo(bytes, 0);

            var instance = new PacketSequence(bytes);
            Assert.NotNull(instance);

            Assert.Equal((uint)1073741823, instance.Id);
        }

        [Fact]
        public void ctorBytes_ByteArrayAllBitsTrue_TypeResponse()
        {
            var bitArray = new BitArray(4 * 8, true);
            var bytes = new byte[4];
            bitArray.CopyTo(bytes, 0);

            var instance = new PacketSequence(bytes);
            Assert.NotNull(instance);

            Assert.Equal(PacketType.Response, instance.Type);
        }

        [Fact]
        public void ctorBytes_ByteArrayAllBitsFalse_TypeRequest()
        {
            var bitArray = new BitArray(4 * 8, false);
            var bytes = new byte[4];
            bitArray.CopyTo(bytes, 0);

            var instance = new PacketSequence(bytes);
            Assert.NotNull(instance);

            Assert.Equal(PacketType.Request, instance.Type);
        }

        [Fact]
        public void ctorBytes_ByteArrayAllBitsFalse_OriginServer()
        {
            var bitArray = new BitArray(4 * 8, false);
            var bytes = new byte[4];
            bitArray.CopyTo(bytes, 0);

            var instance = new PacketSequence(bytes);
            Assert.NotNull(instance);

            Assert.Equal(PacketOrigin.Server, instance.Origin);
        }

        [Fact]
        public void ctorBytes_ByteArrayAllBitsTrue_OriginClient()
        {
            var bitArray = new BitArray(4 * 8, true);
            var bytes = new byte[4];
            bitArray.CopyTo(bytes, 0);

            var instance = new PacketSequence(bytes);
            Assert.NotNull(instance);

            Assert.Equal(PacketOrigin.Client, instance.Origin);
        }

        #endregion
    }
}
