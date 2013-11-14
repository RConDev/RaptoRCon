namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// The interface describes the players Id
    /// </summary>
    public interface IPlayerId : IDiceWordifyable
    {
        /// <summary>
        /// Gets the <see cref="IdType"/> of the current Id
        /// </summary>
        IdType Type { get; }
    }
}
