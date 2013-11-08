using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games
{
    public class GameConnectionInfo : IGameConnectionInfo
    {
        public string HostName
        {
            get;
            set;
        }

        public int Port
        {
            get;
            set;
        }
    }
}
