using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaptoRCon.Sockets;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// This interface describes the connection made to a remote console interface
    /// supporting the DICE protocol
    /// </summary>
    public interface IDiceConnection
    {
        /// <summary>
        /// Gets the name / ip address of the remote host the remote console is running on
        /// </summary>
        string HostName { get; }

        /// <summary>
        /// Gets the port number the remote console listens on for new connections
        /// </summary>
        int Port { get; }

        /// <summary>
        /// This event is invoked, when a <see cref="IDicePacket"/> is received from the RCon interface
        /// </summary>
        event EventHandler<DicePacketEventArgs> PacketReceived;

        /// <summary>
        /// Gets the underlying <see cref="ISocket"/> used to communicate with the RCon interface
        /// </summary>
        ISocketClient SocketClient { get; }

        /// <summary>
        /// Establishes the connection to the remote host asynchronously
        /// </summary>
        /// <returns></returns>
        Task ConnectAsync();

        /// <summary>
        /// Releases the connection to the remote host asynchronously with the option to 
        /// reconnect
        /// </summary>
        /// <returns></returns>
        Task DisconnectAsync();

        /// <summary>
        /// Sends a DICE <see cref="IDicePacket"/> to the RCon interface
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        Task<int> SendAsync(IDicePacket packet);

        /// <summary>
        /// Returns the next valid SequenceId within the <see cref="IDicePacketSequence"/> instance 
        /// used in <see cref="IDicePacket"/> communication
        /// </summary>
        /// <returns></returns>
        uint GetNextSequenceId();
    }
}
