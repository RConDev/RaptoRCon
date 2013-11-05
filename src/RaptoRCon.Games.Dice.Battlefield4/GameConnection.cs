using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaptoRCon.Shared.Util;

namespace RaptoRCon.Games.Dice.Battlefield4
{
    public class GameConnection : IGameConnection
    {
        public IDiceConnection DiceConnection { get; private set; }

        public GameConnection(IDiceConnection diceConnection)
        {
            this.DiceConnection = diceConnection;
            diceConnection.PacketReceived +=
                (sender, e) =>
                {
                    var gameData = new GameData();
                    var eventArgs = new GameDataEventArgs(gameData);
                    OnGameDataReceived(eventArgs);
                };
        }

        

        public Task ConnectAsync()
        {
            throw new NotImplementedException();
        }

        public Task DisconnectAsync()
        {
            throw new NotImplementedException();
        }

        public async Task SendAsync(IGameCommand command)
        {
            var commandString = new DiceCommandString(command.Command);
            var packetSequenceId = await DiceConnection.GetNextSequenceId();
            var commandStringWords = commandString.ToWords();

            var packet = new DicePacket(new DicePacketSequence(packetSequenceId, PacketType.Request, PacketOrigin.Client), commandStringWords);
            await this.DiceConnection.SendAsync(packet);

            var eventArgs = new GameDataEventArgs(new GameData() { DataString = packet.ToString() });
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

        #region Events

        public virtual event EventHandler<GameDataEventArgs> GameDataSent;

        public virtual event EventHandler<GameDataEventArgs> GameDataReceived;

        public virtual event EventHandler<GameConnectionEventArgs> ConnectionCreated;

        public virtual event EventHandler<GameConnectionEventArgs> ConnectionClosed;

        #endregion
    }
}
