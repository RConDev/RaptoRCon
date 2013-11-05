using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games
{
    /// <summary>
    /// The <see cref="IGameConnectionFactory"/> is responsible for creating connections to a remote 
    /// console for a <see cref="IGame"/> instance
    /// </summary>
    public interface IGameConnectionFactory
    {
        /// <summary>
        /// Creates a new <see cref="IGameConnection"/> to a remote console
        /// </summary>
        /// <param name="connectionInfo"></param>
        /// <returns></returns>
        Task<IGameConnection> Create(IGameConnectionInfo connectionInfo);
    }
}
