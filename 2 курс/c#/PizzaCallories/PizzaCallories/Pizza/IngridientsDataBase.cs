using System.Collections.Generic;

namespace PizzaCallories
{
    class IngridientsDataBase
    {
        public static readonly Dictionary<string, double> Flour = new Dictionary<string, double>
        {
            { "White", 1.5 },
            { "Wholegrain", 1.0}
        };

        public static readonly Dictionary<string, double> BakeTech = new Dictionary<string, double>
        {
            { "Chewy", 1.1 },
            { "Home", 1.0},
            { "Crispy", 0.9 }
        };

        public static readonly Dictionary<string, double> Topping = new Dictionary<string, double>
        {
            { "Meat", 1.2 },
            { "Cheese", 1.1},
            { "Vegetables", 0.8 },
            { "Sauce", 0.9 }
        };
    }
}
