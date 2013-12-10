namespace RaptoRCon.Games.Dice.Commands
{
    /// <summary>
    /// The interface describes the data and behaviour of a command, that can be send to the 
    /// <see cref="IDiceConnection"/>
    /// </summary>
    public interface IDiceCommand : IDiceWordifyable
    {
        /// <summary>
        /// Gets the command name / the command on the console
        /// </summary>
        string CommandName { get; }
    }
}
