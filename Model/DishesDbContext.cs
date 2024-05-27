using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Model
{
    public class DishesDbContext:DbContext
    {
        public DishesDbContext() : base("DishesDbContext")
        {

        }
        public DbSet<Dish> Dishes { get; set; }//creat table dishes
        public DbSet<DishType> DishesTypes{ get; set; }//creat table dishtype
    }
}
