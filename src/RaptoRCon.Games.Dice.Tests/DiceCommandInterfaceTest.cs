using System;
using System.Threading;
using System.Threading.Tasks;
using AssertExLib;
using Moq;
using RaptoRCon.Games.Dice.Commands;
using Xunit;

namespace RaptoRCon.Games.Dice.Tests
{
    public class DiceCommandInterfaceTest
    {
        [Fact]
        public void Ctor_Null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new DiceCommandInterface(null));
        }

        [Fact]
        public void Ctor_Null_ThrowsArgumentNullExceptionParamNameConnection()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new DiceCommandInterface(null));
            Assert.Equal("connection", exception.ParamName);
        }

        [Fact]
        public void Ctor_ConnectionMock_ConnectionIsSetWithMock()
        {
            var diceConnectionMock = new Mock<IDiceConnection>();
            var connection = diceConnectionMock.Object;

            var commandInterface = new DiceCommandInterface(connection);

            Assert.Equal(connection, commandInterface.Connection);
        }

        [Fact]
        public void ExecuteAsync_Null_ThrowsArgumentNullException()
        {
            var connectionMock = new Mock<IDiceConnection>();
            var commandInterface = new DiceCommandInterface(connectionMock.Object);

            AssertEx.TaskThrows<ArgumentNullException>(async () =>  await commandInterface.ExecuteAsync(null));
        }

        [Fact]
        public void ExecuteAsync_Null_ThrowsArgumentNullExceptionParamNameCommand()
        {
            var connectionMock = new Mock<IDiceConnection>();
            var commandInterface = new DiceCommandInterface(connectionMock.Object);

            var exception = AssertEx.TaskThrows<ArgumentNullException>(async () => await commandInterface.ExecuteAsync(null));
            Assert.Equal("command", exception.ParamName);
        }

        [Fact]
        public async Task ExecuteAsync_WithCommand_ReturnsResponse()
        {
            var connectionMock = new Mock<IDiceConnection>();
            connectionMock.Setup(x => x.GetNextSequenceId()).Returns(1);

            var responseWords = new[] {new DiceWord("OK"), new DiceWord("F3ED3412") };

            connectionMock.Setup(x => x.SendAsync(It.IsAny<IDicePacket>()))
                .Callback(() => Thread.Sleep(1000))
                .ReturnsAsync(15)
                .Raises(x => x.PacketReceived += null,
                    new DicePacketEventArgs(
                        new DicePacket(
                            new DicePacketSequence(1, PacketType.Response, Origin.Client), responseWords)));

            var commandInterface = new DiceCommandInterface(connectionMock.Object);

            var response = await commandInterface.ExecuteAsync(new LoginHashedCommand());
            Assert.NotNull(response);
            Assert.Equal(responseWords, response.Packet.Words);
        }
    }
}
