﻿using AssertExLib;
using Moq;
using RaptoRCon.Sockets;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace RaptoRCon.Games.Dice.Factories
{
    [ExcludeFromCodeCoverage]
    public class DiceConnectionFactoryTest
    {
        private readonly Mock<ISocketClientFactory> socketFactoryMock;

        private DiceConnectionFactory connectionFactory;

        public DiceConnectionFactoryTest()
        {
            socketFactoryMock = new Mock<ISocketClientFactory>();
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
            Assert.IsType<SocketClientFactory>(instance.SocketClientFactory);
        }

        [Fact]
        public void Ctor_ISocketFactoryMock_PropertySocketFactoryDeliversDefault()
        {
            var socketFactoryMock = new Mock<ISocketClientFactory>();

            var instance = new DiceConnectionFactory(socketFactoryMock.Object);
            Assert.True(socketFactoryMock.Object.Equals(instance.SocketClientFactory));
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
            AssertEx.TaskThrows<ArgumentNullException>(() => connectionFactory.CreateAsync(null, 123, "myPassword"));
        }

        [Fact]
        public void Create_HostNameNull_ArgumentNullExceptionParamNameHostname()
        {
            var exception = AssertEx.TaskThrows<ArgumentNullException>(() => connectionFactory.CreateAsync(null, 123, "myPassword"));
            Assert.Equal("hostname", exception.ParamName);
        }

        [Fact]
        public void Create_PortNegative_ThrowsArgumentOutOfRangeException()
        {
            AssertEx.TaskThrows<ArgumentOutOfRangeException>(() => connectionFactory.CreateAsync("localhost", -1, "myPassword"));
        }

        [Fact]
        public void Create_PortNegative_ThrowsArgumentOutOfRangeExceptionParamNamePort()
        {
            var exception = AssertEx.TaskThrows<ArgumentOutOfRangeException>(() => connectionFactory.CreateAsync("localhost", -1, "myPassword"));
            Assert.Equal("port", exception.ParamName);
        }

        [Fact]
        public void Create_PortZero_ThrowsArgumentOutOfRangeException()
        {
            AssertEx.TaskThrows<ArgumentOutOfRangeException>(() => connectionFactory.CreateAsync("localhost", 0, "myPassword"));
        }

        [Fact]
        public void Create_PasswordNull_ThrowsArgumentNullException()
        {
            AssertEx.TaskThrows<ArgumentNullException>(() => connectionFactory.CreateAsync("localhost", 12345, null));
        }

        [Fact]
        public void Create_PasswordNull_ThrowsArgumentNullExceptionParamNamePassword()
        {
            var exception = AssertEx.TaskThrows<ArgumentNullException>(() => connectionFactory.CreateAsync("localhost", 12345, null));
            Assert.Equal("password", exception.ParamName);
        }

        [Fact]
        public async Task Create_HostnameLocalhostPort11000_ReturnsDiceConnectionWithCorrectSocket()
        {
            var socketMock = new Mock<ISocketClient>();
            var socket = socketMock.Object;
            socketFactoryMock
                .Setup(m => m.CreateAsync(
                    It.Is<string>(x => x == "localhost"), 
                    It.Is<int>(x => x == 11000)))
                .ReturnsAsync(socket);

            var connection = await connectionFactory.CreateAsync("localhost", 11000, "myPassword");
            
            Assert.Equal(socket, connection.SocketClient);
            socketFactoryMock.VerifyAll();
        }

        [Fact]
        public async Task CreateAsync_PasswordMyPassword_ReturnsDiceConnectionPasswordMyPassword()
        {
            var socketMock = new Mock<ISocketClient>();
            var socket = socketMock.Object;
            socketFactoryMock
                .Setup(m => m.CreateAsync(
                    It.Is<string>(x => x == "localhost"),
                    It.Is<int>(x => x == 11000)))
                .ReturnsAsync(socket);

            var connection = await connectionFactory.CreateAsync("localhost", 11000, "myPassword");
            Assert.Equal("myPassword", connection.Password);
        }

        #endregion
    }
}
