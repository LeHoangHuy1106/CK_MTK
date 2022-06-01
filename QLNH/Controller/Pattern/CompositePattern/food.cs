using QLNH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.CompositePattern
{
    class Food:menuComposite
    {
        private String foodID;
        private String name;
        private String id_Category;
        private float price;
        private String img;

        public Food()
        {
        }
        public Food(String foodID, String name, String id_Category, float price, String img)
        {
            this.foodID = foodID;
            this.name = name;
            this.id_Category = id_Category;
            this.price = price;
            this.img = img;
        }

        public string getName()
        {
            return  this.name;
        }
    }
}
