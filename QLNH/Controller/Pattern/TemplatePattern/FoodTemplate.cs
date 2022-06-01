using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.TemplatePattern
{
    public abstract class FoodTemplate
    {
        string p;

        public void setString(string pre)
        {
            this.p = pre;
        }

        protected abstract string prepairMaterial();
        protected abstract string preprocessing();
        protected abstract string processing();
        protected abstract string taste(string p);
        public string prepareFood()
        {
            return
                prepairMaterial() + " -> " +
                preprocessing() + " -> " +
                processing() + " -> " +
                taste(p);
        }
    }
}
