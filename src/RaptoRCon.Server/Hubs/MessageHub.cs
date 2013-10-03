using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Server.Hubs
{
    public class MessageHub : Hub
    {
        public void SendMessage(Guid connectionId, string message)
        {
            Clients.All.sendMessage(connectionId, message);
        }
    }
}
