using System;

namespace RaptoRCon.Shared.Models
{
    public class ConnectionCreated
    {
        public Connection Connection { get; set; }

        public DateTime Created { get; set; }

        public ConnectionCreated(Connection connection)
        {
            this.Connection = connection;
            this.Created = DateTime.UtcNow;
        }
    }
}
