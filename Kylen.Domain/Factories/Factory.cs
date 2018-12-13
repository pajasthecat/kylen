using System;
using Kylen.Domain.Models;
using Kylen.Domain.Repository;
using Kylen.Domain.Services;

namespace Kylen.Domain.Factories
{
    public class Factory
    {
        Service _service;
        public Factory(IRepository repository)
        {
            _service = new Service(repository);
        }

        public Response GetResult(DrinkRequest request)
        {
            switch (request.EnumType)
            {
                case EnumType.ADD:
                    return AddDrinks(request);
                case EnumType.TAKE:
                    return TakeDrinks(request);
                case EnumType.STATUS:
                    return GetDrinkStatus();
                default:
                    return new Response("Hittar inte vad du vill göra. Förösk igen.");
            }
        }

        private Response AddDrinks(DrinkRequest request)
        {
            return _service.AddDrink(request);
        }

        private Response TakeDrinks(DrinkRequest request)
        {
            return _service.TakeDrink(request);
        }

        private Response GetDrinkStatus()
        {
            return _service.GetDrinkStatuses();
        }
    }
}
