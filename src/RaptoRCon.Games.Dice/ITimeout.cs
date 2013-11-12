namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// Some commands, such as bans, take a timeout as argument. This interface describes 
    /// the basic behaviour
    /// </summary>
    public interface ITimeout : IDiceWordifyable
    {
        /// <summary>
        /// Gets the type of the timeout
        /// </summary>
        TimeoutType Type { get; }
    }
}
