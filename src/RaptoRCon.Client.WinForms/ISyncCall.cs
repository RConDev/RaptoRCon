using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Client.WinForms
{
    public interface ISyncCall
    {
        void Invoke(Action a);
    }
}
