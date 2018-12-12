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
