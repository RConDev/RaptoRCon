namespace RaptoRCon.Games.Dice.Commands
{
    /// <summary>
    /// A response to an <see cref="IDiceCommand"/>
    /// </summary>
    public class DiceCommandResponse: IDiceCommandResponse
    {
        /// <summary>
        /// Gets the <see cref="IDicePacket"/> containing the raw response information
        /// </summary>
        public IDicePacket Packet { get; private set; }


        /// <summary>
        /// Creates a new <see cref="DiceCommandResponse"/> instance
        /// </summary>
        /// <param name="packet"></param>
        public DiceCommandResponse(IDicePacket packet)
        {
            Packet = packet;
        }
    }
}