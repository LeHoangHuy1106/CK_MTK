using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.StrategyPattern
{
    interface CheckData
    {
        bool Check();
        String Message();
        //userName, displayName, type, image


    }
}
