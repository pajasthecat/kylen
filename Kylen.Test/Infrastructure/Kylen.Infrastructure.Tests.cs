using Kylen.Domain.Models;
using Kylen.Infrastructure.Repository;
using NUnit.Framework;

namespace Kylen.Test.Infrastructure
{

    [TestFixture]
    public class Kylen
    {
        DrinksRepository _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new DrinksRepository();
        }

        [Test]
        [Explicit]
        public void GetDrinkStatus_HappyCase()
        {

            var result = _sut.GetDrinkStatus();
        }

        [Test]
        [Explicit]
        public void TakeDrink_HappyCase()
        {
            var drinkRequest = new DrinkRequest
            {
                Drinks = new Drink
                {
                    Name = "Pepsi Max",
                    Quantity = 1
                },
                User = "Sebastian"
            };

            _sut.TakeDrinks(drinkRequest);
        }
    }
}
