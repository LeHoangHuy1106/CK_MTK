using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.Decorator
{
    internal class NormalTea:Drink
    {
        public override double cost()
        {
            return 10000;
        }

        public override string makeTea()
        {
            return "Thêm trà";
        }
    }
}
