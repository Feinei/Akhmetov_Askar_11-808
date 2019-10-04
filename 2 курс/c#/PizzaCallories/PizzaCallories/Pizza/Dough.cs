using System;

namespace PizzaCallories
{

    class Dough
    {
        readonly int grams;
        readonly IngredientType flour;
        readonly IngredientType bakeTech;

        public Dough(int grams, string flour, string bakeTech)
        {
            this.grams = grams > 0 && grams <= 200 ? grams :
                throw new Exception("Dough weight should be in the range [1..200].");

            this.flour = IngridientsDataBase.Flour.ContainsKey(flour) ?
                new IngredientType(flour, IngridientsDataBase.Flour[flour]) :
                throw new Exception("Invalid type of dough.");

            this.bakeTech = IngridientsDataBase.BakeTech.ContainsKey(bakeTech) ?
                new IngredientType(bakeTech, IngridientsDataBase.BakeTech[bakeTech]) :
                throw new Exception("Invalid type of dough.");
        }

        public double Callories
        {
            get { return 2 * grams * flour.CalloriesModif * bakeTech.CalloriesModif; }
        }
    }   
}
