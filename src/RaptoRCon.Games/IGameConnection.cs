using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games
{
    public interface IGameConnection
    {
        Task ConnectAsync(string hostname, int port);
        Task DisconnectAsync();
        Task SendAsync(IGameCommand command);

        event EventHandler<GameDataEventArgs> GameDataSent;
        event EventHandler<GameDataEventArgs> GameDataReceived;

        event EventHandler<GameConnectionEventArgs> ConnectionCreated;
        event EventHandler<GameConnectionEventArgs> ConnectionClosed;
    }
}
