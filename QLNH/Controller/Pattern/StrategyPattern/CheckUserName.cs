using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.StrategyPattern
{
    class CheckUserName : CheckData
    {
        private string userName;
        public CheckUserName(string userName)
        {
            this.userName = userName;
        }

        public bool Check()
        {
            if (this.userName.Length <= 6)
                return false;
            else if (this.userName[0] >= '0' && this.userName[0] <= '9')
                {
                return false;
            }
            else
            {
                return true;
            }

        }

        public string Message()
        {
            if (this.userName.Length <= 6)
                return "Độ dài user name phai hơn 6 kí tự "
            else if (this.userName[0] >= '0' && this.userName[0] <= '9')
            {
                return "username phải bắt đầu bằng chữ";
            }
            else
            {
                return "";
            }
        }
    }
}
