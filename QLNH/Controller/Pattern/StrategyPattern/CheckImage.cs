using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.StrategyPattern
{
    class CheckImage : CheckData
    {
        private string image;
        public CheckImage(string image)
        {
            this.image = image;
        }
        public bool Check()
        {
           if( this.image.Length==0)
            {
                return false;
            }
            return true;
        }

        public string Message()
        {
            if (this.image.Length == 0)
            {
                return "Bạn chưa thêm ảnh đại diện";
            }
            return "";
        }
    }
}
