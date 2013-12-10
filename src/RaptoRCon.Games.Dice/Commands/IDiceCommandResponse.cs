namespace RaptoRCon.Games.Dice.Commands
{
    /// <summary>
    /// Describes a response to an <see cref="IDiceCommand"/>
    /// </summary>
    public interface IDiceCommandResponse
    {
        IDicePacket Packet { get; }
    }
}