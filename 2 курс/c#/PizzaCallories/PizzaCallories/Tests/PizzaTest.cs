using NUnit.Framework;
using System;

namespace PizzaCallories.Tests
{
    [TestFixture]
    public class PizzaTest
    {
        [Test]
        public void IsCorrectForCorrectData()
        {
            var pizza = new Pizza("Meatless", new Dough(100, "Wholegrain", "Crispy"));
            pizza.AddTopping(new Topping(50, "Vegetables"));
            pizza.AddTopping(new Topping(50, "Cheese"));
            Assert.AreEqual(370.0, pizza.Callories);
            Assert.AreEqual("Meatless", pizza.Name);
            Assert.AreEqual(2, pizza.ToppingCount);
        }

        [Test]
        public void IsErrorForIncorrectName()
        {
            Assert.AreEqual(new Exception("Pizza name should be in the range [1..15]."),
                new Pizza("Meatlesssssssssss", new Dough(100, "Wholegrain", "Crispy")));
        }

        [Test]
        public void IsErrorForIncorrectToppingsCount()
        {
            var pizza = new Pizza("Meatless", new Dough(100, "Wholegrain", "Crispy"));
            for (var i = 0; i < 15; i++)
                pizza.AddTopping(new Topping(50, "Vegetables"));

            Assert.AreEqual(new Exception("Number of toppings should be in range[0..10]."),
                pizza.ToppingCount);
        }
    }
}
