using System;

namespace PizzaCallories
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pizza: name");
            var pizzaName = Console.ReadLine();

            Console.WriteLine("Dough: grams, flour, bakeTech");
            var doughGrams = int.Parse(Console.ReadLine());
            var flour = Console.ReadLine();
            var bakeTech = Console.ReadLine();

            var pizza = new Pizza(pizzaName, new Dough(doughGrams, flour, bakeTech));

            Console.WriteLine("Topping: count");
            var topCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < topCount; i++)
            {
                Console.WriteLine("Topping: grams, ingridient");
                var topGrams = int.Parse(Console.ReadLine());
                var topping = Console.ReadLine();
                pizza.AddTopping(new Topping(topGrams, topping));
            }
            
            Console.WriteLine($"Pizza: Name - {pizza.Name}, Callories - {pizza.Callories}, Topping Count - {pizza.ToppingCount}");
            Console.ReadKey();
        }
    }
}
