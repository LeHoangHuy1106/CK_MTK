using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.Decorator
{
    internal abstract class Drink
    {
        public abstract double cost();
        public abstract string makeTea();
    }
}
