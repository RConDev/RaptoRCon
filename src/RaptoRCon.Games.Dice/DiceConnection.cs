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
        private uint sequenceId;
        
        /// <summary>
        /// Creates a new <see cref="DiceConnection"/> instance
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="packetReceivedHandler"></param>
        public DiceConnection(ISocket socket, EventHandler<DicePacketEventArgs> packetReceivedHandler = null)
        {
            #region Contracts
            if (socket == null)
            {
                throw new ArgumentNullException("socket");
            }
            #endregion

            Socket = socket;
            socket.DataReceived += SocketOnDataReceived;
            
            if (packetReceivedHandler != null)
            {
                PacketReceived += packetReceivedHandler;
            }
        }

        /// <summary>
        /// Gets the underlying <see cref="ISocket"/> used to communicate with the RCon interface
        /// </summary>
        public ISocket Socket { get; private set; }

        /// <summary>
        /// Sends a DICE <see cref="IDicePacket"/> to the RCon interface
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public async Task<int> SendAsync(IDicePacket packet)
        {
            return await this.Socket.SendAsync(new SocketData(packet.ToBytes()));
        }

        /// <summary>
        /// This event is invoked, when a <see cref="IDicePacket"/> is received from the RCon interface
        /// </summary>
        public event EventHandler<DicePacketEventArgs> PacketReceived;

        /// <summary>
        /// Returns the next valid <see cref="IDicePacketSequence.Id"/> within the <see cref="IDicePacketSequence"/> instance 
        /// used in <see cref="IDicePacket"/> communication for this connection
        /// </summary>
        /// <returns></returns>
        public Task<uint> GetNextSequenceId()
        {
            throw new NotImplementedException();
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
            foreach (var packet in packets)
            {
                await packetReceivedEventHandler.InvokeAllAsync(this, new DicePacketEventArgs(packet));
            }
        }

        #endregion
    }
}