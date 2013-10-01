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

namespace RaptoRCon.Server.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CommandController : ApiController
    {
        private readonly ConnectionHost host;

        [ImportingConstructor]
        public CommandController(ConnectionHost host)
        {
            this.host = host;
        }

        public async Task<CommandResult> Post(Command command)
        {
            if (host.Socket == null)
            {
                var message = new ExceptionMessage(){Code = 100, Message = "The connetion expected was not available."};
                var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                                          {
                                              Content =
                                                  new ObjectContent(typeof (ExceptionMessage), message,
                                                                    new JsonMediaTypeFormatter())
                                          };
                throw new HttpResponseException(responseMessage);
            }

            var packet = new DicePacket(new DicePacketSequence(123, PacketType.Request, PacketOrigin.Client), new List<IDiceWord> {new DiceWord(command.CommandString)});
            var tmp = await host.Socket.SendAsync(new SocketData(packet.ToBytes()));

            return new CommandResult();
        }

    }
}
