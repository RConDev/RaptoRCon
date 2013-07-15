﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RaptoRCon.Dice.Tests
{
    public class PacketSequenceFactoryTest
    {
        private readonly PacketSequenceFactory sequenceFactory;

        public PacketSequenceFactoryTest()
        {
            this.sequenceFactory = new PacketSequenceFactory();
        }

        #region FromBytes()

        [Fact]
        public void ctorBytes_WithNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => sequenceFactory.FromBytes(null));
        }

        [Fact]
        public void ctorBytes_WithByteArrayLenth5_ThrowsArgumentNullException()
        {
            var bytes = Encoding.Default.GetBytes("12345");

            Assert.Throws<ArgumentOutOfRangeException>(() => sequenceFactory.FromBytes(bytes));
        }

        [Fact]
        public void ctorBytes_WithByteArrayLenth3_ThrowsArgumentNullException()
        {
            var bytes = Encoding.Default.GetBytes("123");
            Assert.Equal(3, bytes.Length);

            Assert.Throws<ArgumentOutOfRangeException>(() => sequenceFactory.FromBytes(bytes));
        }

        [Fact]
        public void ctorBytes_ByteArrayAllBitsFalse_Id0()
        {
            var bitArray = new BitArray(4 * 8, false);
            var bytes = new byte[4];
            bitArray.CopyTo(bytes, 0);

            var instance = sequenceFactory.FromBytes(bytes);
            Assert.NotNull(instance);

            Assert.Equal((uint)0, instance.Id);
        }

        [Fact]
        public void ctorBytes_ByteArrayAllBitsTrue_Id1073741823()
        {
            var bitArray = new BitArray(4 * 8, true);
            var bytes = new byte[4];
            bitArray.CopyTo(bytes, 0);

            var instance = sequenceFactory.FromBytes(bytes);
            Assert.NotNull(instance);

            Assert.Equal((uint)1073741823, instance.Id);
        }

        [Fact]
        public void ctorBytes_ByteArrayAllBitsTrue_TypeResponse()
        {
            var bitArray = new BitArray(4 * 8, true);
            var bytes = new byte[4];
            bitArray.CopyTo(bytes, 0);

            var instance = sequenceFactory.FromBytes(bytes);
            Assert.NotNull(instance);

            Assert.Equal(PacketType.Response, instance.Type);
        }

        [Fact]
        public void ctorBytes_ByteArrayAllBitsFalse_TypeRequest()
        {
            var bitArray = new BitArray(4 * 8, false);
            var bytes = new byte[4];
            bitArray.CopyTo(bytes, 0);

            var instance = sequenceFactory.FromBytes(bytes);
            Assert.NotNull(instance);

            Assert.Equal(PacketType.Request, instance.Type);
        }

        [Fact]
        public void ctorBytes_ByteArrayAllBitsFalse_OriginServer()
        {
            var bitArray = new BitArray(4 * 8, false);
            var bytes = new byte[4];
            bitArray.CopyTo(bytes, 0);

            var instance = sequenceFactory.FromBytes(bytes);
            Assert.NotNull(instance);

            Assert.Equal(PacketOrigin.Server, instance.Origin);
        }

        [Fact]
        public void ctorBytes_ByteArrayAllBitsTrue_OriginClient()
        {
            var bitArray = new BitArray(4 * 8, true);
            var bytes = new byte[4];
            bitArray.CopyTo(bytes, 0);

            var instance = sequenceFactory.FromBytes(bytes);
            Assert.NotNull(instance);

            Assert.Equal(PacketOrigin.Client, instance.Origin);
        }

        #endregion
    }
}
