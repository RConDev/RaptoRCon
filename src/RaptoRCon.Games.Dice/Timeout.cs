using System.Collections.Generic;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// Base class for all <see cref="Timeout"/> implementations
    /// </summary>
    public abstract class Timeout : ITimeout
    {
        /// <summary>
        /// Creates a new <see cref="Timeout"/> instance
        /// </summary>
        /// <param name="type"></param>
        protected Timeout(TimeoutType type)
        {
            this.Type = type;
        }

        /// <summary>
        /// Gets the type of the timeout
        /// </summary>
        public TimeoutType Type { get; private set; }

        /// <summary>
        /// Transforms the current instance into words for communication with the remote console 
        /// of the game server
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<IDiceWord> ToWords() 
        {
            yield return new DiceWord(this.Type.ToString().ToLower());
        }
    }
}
