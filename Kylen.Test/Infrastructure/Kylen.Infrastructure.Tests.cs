using Kylen.Infrastructure.Repository;
using NUnit.Framework;

namespace Kylen.Test.Infrastructure
{

    [TestFixture]
    public class Kylen
    {
        [Test]
        public void GetDrinkStatus_HappyCase()
        {
            var sut = new DrinksRepository();

            var result = sut.GetDrinkStatus();
        }
    }
}
