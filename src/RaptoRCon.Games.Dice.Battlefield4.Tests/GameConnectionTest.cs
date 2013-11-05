using AssertExLib;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using RaptoRCon.Tests;

namespace RaptoRCon.Games.Dice.Battlefield4.Tests
{
    public class GameConnectionTest
    {
        #region Creator

        [Fact]
        public void Ctor_IDiceConnectionMock_DiceConnectionIDiceConnectionMock()
        {
            var diceConnection = new Mock<IDiceConnection>().Object;
            var instance = new GameConnection(diceConnection);
            Assert.Equal(diceConnection, instance.DiceConnection);
        }

        #endregion

        #region SendAsync()

        [Fact]
        public async Task SendAsync_IGameCommand_EventGameDataSentIsInvoked()
        {
            var diceConnectionMock = new Mock<DiceConnection>();
            var diceConnection = diceConnectionMock.Object;
            diceConnectionMock.Setup(mock => mock.SendAsync(It.IsAny<IDicePacket>())).ReturnsAsync(123);

            var isCalled = false;
            var instance = new GameConnection(diceConnection);
            instance.GameDataSent +=
                (sender, e) =>
                {
                    isCalled = true;
                };

            var gameCommand = new GameCommand() { Command="myCommand"};
            await instance.SendAsync(gameCommand);

            Assert.True(isCalled);
        }

        [Fact]
        public async Task SendAsync_IGameCommand_IDiceConnectionSendAsyncPacket() 
        {
            var diceConnectionMock = new Mock<IDiceConnection>();
            diceConnectionMock.Setup(mock => mock.SendAsync(It.IsAny<IDicePacket>())).ReturnsAsync(123);
            diceConnectionMock.Setup(mock => mock.GetNextSequenceId()).ReturnsAsync(123u);
            var diceConnection = diceConnectionMock.Object;

            var isCalled = false;
            var instance = new GameConnection(diceConnection);
            await instance.SendAsync(new GameCommand() { Command = "listPlayers all" });

            diceConnectionMock.VerifyAll();
        }

        #endregion

        #region Behaviour

        [Fact]
        public void Behaviour_DiceConnectionPacketReceived_GameDataReceivedIsInvoked()
        {
            var diceConnectionMock = new Mock<DiceConnection>();
            var diceConnection = diceConnectionMock.Object;

            var isCalled = false;
            var instance = new GameConnection(diceConnection);
            instance.GameDataReceived += (sender, e) =>
            {
                isCalled = true;
            };

            var dicePacket = new Mock<IDicePacket>().Object;
            diceConnectionMock.Raise(mock => mock.PacketReceived += null, new DicePacketEventArgs(dicePacket));

            Assert.True(isCalled);
        }
        
        #endregion
    }
}
