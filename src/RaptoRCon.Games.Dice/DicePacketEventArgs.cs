using System;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// The <see cref="EventArgs"/> containing the <see cref="IDicePacket"/> information
    /// </summary>
    public class DicePacketEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the <see cref="IDicePacket"/> 
        /// </summary>
        public IDicePacket Packet { get; private set; }

        /// <summary>
        /// Creates a new <see cref="DicePacketEventArgs"/> instance with the delivered <see cref="IDicePacket"/> information
        /// </summary>
        /// <param name="packet"></param>
        public DicePacketEventArgs(IDicePacket packet)
        {
            #region Contracts
            if (packet == null)
            {
                throw new ArgumentNullException("packet");
            }
            #endregion

            Packet = packet;
        }
    }
}