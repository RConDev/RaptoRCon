using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// The definition of a player subset argument for specific commands
    /// </summary>
    public interface IPlayerSubset
    {
        /// <summary>
        /// Gets the current <see cref="PlayerSubsetType"/>
        /// </summary>
        PlayerSubsetType Type { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<IDiceWord> ToWords();
    }
}
