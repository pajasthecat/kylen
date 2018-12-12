using Kylen.Domain.Models;
using Kylen.Domain.Services;
using Kylen.Function.Contracts;
using Kylen.Infrastructure.Repository;

namespace Kylen.Function.Factories
{
    internal class Factory
    {
        Service _service;
        public Factory()
        {
            var repository = new DrinksRepository();
            _service = new Service(repository);
        }
        public object GetResult(string command)
        {
            switch (command)
            {
                case "/kylstatus":
                    return GetDrinkStatus();
                default:
                    return null;
            }
        }

        private object GetDrinkStatus()
        {         
            return _service.GetDrinkStatuses();
        }
    }
}
