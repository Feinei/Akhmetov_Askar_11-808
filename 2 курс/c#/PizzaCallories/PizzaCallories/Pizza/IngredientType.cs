namespace PizzaCallories
{
    class IngredientType
    {
        public string Name { get; private set; }
        public double CalloriesModif { get; private set; }

        public IngredientType(string name, double calloriesModif)
        {
            Name = name;
            CalloriesModif = calloriesModif;
        }
    }
}
