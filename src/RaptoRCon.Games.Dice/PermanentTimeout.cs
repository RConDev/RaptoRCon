﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games.Dice
{
    public class PermanentTimeout : Timeout
    {
        public PermanentTimeout() 
            : base(TimeoutType.Perm) 
        {
        }
    }
}
