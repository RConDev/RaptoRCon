using System.Collections.Generic;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// This interface describes objects that can be used for communication with
    /// the remote console of the DICE game server
    /// </summary>
    public interface IDiceWordifyable
    {
        /// <summary>
        /// Transforms the current instance into words for communication with the remote console 
        /// of the game server
        /// </summary>
        /// <returns></returns>
        IEnumerable<IDiceWord> ToWords();
    }
}