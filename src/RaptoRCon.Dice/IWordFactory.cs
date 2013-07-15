using System.Collections.Generic;

namespace RaptoRCon.Dice
{
    /// <summary>
    /// This interface describes a factory responsible for creating new <see cref="IWord"/> instances
    /// </summary>
    public interface IWordFactory
    {
        /// <summary>
        /// Creates a new <see cref="IWord"/> instance from delievered bytes
        /// </summary>
        /// <param name="bytes">The Collection of <see cref="byte"/> to extract the <see cref="IWord"/> instance from</param>
        /// <returns>The extracted <see cref="IWord"/> instance</returns>
        IWord FromBytes(IEnumerable<byte> bytes);
    }
}
