using System;
namespace RaptoRCon.Shared.Models
{
    public class Command
    {
        public Guid ConnectionId { get; set; }

        public string CommandString { get; set; }
    }
}