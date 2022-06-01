using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.FactoryPattern
{
    class AccountStaffFactory
    {
        public static AccountStaff GetAccountStaff(int Type)
        {
            AccountStaff account = null;
            if (Type == 2)
            {
                account = new staff();
            }
            else if (Type == 3)
            {
                account = new receptionist();
            }
            else if (Type == 4)
            {
                account = new Chef();
            }
            return account;
        }
    }
}
