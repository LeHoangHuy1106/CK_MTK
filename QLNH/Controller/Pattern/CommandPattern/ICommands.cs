using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.CommandPattern
{
    internal interface ICommands
    {
        void executeEnable();
        void executeDisable();
    }
}
