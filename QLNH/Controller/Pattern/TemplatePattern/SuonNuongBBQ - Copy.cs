using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.TemplatePattern
{
    public class SuonNuongBBQ : FoodTemplate
    {
        protected override string prepairMaterial()
        {
            return "Chuẩn bị sườn, than, gia vị ướp, đồ chấm, dụng cụ nướng";
        }
        protected override string preprocessing()
        {
            return "Tẩm ướp gia vị vào sườn, chuẩn bị đồ chấm";
        }
        protected override string processing()
        {
            return "Nướng sườn ";
        }
        protected override string taste(string p)
        {
            if (p.Contains("Sườn nướng ngọt"))
            {
                return "Sườn nướng BBQ thêm gia vị ngọt";
            }
            else
            {
                return "Sườn nướng sốt BBQ";
            }
        }
    }
}
