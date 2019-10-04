using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCallories
{
    class Pizza
    {
        public string Name
        {
            get { return Name; }
            private set
            {
                if (value == null || value == "" || value.Length > 15)
                    throw new Exception("Pizza name should be in the range [1..15].");
                Name = value;
            }
        }
    
        public int ToppingCount
        {
            get { return ToppingCount; }
            private set
            {
                if (value > 10)
                    throw new Exception("Number of toppings should be in range[0..10].");
                ToppingCount = value;
            }
        }

        readonly Dough dough;
        readonly List<Topping> toppings = new List<Topping>();

        public Pizza(string name, Dough dough)
        {
            Name = name;
            this.dough = dough;
            Callories = dough.Callories;
        }

        public double Callories { get; private set; }

        public void AddTopping(Topping topping)
        {
            toppings.Add(topping);
            ToppingCount++;
            Callories += topping.Callories;
        }       
    }
}
