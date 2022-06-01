using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.StrategyPattern
{
    class CheckType : CheckData
    {
        private int type;
        public CheckType(int type)
        {
            this.type = type;
        }
        public bool Check()
        {
            if (!(this.type <= 4 && this.type >= 1))
            {
                return false;
            }
            return true;
        }

        public string Message()
        {
            if (!(this.type <= 4 && this.type >= 1))
            {
                return "Type phải là 1,2,3,4";
            }
            return "";
        }
    }
}
