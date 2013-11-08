using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games
{
    public interface IGameData
    {
        /// <summary>
        /// Gets the data in a <see cref="string"/> representation for display purposes.
        /// </summary>
        string DataString { get; }
    }
}
