using Moq;
using System.Threading.Tasks;
using RaptoRCon.Shared.Models;
using Xunit;

namespace RaptoRCon.Games.Dice.Battlefield4.Tests
{
    public class GameConnectionTest
    {
        #region Ctor

        [Fact]
        public void Ctor_IDiceConnectionMock_DiceConnectionIDiceConnectionMock()
        {
            var diceConnection = new Mock<IDiceConnection>().Object;
            var instance = new GameConnection(diceConnection);
            Assert.Equal(diceConnection, instance.DiceConnection);
        }

        [Fact]
        public void Ctor_IDiceConnectionMock_StateNotConnected()
        {
            var diceConnection = new Mock<IDiceConnection>().Object;
            var instance = new GameConnection(diceConnection);
            Assert.Equal(ConnectionState.NotConnected, instance.State);
        }

        #endregion

        #region SendAsync()

        [Fact]
        public async Task SendAsync_IGameCommand_EventGameDataSentIsInvoked()
        {
            var diceConnectionMock = new Mock<IDiceConnection>();
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
            diceConnectionMock.Setup(mock => mock.GetNextSequenceId()).Returns(123u);
            var diceConnection = diceConnectionMock.Object;

            var instance = new GameConnection(diceConnection);
            await instance.SendAsync(new GameCommand() { Command = "listPlayers all" });

            diceConnectionMock.VerifyAll();
        }

        #endregion

        #region ConnectAsync()

        [Fact]
        public async Task ConnectAsync_CallsIDiceConnectionConnectAsync()
        {
            var diceConnectionMock = new Mock<IDiceConnection>();
            diceConnectionMock.Setup(x => x.ConnectAsync()).Returns(Task.FromResult<object>(null));
            diceConnectionMock.Setup(x => x.AuthenticateAsync()).Returns(Task.FromResult<object>(null));

            var gameConnection = new GameConnection(diceConnectionMock.Object);
            await gameConnection.ConnectAsync();

            diceConnectionMock.VerifyAll();
        }

        [Fact]
        public async Task ConnectAsync_StateConnected()
        {
            var diceConnectionMock = new Mock<IDiceConnection>();
            diceConnectionMock.Setup(x => x.ConnectAsync()).Returns(Task.FromResult<object>(null));
            diceConnectionMock.Setup(x => x.AuthenticateAsync()).Returns(Task.FromResult<object>(null));

            var gameConnection = new GameConnection(diceConnectionMock.Object);
            await gameConnection.ConnectAsync();

            Assert.Equal(ConnectionState.Connected, gameConnection.State);

            diceConnectionMock.VerifyAll();
        }

        #endregion

        #region DisconnectAsync()

        [Fact]
        public async Task DisconnectAsync_CallsIDiceConnectionDisconnectAsync()
        {
            var diceConnectionMock = new Mock<IDiceConnection>();
            diceConnectionMock.Setup(x => x.DisconnectAsync()).Returns(Task.FromResult<object>(null));

            var gameConnection = new GameConnection(diceConnectionMock.Object);
            await gameConnection.DisconnectAsync();

            diceConnectionMock.VerifyAll();
        }

        [Fact]
        public async Task DisconnectAsync_StateNotConnected()
        {
            var diceConnectionMock = new Mock<IDiceConnection>();
            var gameConnection = new GameConnection(diceConnectionMock.Object);
            diceConnectionMock.Setup(x => x.DisconnectAsync()).Returns(Task.FromResult<object>(null));
            await gameConnection.DisconnectAsync();
            Assert.Equal(ConnectionState.NotConnected, gameConnection.State);
        }

        #endregion

        #region Behaviour

        [Fact]
        public void Behaviour_DiceConnectionPacketReceived_GameDataReceivedIsInvoked()
        {
            var diceConnectionMock = new Mock<IDiceConnection>();
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
