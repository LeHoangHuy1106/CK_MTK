using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controler.Pattern.CommandPattern
{
    class button
    {
        private bool enable;
        public button(bool enable)
        {
            this.enable = enable;
        }
        public bool setTrue()
        {
            return true;
        }

    }

}
