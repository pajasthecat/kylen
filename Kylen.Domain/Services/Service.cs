using Kylen.Domain.Models;
using Kylen.Domain.Repository;
using System.Collections.Generic;

namespace Kylen.Domain.Services
{
    public class Service
    {
        private readonly IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }

        public Response GetDrinkStatuses()
        {
            var drinkStatuses = _repository.GetDrinkStatus();
            return drinkStatuses;
        }

        public Response TakeDrink(DrinkRequest drinkRequest)
        {
            drinkRequest.Drinks.Quantity = -drinkRequest.Drinks.Quantity;
            return _repository.TakeDrinks(drinkRequest);
        }

        public Response AddDrink(DrinkRequest drinkRequest)
        {
            return _repository.AddDrinks(drinkRequest);
        }
    }
}
