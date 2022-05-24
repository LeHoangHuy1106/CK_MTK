using QLNH.Conttroler.Pattern.StatePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controler.Pattern.StatePattern
{
    class TableStateContext
    {
        private TableState state;
        public void setState(TableState state)
        {
            this.state = state;
        }    
        public string getState()
        {
            return this.state.State();
        }
    }
}
