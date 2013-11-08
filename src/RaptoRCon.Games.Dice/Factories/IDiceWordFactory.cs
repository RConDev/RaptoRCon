using System.Collections.Generic;

namespace RaptoRCon.Games.Dice.Factories
{
    /// <summary>
    /// This interface describes a factory responsible for creating new <see cref="IDiceWord"/> instances
    /// </summary>
    public interface IDiceWordFactory
    {
        /// <summary>
        /// Creates a new <see cref="IDiceWord"/> instance from delievered bytes
        /// </summary>
        /// <param name="bytes">The Collection of <see cref="byte"/> to extract the <see cref="IDiceWord"/> instance from</param>
        /// <returns>The extracted <see cref="IDiceWord"/> instance</returns>
        IDiceWord FromBytes(IEnumerable<byte> bytes);
    }
}
