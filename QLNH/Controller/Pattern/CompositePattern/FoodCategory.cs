using QLNH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.Controller.Pattern.CompositePattern
{
    class FoodCategory : menuComposite
    {
         protected List<Food> foods = new List<Food>();
        protected String name;
        private String id_Category;
        private String img;

        public FoodCategory(List<Food> foods, string name, string id_Category, string img)
        {
            this.foods = foods;
            this.name = name;
            this.id_Category = id_Category;
            this.img = img;
        }

        public string getName()
        {
           return  this.name = name;
        }
        public void addFood(Food food )
        {
            foods.Add(food);
        }
        public void removFood(Food food)
        {
            foods.Remove(food);
        }
    }
}

