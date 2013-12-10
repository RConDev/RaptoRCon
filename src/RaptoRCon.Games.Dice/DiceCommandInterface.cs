using System;
using System.Threading.Tasks;
using RaptoRCon.Games.Dice.Commands;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// Manages sending <see cref="IDiceCommand"/>s to the underlying <see cref="IDiceConnection"/> with directly receiving
    /// the responses
    /// </summary>
    public class DiceCommandInterface : IDiceCommandInterface
    {
        private IDicePacketSequence sequence;
        private IDiceCommandResponse response;
        private bool disposed;

        /// <summary>
        /// Gets the underlying <see cref="IDiceConnection"/> for sending the packets generated from
        /// the <see cref="IDiceCommand"/>s
        /// </summary>
        public IDiceConnection Connection { get; private set; }

        /// <summary>
        /// Creates a new <see cref="DiceCommandInterface"/> instance
        /// </summary>
        /// <param name="connection"></param>
        public DiceCommandInterface(IDiceConnection connection)
        {
            #region Contracts

            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }

            #endregion

            Connection = connection;
        }

        /// <summary>
        /// Executes the <see cref="IDiceCommand"/> and directly receives the <see cref="IDiceCommandResponse"/>
        /// </summary>
        /// <param name="command"><see cref="IDiceCommand"/> to execute</param>
        /// <returns><see cref="IDiceCommandResponse"/> to the command executed</returns>
        public async Task<IDiceCommandResponse> ExecuteAsync(IDiceCommand command)
        {
            #region Contracts

            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            #endregion

            // Cleanup before execution
            response = null;
            Connection.PacketReceived -= ConnectionOnPacketReceived;

            sequence = new DicePacketSequence(Connection.GetNextSequenceId(), PacketType.Request, Origin.Client);
            
            Connection.PacketReceived += ConnectionOnPacketReceived;

            var packet = new DicePacket(sequence, command.ToWords());
            await Connection.SendAsync(packet);

            while (response == null)
            {
                await Task.Delay(10);
            }

            return response;
        }

        private void ConnectionOnPacketReceived(object sender, DicePacketEventArgs e)
        {
            if (e.Packet.Sequence.Id == sequence.Id &&
                                                e.Packet.Sequence.Origin == sequence.Origin &&
                                                e.Packet.Sequence.Type == PacketType.Response)
            {
                response = new DiceCommandResponse(e.Packet);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    // Dispose managed resources.
                    Connection.PacketReceived -= ConnectionOnPacketReceived;
                }

                disposed = true;
            }
        }

        ~DiceCommandInterface()
        {
            Dispose(false);
        }
    }
}
