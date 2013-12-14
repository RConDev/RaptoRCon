using RaptoRCon.Server.Hosting.Exceptions;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace RaptoRCon.Server.Hosting
{
    [Export(typeof(IConnectionHost))]
    public class ConnectionHost : IConnectionHost
    {
        private readonly ICollection<IHostedConnection> connections = new List<IHostedConnection>();

        /// <summary>
        /// Gets all <see cref="IHostedConnection"/> instances hosted within the <see cref="ConnectionHost"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IHostedConnection> Get()
        {
            return connections.AsEnumerable();
        }

        public void Add(IHostedConnection hostedConnection)
        {
            if (connections.Any(x => x.Id == hostedConnection.Id))
            {
                throw new ConnectionAlreadyAddedException();
            }

            connections.Add(hostedConnection);
        }

        public IHostedConnection Get(System.Guid id)
        {
            var connection = connections.SingleOrDefault(x => x.Id == id);
            if (connection == null)
            {
                throw new UnknownConnectionIdException();
            }

            return connection;
        }

        public bool Remove(IHostedConnection hostedConnection)
        {
            if (connections.Contains(hostedConnection))
            {
                connections.Remove(hostedConnection);
                return true;
            }

            return false;
        }
    }
}
