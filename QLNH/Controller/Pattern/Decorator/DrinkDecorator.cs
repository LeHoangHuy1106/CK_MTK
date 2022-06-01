using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.Decorator
{
    internal abstract class DrinkDecorator: Drink
    {
        protected Drink drink;
        public DrinkDecorator(Drink d)
        {
            this.drink = d;
        }
    }
}
