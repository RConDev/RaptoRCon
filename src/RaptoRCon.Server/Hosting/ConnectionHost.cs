using RaptoRCon.Dice;
using RaptoRCon.Sockets;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Server.Hosting
{
    [Export]
    public class ConnectionHost
    {
        public IDiceConnection Socket { get; set; }
    }
}
