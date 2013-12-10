using System;
using System.Threading.Tasks;
using RaptoRCon.Shared.Models;
using RaptoRCon.Shared.Util;

namespace RaptoRCon.Games.Dice.Battlefield4
{
    /// <summary>
    /// The <see cref="IGameConnection"/> implementation for administrating the Battlefield 4 Game Server
    /// </summary>
    public class GameConnection : IGameConnection
    {
        #region Events

        public virtual event EventHandler<GameDataEventArgs> GameDataSent;

        public virtual event EventHandler<GameDataEventArgs> GameDataReceived;

        public virtual event EventHandler<GameConnectionEventArgs> ConnectionCreated;

        public virtual event EventHandler<GameConnectionEventArgs> ConnectionClosed;

        #endregion

        /// <summary>
        /// Gets the underlying <see cref="IDiceConnection"/>
        /// </summary>
        public IDiceConnection DiceConnection { get; private set; }

        /// <summary>
        /// Gets the curren state of the <see cref="IGameConnection"/>
        /// </summary>
        public ConnectionState State { get; private set; }

        /// <summary>
        /// Creates a new <see cref="GameConnection"/> instance
        /// </summary>
        /// <param name="diceConnection"></param>
        public GameConnection(IDiceConnection diceConnection)
        {
            this.State = ConnectionState.NotConnected;
            this.DiceConnection = diceConnection;
            diceConnection.PacketReceived +=
                (sender, e) =>
                {
                    var gameData = new GameData() { DataString = e.Packet.ToString()};
                    var eventArgs = new GameDataEventArgs(gameData);
                    OnGameDataReceived(eventArgs);
                };
        }

        public async Task ConnectAsync()
        {
            await DiceConnection.ConnectAsync();
            State = ConnectionState.Connected;
            await DiceConnection.AuthenticateAsync();
        }

        public async Task DisconnectAsync()
        {
            await DiceConnection.DisconnectAsync();
            State = ConnectionState.NotConnected;
        }

        public async Task SendAsync(IGameCommand command)
        {
            var commandString = new DiceCommandString(command.Command);
            var packetSequenceId = DiceConnection.GetNextSequenceId();
            var commandStringWords = commandString.ToWords();

            var packet = new DicePacket(new DicePacketSequence(packetSequenceId, PacketType.Request, Origin.Client), commandStringWords);
            await this.DiceConnection.SendAsync(packet);

            var eventArgs = new GameDataEventArgs(new GameData { DataString = packet.ToString() });
            this.OnGameDataSent(eventArgs);
        }

        #region Invoke Events

        protected void OnGameDataReceived(GameDataEventArgs eventArgs)
        {
            var eventHandler = this.GameDataReceived;
            if (eventHandler == null) return;

            eventHandler.InvokeAll(this, eventArgs);
        }

        protected void OnGameDataSent(GameDataEventArgs eventArgs)
        {
            var eventHandler = this.GameDataSent;
            if (eventHandler == null) return;

            this.GameDataSent.InvokeAll(this, eventArgs);
        }

        #endregion
    }
}
