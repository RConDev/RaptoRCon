using Moq;
using RaptoRCon.Sockets;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace RaptoRCon.Games.Dice.Tests
{
    [ExcludeFromCodeCoverage]
    public class DiceConnectionTest
    {
        private readonly Mock<ISocketClient> socketMock;

        public DiceConnectionTest()
        {
            socketMock = new Mock<ISocketClient>();
        }

        #region CTOR

        [Fact]
        public void Ctor_InstanceImplementsIDiceConnection()
        {
            var instance = new DiceConnection("myhost", 12345, "myPassword", socketMock.Object);
            Assert.IsAssignableFrom<IDiceConnection>(instance);
        }

        [Fact]
        public void Ctor_SocketNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new DiceConnection("myhost", 12345, "myPassword", null));
        }

        [Fact]
        public void Ctor_HostnameNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new DiceConnection(null, 12345, "myPassword", socketMock.Object));
        }

        [Fact]
        public void Ctor_HostnameNull_ThrowsArgumentNullExceptionParamNameHostname()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new DiceConnection(null, 12345, "myPassword", socketMock.Object));
            Assert.Equal("hostname", exception.ParamName);
        }

        [Fact]
        public void Ctor_HostnameMyHost_HostNameMyHost()
        {
            var diceConnection = new DiceConnection("myhost", 12345, "myPassword", socketMock.Object);
            Assert.Equal("myhost", diceConnection.HostName);
        }
        
        [Fact]
        public void Ctor_Port12345_Port12345()
        {
            var diceConnection = new DiceConnection("myhost", 12345, "myPassword", socketMock.Object);
            Assert.Equal(12345, diceConnection.Port);
        }

        [Fact]
        public void Ctor_PasswordNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new DiceConnection("myhost", 12345,null, socketMock.Object));
        }

        [Fact]
        public void Ctor_PasswordNull_ThrowsArgumentNullExceptionParamNamePassword()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new DiceConnection("myhost", 12345, null, socketMock.Object));
            Assert.Equal("password", exception.ParamName);
        }

        #endregion

        #region SendAsync()



        #endregion
    
        #region GetNextSequenceId()

        [Fact]
        public void GetNextSequenceId_NewGeneratedConnection_Returns1() 
        {
            var socketMock = new Mock<ISocketClient>();
            var diceConnection = new DiceConnection("myhost", 12345, "myPassword", socketMock.Object);

            var sequenceId = diceConnection.GetNextSequenceId();
            Assert.Equal(1u, sequenceId);
            socketMock.VerifyAll();
        }
        
        #endregion

        #region UpdateSequenceId()

        [Fact]
        public void UpdateSequenceId_1234_NextSequenceIdReturns1235() 
        {
            var socketMock = new Mock<ISocketClient>();
            var diceConnection = new DiceConnection("myhost", 12345, "myPassword", socketMock.Object);

            diceConnection.UpdateSequenceId(1234);
            var sequenceId = diceConnection.GetNextSequenceId();
            socketMock.VerifyAll();
            Assert.Equal(1235u, sequenceId);
        }

        #endregion
    }
}
