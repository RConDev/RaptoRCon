﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Shared.Commands
{
    public class CreateConnectionCommand
    {
        public Guid GameId { get; set; }

        public string HostName { get; set; }

        public int Port { get; set; }
    }
}
