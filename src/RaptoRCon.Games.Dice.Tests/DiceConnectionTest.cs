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
        #region CTOR

        [Fact]
        public void Ctor_InstanceImplementsIDiceConnection()
        {
            var socketMock = new Mock<ISocketClient>();
                var instance = new DiceConnection(socketMock.Object);
            Assert.IsAssignableFrom<IDiceConnection>(instance);
        }

        [Fact]
        public void Ctor_SocketNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new DiceConnection(null));
        }

        #endregion

        #region SendAsync()



        #endregion
    
        #region GetNextSequenceId()

        [Fact]
        public void GetNextSequenceId_NewGeneratedConnection_Returns1() 
        {
            var socketMock = new Mock<ISocketClient>();
            var diceConnection = new DiceConnection(socketMock.Object);

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
            var diceConnection = new DiceConnection(socketMock.Object);

            diceConnection.UpdateSequenceId(1234);
            var sequenceId = diceConnection.GetNextSequenceId();
            socketMock.VerifyAll();
            Assert.Equal(1235u, sequenceId);
        }

        #endregion
    }
}
