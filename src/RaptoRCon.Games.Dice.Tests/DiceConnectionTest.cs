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
            var socketMock = new Mock<ISocket>();
                var instance = new DiceConnection(socketMock.Object, (sender, args) => {});
            Assert.IsAssignableFrom<IDiceConnection>(instance);
        }

        [Fact]
        public void Ctor_SocketNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new DiceConnection(null, (sender, args) => { }));
        }

        #endregion

        #region SendAsync()



        #endregion
    
        #region GetNextSequenceId()

        [Fact]
        public async Task GetNextSequenceId_NewGeneratedConnection_Returns1() 
        {
            var socketMock = new Mock<ISocket>();
            var diceConnection = new DiceConnection(socketMock.Object);

            var sequenceId = await diceConnection.GetNextSequenceIdAsync();
            Assert.Equal(1u, sequenceId);
            socketMock.VerifyAll();
        }
        
        #endregion

        #region UpdateSequenceId()

        [Fact]
        public async Task UpdateSequenceId_1234_NextSequenceIdReturns1235() 
        {
            var socketMock = new Mock<ISocket>();
            var diceConnection = new DiceConnection(socketMock.Object);

            await diceConnection.UpdateSequenceIdAsync(1234);
            var sequenceId = await diceConnection.GetNextSequenceIdAsync();
            socketMock.VerifyAll();
            Assert.Equal(1235u, sequenceId);
        }

        #endregion
    }
}
