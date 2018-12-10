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

        public IEnumerable<DrinkStatus> GetDrinkStatuses()
        {
            var drinkStatuses = _repository.GetDrinkStatus();
            return drinkStatuses;
        }
    }
}
