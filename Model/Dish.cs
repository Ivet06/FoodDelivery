using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Model
{
    public class Dish
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Info { get; set; }

        public double Price {  get; set; }
        public double Weight { get; set; }
        public string Type { get; set; }

        //M:1
        public int DishTypesId{ get; set; }//FK
        public DishType DishTypes { get; set; }//таблицата, с която сe осъществява връзката
    }
}
