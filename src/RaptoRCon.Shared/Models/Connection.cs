using System;

namespace RaptoRCon.Shared.Models
{
    public class Connection
    {
        public Guid Id { get; set; }

        public string HostName { get; set; }

        public int Port { get; set; }

        public ConnectionState State { get; set; }
    }
}