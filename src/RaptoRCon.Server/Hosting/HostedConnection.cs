﻿using RaptoRCon.Games;
using RaptoRCon.Games.Dice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RaptoRCon.Server.Hosting
{
    /// <summary>
    /// Implementation of <see cref="IHostedConnection"/>
    /// </summary>
    public class HostedConnection : IHostedConnection
    {
        public System.Guid Id { get; private set; }

        public string HostName { get; private set; }

        public int Port { get; private set; }

        public IGameConnection Connection { get; private set; }
       
        /// <summary>
        /// Creates a new <see cref="HostedConnection"/> instance
        /// </summary>
        /// <param name="diceConnection"></param>
        public HostedConnection(string hostName, int port, IGameConnection diceConnection)
        {
            Id = Guid.NewGuid();
            this.HostName = hostName;
            this.Port = port;
            this.Connection = diceConnection;
        }

        /// <summary>
        /// Establishes the underlying <see cref="IGameConnection"/> to the remote console
        /// </summary>
        /// <returns></returns>
        public async Task ConnectAsync()
        {
            await Connection.ConnectAsync();
        }

        /// <summary>
        /// Releases the underlying <see cref="IGameConnection"/> to the remote console with the option to 
        /// reonnect
        /// </summary>
        /// <returns></returns>
        public async Task DisconnectAsync()
        {
            await Connection.DisconnectAsync();
        }
    }
}
