using Kylen.Domain.Models;
using System.Collections.Generic;

namespace Kylen.Domain.Repository
{
    public interface IRepository
    {
        Response GetDrinkStatus();

        Response TakeDrinks(DrinkRequest drinkRequest);

        Response AddDrinks(DrinkRequest drinkRequest);
    }
}
