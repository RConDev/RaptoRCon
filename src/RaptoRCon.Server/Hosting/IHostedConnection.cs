using RaptoRCon.Games;
using RaptoRCon.Games.Dice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        System.Guid Id { get; }

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



        
    }
}
