using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.TemplatePattern
{
    public class CaPhileSotChanhDay : FoodTemplate
    {
        protected override string prepairMaterial()
        {
            return "Cá phi lê, chanh dây, muối, tiêu, bếp nướng";
        }
        protected override string preprocessing()
        {
            return "Rửa sạch và đánh vẩy";
        }
        protected override string processing()
        {
            return "Nướng cá";
        }
        protected override string taste(string p)
        {
            if (p.Contains("Tự lóc xương"))
            {
                return "Khách hàng tự lóc xương";
            }
            else
            {
                return "Lóc xương sẵn";
            }
        }
    }
}
