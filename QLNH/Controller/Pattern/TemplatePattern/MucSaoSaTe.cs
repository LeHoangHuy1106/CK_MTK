using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.TemplatePattern
{
    public class MucSaoSaTe : FoodTemplate
    {
        protected override string prepairMaterial()
        {
            return "Chuẩn bị mực. hành củ, hành lá, gừng, sa tế";
        }
        protected override string preprocessing()
        {
            return "Tẩm ướp gia vị, thái cắt nguyên liệu";
        }
        protected override string processing()
        {
            return "Bỏ toàn bộ vào chảo dầu";
        }
        protected override string taste(string p)
        {
            if (p.Contains("Cay nhiều"))
            {
                return "Cay nhiền -> thêm sa tế";
            }
            else
            {
                return "Cay ít";
            }
        }
    }
}
