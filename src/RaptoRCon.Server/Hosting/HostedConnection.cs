using RaptoRCon.Dice;
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
        public Guid Id { get; private set; }

        public string HostName { get; private set; }

        public int Port { get; private set; }

        public IDiceConnection Connection { get; private set; }

        /// <summary>
        /// Creates a new <see cref="HostedConnection"/> instance
        /// </summary>
        /// <param name="diceConnection"></param>
        public HostedConnection(string hostName, int port, IDiceConnection diceConnection)
        {
            this.Id = Guid.NewGuid();
            this.HostName = hostName;
            this.Port = port;
            this.Connection = diceConnection;
        }
    }
}
