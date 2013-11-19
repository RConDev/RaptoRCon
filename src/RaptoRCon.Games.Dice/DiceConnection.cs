using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly object sequenceIdLock = new object();
        private uint sequenceId;

        /// <summary>
        /// This event is invoked, when a <see cref="IDicePacket"/> is received from the RCon interface
        /// </summary>
        public virtual event EventHandler<DicePacketEventArgs> PacketReceived;

        /// <summary>
        /// Gets the underlying <see cref="ISocket"/> used to communicate with the RCon interface
        /// </summary>
        public ISocketClient SocketClient { get; private set; }

        /// <summary>
        /// Creates a new <see cref="DiceConnection"/> instance
        /// </summary>
        /// <param name="socketClient"></param>
        public DiceConnection(ISocketClient socketClient)
        {
            #region Contracts
            if (socketClient == null)
            {
                throw new ArgumentNullException("socketClient");
            }
            #endregion

            SocketClient = socketClient;
            SocketClient.DataReceived += SocketOnDataReceived;
        }
        
        /// <summary>
        /// Establishes the connection to the remote host asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task ConnectAsync(string hostname, int port)
        {
            await this.SocketClient.ConnectAsync(hostname, port);
        }

        /// <summary>
        /// Sends a DICE <see cref="IDicePacket"/> to the RCon interface
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        public virtual async Task<int> SendAsync(IDicePacket packet)
        {
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