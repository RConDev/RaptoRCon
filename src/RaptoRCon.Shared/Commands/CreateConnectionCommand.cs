using System;

namespace RaptoRCon.Shared.Commands
{
    public class CreateConnectionCommand
    {
        public Guid GameId { get; set; }

        public string HostName { get; set; }

        public int Port { get; set; }

        public string Password { get; set; }
    }
}
