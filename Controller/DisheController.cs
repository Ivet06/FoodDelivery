using FoodDelivery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.NewFolder1
{
    public class DisheController
    {
        private DishesDbContext dishesDbContext = new DishesDbContext();

        public Dish Get(int id)
        {
            Dish findDish = dishesDbContext.Dishes.Find(id);
            if(findDish != null)
            {
                dishesDbContext.Entry(findDish).Reference(x=>x.DishTypes).Load();   
            }
            return findDish;
        }
        public List<Dish> GetAll()
        {
            return dishesDbContext.Dishes.Include("DishType").ToList();
        }
        public void Create(Dish dish) 
        {
            dishesDbContext.Dishes.Add(dish);
            dishesDbContext.SaveChanges();
        }
        public void Update(int id, Dish dish)
        {
            Dish findDish = dishesDbContext.Dishes.Find(id);
            if(findDish == null) 
            {
                return;
            }
           
            findDish.Name = dish.Name;
            findDish.Info = dish.Info;
            findDish.Price = dish.Price;
            findDish.Weight = dish.Weight;
            findDish.Type = dish.Type;
            findDish.DishTypesId = dish.DishTypesId;
            dishesDbContext.SaveChanges();

        }
        public void Delete(int id) 
        {
            Dish findDish = dishesDbContext.Dishes.Find(id);
            dishesDbContext.Dishes.Remove(findDish);
            dishesDbContext.SaveChanges();
        }
    }
}
