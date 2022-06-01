using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.Decorator
{
    internal class Bubble:DrinkDecorator
    {
        public Bubble(Drink d) : base(d)
        {
        }

        public override double cost()
        {
            return 5000 + drink.cost();
        }

        public override string makeTea()
        {
            return "Thêm trân châu" + " " + drink.makeTea();
        }
    }
}
