using RaptoRCon.Dice;
using RaptoRCon.Server.Hosting.Exceptions;
using RaptoRCon.Sockets;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Server.Hosting
{
    [Export]
    public class ConnectionHost
    {
        ////public IDiceConnection Socket { get; set; }

        private IList<IHostedConnection> connections = new List<IHostedConnection>();

        /// <summary>
        /// Gets all <see cref="IHostedConnection"/> instances hosted within the <see cref="ConnectionHost"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IHostedConnection> Get()
        {
            return connections.AsEnumerable<IHostedConnection>();
        }

        public void Add(IHostedConnection hostedConnection)
        {
            if (connections.Any(x => x.Id == hostedConnection.Id))
            {
                throw new ConnectionAlreadyAddedException();
            }

            connections.Add(hostedConnection);
        }

        public IHostedConnection Get(Guid id)
        {
            var connection = connections.SingleOrDefault(x => x.Id == id);
            if (connection == null)
            {
                throw new UnknownConnectionIdException();
            }

            return connection;
        }
    }
}
