using System;
using System.Threading.Tasks;
using Common.Logging;
using RaptoRCon.Sockets;
using RaptoRCon.Games.Dice.Factories;
using RaptoRCon.Shared.Util;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// Implementation of <see cref="IDiceConnection"/>
    /// </summary>
    public class DiceConnection : IDiceConnection
    {
        private static readonly ILog logger = LogManager.GetCurrentClassLogger();
        private readonly object sequenceIdLock = new object();
        private uint sequenceId;

        /// <summary>
        /// This event is invoked, when a <see cref="IDicePacket"/> is received from the RCon interface
        /// </summary>
        public virtual event EventHandler<DicePacketEventArgs> PacketReceived;

        /// <summary>
        /// Gets the name / ip address of the remote host the remote console is running on
        /// </summary>
        public string HostName { get; private set; }

        /// <summary>
        /// Gets the port number the remote console listens on for new connections
        /// </summary>
        public int Port { get; private set; }

        /// <summary>
        /// Gets the underlying <see cref="ISocket"/> used to communicate with the RCon interface
        /// </summary>
        public ISocketClient SocketClient { get; private set; }

        /// <summary>
        /// Gets the Admin's password to gain admin's priviledges
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Creates a new <see cref="DiceConnection"/> instance
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <param name="password"></param>
        /// <param name="socketClient"></param>
        public DiceConnection(string hostname, int port, string password, ISocketClient socketClient)
        {
            logger.TraceFormat("Creating new {0} instance", GetType());
            
            #region Contracts
            if (hostname == null)
            {
                throw new ArgumentNullException("hostname");
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            if (socketClient == null)
            {
                throw new ArgumentNullException("socketClient");
            }
            #endregion

            HostName = hostname;
            Port = port;
            Password = password;
            SocketClient = socketClient;
            SocketClient.DataReceived += SocketOnDataReceived;
            
            logger.TraceFormat("New {0} instance created", this.GetType());
        }
        
        /// <summary>
        /// Establishes the connection to the remote host asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task ConnectAsync()
        {
            await SocketClient.ConnectAsync(HostName, Port);
        }

        /// <summary>
        /// Releases the connection to the remote host asynchronously with the option to 
        /// reconnect
        /// </summary>
        /// <returns></returns>
        public async Task DisconnectAsync()
        {
            logger.DebugFormat("Disconnecting from {0}:{1}", HostName, Port);
            await SocketClient.DisconnectAsync(true);
            logger.DebugFormat("Disconnected from {0}:{1}", HostName, Port);
        }

        /// <summary>
        /// Sends a DICE <see cref="IDicePacket"/> to the RCon interface
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        public virtual async Task<int> SendAsync(IDicePacket packet)
        {
            logger.DebugFormat("Sending Packet '{0}'", packet);
            return await this.SocketClient.SendAsync(new SocketData(packet.ToBytes()));
        }

        /// <summary>
        /// Returns the next valid <see cref="IDicePacketSequence.Id"/> within the <see cref="IDicePacketSequence"/> instance 
        /// used in <see cref="IDicePacket"/> communication for this connection
        /// </summary>
        /// <returns></returns>
        public uint GetNextSequenceId()
        {
            lock (sequenceIdLock)
            {
                return Convert.ToUInt32(++this.sequenceId);
            }
        }

        public void UpdateSequenceId(uint newSequenceId)
        {
            lock (sequenceIdLock)
            {
                this.sequenceId = newSequenceId;
            }
        }

        #region Event Handler

        private async void SocketOnDataReceived(object sender, SocketDataReceivedEventArgs socketDataReceivedEventArgs)
        {
            var packetReceivedEventHandler = this.PacketReceived;
            if (packetReceivedEventHandler == null)
            {
                return;
            }

            var packetFactory = new DicePacketFactory();
            var packets = packetFactory.FromBytes(socketDataReceivedEventArgs.DataReceived);
            var maxSequenceId = this.sequenceId;
            foreach (var packet in packets)
            {
                maxSequenceId = packet.Sequence.Id > maxSequenceId ? packet.Sequence.Id : maxSequenceId;
                await packetReceivedEventHandler.InvokeAllAsync(this, new DicePacketEventArgs(packet));
            }

            this.UpdateSequenceId(maxSequenceId);
        }

        #endregion
    }
}