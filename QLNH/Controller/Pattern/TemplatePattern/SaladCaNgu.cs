using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.TemplatePattern
{
    public class SaladCaNgu : FoodTemplate
    {
        protected override string prepairMaterial()
        {
            return "Cá ngừ, rau xà lách, sốt salad, củ cải đường, rau mùi";
        }
        protected override string preprocessing()
        {
            return "Cắt cá miếng vừa ăn, thái nhỏ nguyên liệu";
        }
        protected override string processing()
        {
            return "Trộn nguyên liệu cùng nước sốt salad";
        }
        protected override string taste(string p)
        {
            if (p.Contains("Ăn mặn"))
            {
                return "Salad trộn sẵn kèm thêm nước sốt";
            }
            else
            {
                return "Salad trộn sẵn";
            }
        }
    }
}
