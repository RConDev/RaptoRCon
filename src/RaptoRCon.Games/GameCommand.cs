using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games
{
    public class GameCommand : IGameCommand
    {
        public string Command
        {
            get;
            set;
        }
    }
}
