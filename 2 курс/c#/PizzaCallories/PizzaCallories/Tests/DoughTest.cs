using System;
using NUnit.Framework;

namespace PizzaCallories
{
    [TestFixture]
    public class DoughTest
    {
        [Test]
        public void IsCorrectForCorrectData()
        {
            var dough = new Dough(100, "White", "Chewy");
            Assert.AreEqual(330.0, dough.Callories);
        }

        [Test]
        public void IsErrorForIncorrectFlour()
        {
            Assert.AreEqual(new Exception("Invalid type of dough."), new Dough(100, "Tip500", "Chewy"));
        }

        [Test]
        public void IsErrorForIncorrectGrams()
        {
            Assert.AreEqual(new Exception("Dough weight should be in the range [1..200]."), new Dough(240, "White", "Chewy"));
        }
    }
}
