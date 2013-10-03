using System;

namespace RaptoRCon.Shared.Models
{
    public class ConnectionCreated
    {
        public Guid ConnectionId { get; set; }

        public Connection Connection { get; set; }

        public DateTime Created { get; set; }

        public ConnectionCreated(Guid id, Connection connection)
        {
            this.ConnectionId = id;
            this.Connection = connection;
            this.Created = DateTime.UtcNow;
        }
    }
}
