using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class GameBase : IGame
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public Uri Homepage { get; private set; }

        protected GameBase(Guid id, string name, Uri homepage) 
        {
            this.Id = id;
            this.Name = name;
            this.Homepage = homepage;
        }

        public abstract Task<IGameConnection> CreateConnectionAsync(IGameConnectionInfo connectionInfo);
    }
}
