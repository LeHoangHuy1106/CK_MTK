using QLNH.Conttroler.Pattern.StatePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.StatePattern
{
    class paidState : TableState
    {
        public string State()
        {
            return "Paid";
        }
    }
}
