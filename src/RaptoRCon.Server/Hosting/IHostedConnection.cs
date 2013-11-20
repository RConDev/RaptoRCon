using RaptoRCon.Games;
using System;
using System.Threading.Tasks;
using RaptoRCon.Shared.Models;

namespace RaptoRCon.Server.Hosting
{
    /// <summary>
    /// A connection that is hosted in the <see cref="ConnectionHost"/>
    /// </summary>
    public interface IHostedConnection
    {
        /// <summary>
        /// Id for the connection in the <see cref="ConnectionHost"/>
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets the hostname of the connected game server
        /// </summary>
        string HostName { get; }

        /// <summary>
        /// Gets the port number of the connected game server
        /// </summary>
        int Port { get; }

        /// <summary>
        /// Gets the underlying connection used for communication
        /// </summary>
        IGameConnection Connection { get; }
        
        /// <summary>
        /// Establishes the underlying <see cref="IGameConnection"/> to the remote console
        /// </summary>
        /// <returns></returns>
        Task ConnectAsync();

        /// <summary>
        /// Releases the underlying <see cref="IGameConnection"/> to the remote console with the option to 
        /// reonnect
        /// </summary>
        /// <returns></returns>
        Task DisconnectAsync();
    }
}
