using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RaptoRCon.Dice.Factories;
using RaptoRCon.Sockets;
using Xunit;
using AssertExLib;

namespace RaptoRCon.Dice.Tests.Factories
{
    public class DiceConnectionFactoryTest
    {
        private readonly Mock<ISocketFactory> socketFactoryMock;

        private DiceConnectionFactory connectionFactory;

        public DiceConnectionFactoryTest()
        {
            socketFactoryMock = new Mock<ISocketFactory>();
            connectionFactory = new DiceConnectionFactory(socketFactoryMock.Object);
        }

        #region CTOR

        [Fact]
        public void Ctor_None_ImplementsIDiceConnectionFactory()
        {
            var instance = new DiceConnectionFactory();
            Assert.IsAssignableFrom<IDiceConnectionFactory>(instance);
        }

        [Fact]
        public void Ctor_None_PropertySocketFactoryDeliversDefault()
        {
            var instance = new DiceConnectionFactory();
            Assert.IsType<SocketFactory>(instance.SocketFactory);
        }

        [Fact]
        public void Ctor_ISocketFactoryMock_PropertySocketFactoryDeliversDefault()
        {
            var socketFactoryMock = new Mock<ISocketFactory>();

            var instance = new DiceConnectionFactory(socketFactoryMock.Object);
            Assert.True(socketFactoryMock.Object.Equals(instance.SocketFactory));
        }

        [Fact]
        public void Ctor_null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new DiceConnectionFactory(null));
        }

        #endregion

        #region CreateAsync()

        [Fact]
        public void Create_HostNameNull_ThrowsArgumentNullException()
        {
            AssertEx.TaskThrows<ArgumentNullException>(() => connectionFactory.CreateAsync(null, 123));
        }

        [Fact]
        public void Create_HostNameNull_ArgumentNullExceptionParamNameHostname()
        {   
            var exception = AssertEx.TaskThrows<ArgumentNullException>(() => connectionFactory.CreateAsync(null, 123));
            Assert.Equal("hostname", exception.ParamName);
        }

        [Fact]
        public void Create_PortNegative_ThrowsArgumentOutOfRangeException()
        {
            AssertEx.TaskThrows<ArgumentOutOfRangeException>(() => connectionFactory.CreateAsync("localhost", -1));
        }

        [Fact]
        public void Create_PortNegative_ThrowsArgumentOutOfRangeExceptionParamNamePort()
        {
            var exception = AssertEx.TaskThrows<ArgumentOutOfRangeException>(() => connectionFactory.CreateAsync("localhost", -1));
            Assert.Equal("port", exception.ParamName);
        }

        [Fact]
        public void Create_PortZero_ThrowsArgumentOutOfRangeException()
        {
            AssertEx.TaskThrows<ArgumentOutOfRangeException>(() => connectionFactory.CreateAsync("localhost", 0));
        }

        #endregion
    }
}
