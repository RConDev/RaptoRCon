namespace RaptoRCon.Dice
{
    /// <summary>
    /// This interface describes the structure used for communicating with 
    /// remote console servers for games published by DICE (http://dice.se/)
    /// </summary>
    public interface IPacket
    {
        /// <summary>
        /// Gets the <see cref="IPacketSequence"/> for the current <see cref="IPacket"/>
        /// </summary>
        IPacketSequence Sequence { get; }

        /// <summary>
        /// Gets the size of the <see cref="IPacket"/> instance in bytes
        /// </summary>
        uint Size { get; }
    }
}
