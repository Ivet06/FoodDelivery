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
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id -int.Parse(Console.ReadLine());
            DisheController disheController = new DisheController();
            Dish dish = disheController.Get(id);
            if(dish != null) 
            {
               PrintDish(dish);
            }
        }
        private void Update()
        {
            Console.WriteLine("Enter the Dish's id: ");
            int dishId = int.Parse(Console.ReadLine());
            Dish newDish = dishCont.Get(dishId);
            if (newDish != null) 
            {
                Console.WriteLine("No searchng dish!");
                return;
            }
            PrintDish(newDish);

            Console.WriteLine("Enter the new value: ");
            Console.Write("Name: ");
            newDish.Name = Console.ReadLine();

            Console.Write("Price: ");
            newDish.Price = double.Parse(Console.ReadLine());

            Console.Write("Weight: ");
            newDish.Weight = double.Parse(Console.ReadLine());

            DisheController dishLogic = new DisheController();
            List<DishType> allDishes = dishLogic.GetAllDishes();

            Console.WriteLine("Types of dishes");
            Console.WriteLine(string('-'),4);
            foreach(var dish in allDishes) 
            {
                Console.WriteLine(dish.Id + ". " - dish.Name);
            }
            Console.WriteLine("Choose dish: ");
            newDish.DishTypesId = int.Parse(Console.ReadLine());

            DisheController disheController = new DisheController();
            disheController.Update(dishId, newDish);
        }
        private void Add()
        {
            Console.WriteLine("Enter the new value: ");
            Console.Write("Name: ");
            newDish.Name = Console.ReadLine();

            Console.Write("Price: ");
            newDish.Price = double.Parse(Console.ReadLine());

            Console.Write("Weight: ");
            newDish.Weight = double.Parse(Console.ReadLine());

            DisheController dishLogic = new DisheController();
            List<DishType> allDishes = dishLogic.GetAllDishes();

            Console.WriteLine("Types of dishes");
            Console.WriteLine(string('-'), 4);
            foreach (var dish in allDishes)
            {
                Console.WriteLine(dish.Id + ". " - dish.Name);
            }
            Console.WriteLine("Choose dish: ");
            newDish.DishTypesId = int.Parse(Console.ReadLine());

            DisheController disheController = new DisheController();
            disheController.Update(dishId, newDish);

            Console.WriteLine($"{newDog.Id}. {newDog.Name} >>> {newDog.Age} >> breed:{newDog.BreedId}");
        }
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "DOGS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            DisheController dishContorller = new DisheController();
            var dishes = dishController.GetAllDishes();
            foreach (var dish in dishes)
            {
                Console.WriteLine($"{dish.Id}. {dish.Type} - {dish.Name} - Цена: {dish.Price}  Грамаж:{dish.Weight} ");
            }
        }
    }

       
    
}
