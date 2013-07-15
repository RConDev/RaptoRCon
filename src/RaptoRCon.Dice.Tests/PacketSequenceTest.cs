﻿using System;
using System.Collections;
using System.Linq;
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
        public void ctorParameter_Id1073741823_ReturnsInstance()
        {
            var id = 1073741823u;
            var packetSequence = new PacketSequence(id, PacketType.Request, PacketOrigin.Client);

            Assert.Equal(id, packetSequence.Id);
        }

        [Fact]
        public void ctorParameter_Id1073741824_ReturnsInstance()
        {
            var id = 1073741824u;
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new PacketSequence(id, PacketType.Request, PacketOrigin.Client));
        }

        #endregion

        #region ToBytes()

        [Fact]
        public void ToBytes_NewSequence_BytesLength4()
        {
            var sequence = new PacketSequence(1u, PacketType.Request, PacketOrigin.Client);

            var bytes = sequence.ToBytes();
            
            Assert.Equal(4, bytes.Count());
        }

        [Fact]
        public void ToBytes_PacketRequestClient1_Equals()
        {
            var expectedBytes = Convert.FromBase64String("AQAAgA==");
            var sequence = new PacketSequence(1u, PacketType.Request, PacketOrigin.Client);

            var bytes = sequence.ToBytes();
            Assert.Equal(expectedBytes, bytes);
        }

        [Fact]
        public void ToBytes_PacketRequestClient1073741823_Equals()
        {
            var expectedBytes = Convert.FromBase64String("////vw==");
            var sequence = new PacketSequence(1073741823u, PacketType.Request, PacketOrigin.Client);

            var bytes = sequence.ToBytes();
            Assert.Equal(expectedBytes, bytes);
        }

        #endregion

        #region Equals() 

        [Fact]
        public void Equals_Sequence123ClientRequest_True()
        {
            var sequence = new PacketSequence(123, PacketType.Request, PacketOrigin.Client);
            var sequence2 = new PacketSequence(123, PacketType.Request, PacketOrigin.Client);
            Assert.Equal(sequence, sequence2);
        }

        #endregion
    }
}
