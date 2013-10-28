using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaptoRCon.Server.Hosting
{
    /// <summary>
    /// Description of the central host collecting the connection information
    /// </summary>
    public interface IConnectionHost
    {
        /// <summary>
        /// Gets all <see cref="IHostedConnection"/> instances hosted within the <see cref="ConnectionHost"/>
        /// </summary>
        /// <returns></returns>
        IEnumerable<IHostedConnection> Get();

        /// <summary>
        /// Adds an <see cref="IHostedConnection"/> instance to the <see cref="IConnectionHost"/>
        /// </summary>
        /// <param name="hostedConnection"></param>
        void Add(IHostedConnection hostedConnection);

        /// <summary>
        /// Gets a single <see cref="IHostedConnection"/> instance identified by its <see cref="Guid"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IHostedConnection Get(Guid id);

        /// <summary>
        /// Removes a <see cref="IHostedConnection"/> from the <see cref="IConnectionHost"/>
        /// </summary>
        /// <param name="hostedConnection"></param>
        /// <returns>Returns <see cref="true"/> if a <see cref="IHostedConnection"/> is successfully removed. Otherwise <see cref="false"/></returns>
        bool Remove(IHostedConnection hostedConnection);
    }
}
