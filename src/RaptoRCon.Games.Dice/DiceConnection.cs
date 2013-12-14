using System;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Common.Logging;
using RaptoRCon.Games.Dice.Commands;
using RaptoRCon.Games.Dice.Utils;
using RaptoRCon.Sockets;
using RaptoRCon.Games.Dice.Factories;
using RaptoRCon.Shared.Util;
using Seterlund.CodeGuard;

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
            
            Guard.That(() => hostname).IsNotNull();
            Guard.That(() => password).IsNotNull();
            Guard.That(() => socketClient).IsNotNull();

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
            return await SocketClient.SendAsync(new SocketData(packet.ToBytes()));
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

        /// <summary>
        /// Authenticates the current connection with the password delivered
        /// </summary>
        public async Task AuthenticateAsync()
        {
            using (var commandInterface = GetCommandInterface())
            {
                var saltHexString =
                    new HexString(
                        (await commandInterface.ExecuteAsync(new LoginHashedCommand())).Packet.Words.Skip(1)
                            .FirstOrDefault()
                            .Content);

                var passwordHash = HashUtil.GeneratePasswordHash(saltHexString, Password);
                var response = await commandInterface.ExecuteAsync(new LoginHashedCommand(passwordHash));

                if (response.Packet.Words.First().Content != "OK")
                {
                    throw new AuthenticationException("Authentication failed");
                }
            }
        }

        /// <summary>
        /// Gets a new <see cref="IDiceCommandInterface"/> instance implementing <see cref="IDisposable"/>
        /// </summary>
        /// <returns></returns>
        public IDiceCommandInterface GetCommandInterface()
        {
            return new DiceCommandInterface(this);
        }

        public void UpdateSequenceId(uint newSequenceId)
        {
            lock (sequenceIdLock)
            {
                sequenceId = newSequenceId;
            }
        }

        private async void SocketOnDataReceived(object sender, SocketDataReceivedEventArgs socketDataReceivedEventArgs)
        {
            var packetReceivedEventHandler = this.PacketReceived;
            if (packetReceivedEventHandler == null)
            {
                return;
            }

            var packetFactory = new DicePacketFactory();
            var packets = packetFactory.FromBytes(socketDataReceivedEventArgs.DataReceived);
            var maxSequenceId = sequenceId;
            foreach (var packet in packets)
            {
                maxSequenceId = packet.Sequence.Id > maxSequenceId ? packet.Sequence.Id : maxSequenceId;
                await packetReceivedEventHandler.InvokeAllAsync(this, new DicePacketEventArgs(packet));
            }

            UpdateSequenceId(maxSequenceId);
        }
   }
}