using System;
using RaptoRCon.Sockets;
using System.Threading.Tasks;

namespace RaptoRCon.Server
{
    /// <summary>
    /// This interface describes the behavior of the server hosting the connections
    /// to the remote admin console and publishing the api available to control it.
    /// </summary>
    public interface IRaptoRConServer
    {
        /// <summary>
        /// Gets the <see cref="Uri"/> the server listens on for api commands
        /// </summary>
        Uri Endpoint { get; }

        /// <summary>
        /// Starts the <see cref="IRaptoRConServer"/> instance and initializes the endpoint 
        /// for publishing the api
        /// </summary>
        Task StartAsync();

        /// <summary>
        /// Stops the <see cref="IRaptoRConServer"/> instances and removes the api endpoint
        /// </summary>
        Task StopAsync();
    }
}