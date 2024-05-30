using FoodDelivery.Model;
using FoodDelivery.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.View
{
    public class Display
    {
        private DisheController dishCont = new DisheController();
        private int closeOperation = 6;


        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fench entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }

        private void PrintDish(Dish dish)
        {
            Console.WriteLine($"{dish.Id}. {dish.Type} - {dish.Name} - Цена: {dish.Price}  Грамаж:{dish.Weight} ");
        }

        private void Delete()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            DisheController dishContorller = new DisheController();
            Dish Dish = dishContorller.Get(id);
            if (Dish != null)
            {
                dishContorller.Delete(id);
            }
        }
    }

       
    
}
