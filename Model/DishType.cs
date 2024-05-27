using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Model
{
    public class DishType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // relation 1:M
        public ICollection<Dish> Dishes { get; set; }


    }
}
