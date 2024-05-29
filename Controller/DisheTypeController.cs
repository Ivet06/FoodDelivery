using FoodDelivery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Controller
{
    public class DisheTypeController
    {
        private DishesDbContext dishesDbContext = new DishesDbContext();

        public List<DishType> GetAllDishesType()
        {
            return dishesDbContext.DishesTypes.ToList();
        }
        public string GetDisheById(int id)
        {
            return dishesDbContext.DishesTypes.Find(id).Name;
        }
    }
}
