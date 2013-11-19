using System.Threading.Tasks;
using Common.Logging;

namespace RaptoRCon.Sockets
{
    /// <summary>
    /// Implementation of <see cref="ISocketClientFactory"/>
    /// </summary>
    public class SocketClientFactory : ISocketClientFactory
    {
        private static readonly ILog logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Creates a new <see cref="ISocket"/> instance connected to the stated remote host
        /// </summary>
        /// <param name="hostname">the domain name or ip-address of the remote host</param>
        /// <param name="port"></param>
        /// <returns></returns>
        public async Task<ISocketClient> CreateAsync(string hostname, int port)
        {
            logger.TraceFormat("CreateAsync({0}, {1})", hostname, port);
            return await
                Task.Factory
                    .StartNew(() =>
                              {
                                  var socket = new SocketClient(new Socket());

                                  logger.TraceFormat("CreateAsync({0}, {1}) returning {2}", hostname, port, socket);
                                  return socket;
                              });
            
        }
    }
}