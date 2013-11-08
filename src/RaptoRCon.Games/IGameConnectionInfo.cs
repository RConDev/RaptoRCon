using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaptoRCon.Games
{
    public interface IGameConnectionInfo
    {
        string HostName { get; }

        int Port { get; }
    }
}
