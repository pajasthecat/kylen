using Kylen.Domain.Services;
using Kylen.Infrastructure.Repository;

namespace Kylen.Function.Factories
{
    internal class Factory
    {
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
            var repository = new DrinksRepository();
            var service = new Service(repository);
            return service.GetDrinkStatuses();
        }
    }
}
