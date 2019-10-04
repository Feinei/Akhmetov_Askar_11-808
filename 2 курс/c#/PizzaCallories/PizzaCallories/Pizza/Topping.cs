using System;

namespace PizzaCallories
{
    class Topping
    {
        readonly int grams;
        readonly IngredientType topIngredient;

        public Topping(int grams, string topping)
        {
            this.grams = grams > 0 && grams <= 50 ? grams :
                throw new Exception($"{topping} weight should be in the range [1..50].");

            topIngredient = IngridientsDataBase.Topping.ContainsKey(topping) ?
                new IngredientType(topping, IngridientsDataBase.Topping[topping]) :
                throw new Exception($"Cannot place ${topping} on top of your pizza.");
        }

        public double Callories
        {
            get { return 2 * grams * topIngredient.CalloriesModif; }
        }
    }
}
