using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games
{
    /// <summary>
    /// This interface describes the current context, which is responsible for the games managed by RaptoRCon
    /// </summary>
    public interface IGamesContext
    {
        /// <summary>
        /// Deliveres all currently loaded and supported games by RaptoRCon asynchronously
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IGame>> GetAsync();

        /// <summary>
        /// Gets a single game loaded and supported by RaptoRCon asynchronously, which is identified by it's <see cref="Guid"/>
        /// </summary>
        /// <param name="id">The unique <see cref="Guid"/> of the game</param>
        /// <returns></returns>
        Task<IGame> GetAsync(Guid id);
    }
}
