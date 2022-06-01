using QLNH.Conttroler.Pattern.StatePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controler.Pattern.StatePattern
{
    class FullState:TableState
    {
        public string State()
        {
            return "Full";
        }
    }
}
