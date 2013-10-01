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

            var packetSequence = new DicePacketSequence(id, type, origin);

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

            var packetSequence = new DicePacketSequence(id, type, origin);

            Assert.IsAssignableFrom<IDicePacketSequence>(packetSequence);
        }

        [Fact]
        public void ctorParameter_Id1073741823_ReturnsInstance()
        {
            var id = 1073741823u;
            var packetSequence = new DicePacketSequence(id, PacketType.Request, PacketOrigin.Client);

            Assert.Equal(id, packetSequence.Id);
        }

        [Fact]
        public void ctorParameter_Id1073741824_ReturnsInstance()
        {
            var id = 1073741824u;
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new DicePacketSequence(id, PacketType.Request, PacketOrigin.Client));
        }
        
        #endregion

        #region ToBytes()

        [Fact]
        public void ToBytes_NewSequence_BytesLength4()
        {
            var sequence = new DicePacketSequence(1u, PacketType.Request, PacketOrigin.Client);

            var bytes = sequence.ToBytes();
            
            Assert.Equal(4, bytes.Count());
        }

        [Fact]
        public void ToBytes_PacketRequestClient1_Equals()
        {
            var expectedBytes = Convert.FromBase64String("AQAAgA==");
            var sequence = new DicePacketSequence(1u, PacketType.Request, PacketOrigin.Client);

            var bytes = sequence.ToBytes();
            Assert.Equal(expectedBytes, bytes);
        }

        [Fact]
        public void ToBytes_PacketRequestClient1073741823_Equals()
        {
            var expectedBytes = Convert.FromBase64String("////vw==");
            var sequence = new DicePacketSequence(1073741823u, PacketType.Request, PacketOrigin.Client);

            var bytes = sequence.ToBytes();
            Assert.Equal(expectedBytes, bytes);
        }

        #endregion

        #region Equals() 

        [Fact]
        public void Equals_Sequence123ClientRequest_True()
        {
            var sequence = new DicePacketSequence(123, PacketType.Request, PacketOrigin.Client);
            var sequence2 = new DicePacketSequence(123, PacketType.Request, PacketOrigin.Client);
            Assert.Equal(sequence, sequence2);
        }

        [Fact]
        public void Equals_StringTest_NotEqual()
        {
            var sequence = new DicePacketSequence(123, PacketType.Request, PacketOrigin.Client);
            Assert.False(Equals(sequence, "Test"));
        }

        [Fact]
        public void Equals_DifferentPackets_False()
        {
            var sequence = new DicePacketSequence(123, PacketType.Request, PacketOrigin.Client);
            var sequence2 = new DicePacketSequence(124, PacketType.Request, PacketOrigin.Client);
            Assert.False(Equals(sequence, sequence2));
        }

        [Fact]
        public void Equals_OneSequenceNull_False()
        {
            var sequence = new DicePacketSequence(123, PacketType.Request, PacketOrigin.Client);
            Assert.False(Equals(sequence, null));
        }

        #endregion

        #region GetHashCode()

        [Fact]
        public void GetHashCode_WithSameInstance_IsEqual()
        {
            var instance = new DicePacketSequence(123, PacketType.Request, PacketOrigin.Client);
            Assert.Equal(instance.GetHashCode(), instance.GetHashCode());
        }

        #endregion
    }
}