namespace RaptoRCon.Dice
{
    /// <summary>
    /// This interface describes the first part of each <see cref="IPacket"/>.
    /// It informs about the function, origin and order of it.
    /// </summary>
    public interface IPacketSequence
    {
        /// <summary>
        /// Gets the Id of the <see cref="IPacketSequence"/> instance
        /// </summary>
        /// <remarks>
        /// Each Id should be unique in one communication channel
        /// </remarks>
        uint Id { get; }

        /// <summary>
        /// Gets the <see cref="PacketOrigin"/>-option, to show where the command
        /// of the current request/response communication was originated
        /// </summary>
        PacketOrigin Origin { get; }

        /// <summary>
        /// Gets the <see cref="PacketType"/>-option, to show wheather the current
        /// <see cref="IPacket"/> is a request or a response
        /// </summary>
        PacketType Type { get; }
    }
}
