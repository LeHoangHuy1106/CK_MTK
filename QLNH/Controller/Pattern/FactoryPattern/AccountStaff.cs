using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.FactoryPattern
{
    interface AccountStaff
    {
        string userName();
        string displayName();
        string passWord();
        int type();
        string images();


    }
}
