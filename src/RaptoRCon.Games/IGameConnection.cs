using System;
using System.Threading.Tasks;
using RaptoRCon.Shared.Models;

namespace RaptoRCon.Games
{
    public interface IGameConnection
    {
        Task ConnectAsync();
        Task DisconnectAsync();
        Task SendAsync(IGameCommand command);

        /// <summary>
        /// Gets the curren state of the <see cref="IGameConnection"/>
        /// </summary>
        ConnectionState State { get; }

        event EventHandler<GameDataEventArgs> GameDataSent;
        event EventHandler<GameDataEventArgs> GameDataReceived;

        event EventHandler<GameConnectionEventArgs> ConnectionCreated;
        event EventHandler<GameConnectionEventArgs> ConnectionClosed;
    }
}
