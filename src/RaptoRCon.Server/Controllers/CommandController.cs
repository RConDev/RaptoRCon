using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using RaptoRCon.Dice;
using RaptoRCon.Server.Config;
using RaptoRCon.Shared.Models;
using RaptoRCon.Sockets;
using System.ComponentModel.Composition;
using RaptoRCon.Server.Hosting;
using Microsoft.AspNet.SignalR.Client;
using System.Text;
using System.Linq;
using RaptoRCon.Dice.Factories;

namespace RaptoRCon.Server.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CommandController : RaptoRConApiControllerBase
    {
        [ImportingConstructor]
        public CommandController(IConnectionHost connectionHost ) : base(connectionHost)
        {
        }

        public async Task<CommandResult> Post(Command command)
        {
            var connection = GetHostedConnection(command.ConnectionId);

            var commandString = new DiceCommandString(command.CommandString);
            var packet = new DicePacket(new DicePacketSequence(123, PacketType.Request, PacketOrigin.Client), commandString.ToWords());
            var tmp = await connection.Connection.Socket.SendAsync(new SocketData(packet.ToBytes()));

            return new CommandResult();
        }


    }
}
