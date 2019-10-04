using System;
using NUnit.Framework;

namespace PizzaCallories
{
    [TestFixture]
    public class ToppingTest
    {
        [Test]
        public void IsCorrectForCorrectData()
        {
            var topping = new Topping(30, "Meat");
            Assert.AreEqual(330.0, topping.Callories);
        }

        [Test]
        public void IsErrorForIncorrectTopping()
        {
            Assert.AreEqual(new Exception("Cannot place Krenvirshi on top of your pizza."), new Topping(30, "Krenvirshi"));
        }

        [Test]
        public void IsErrorForIncorrectGrams()
        {
            Assert.AreEqual(new Exception("Meat weight should be in the range [1..50]."), new Topping(500, "Meat"));
        }
    }
}
