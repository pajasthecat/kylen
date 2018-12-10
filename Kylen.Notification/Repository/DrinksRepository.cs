using Kylen.Domain.Repository;
using Kylen.Infrastructure.Models;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace Kylen.Infrastructure.Repository
{
    public class DrinksRepository : IRepository
    {
        public IEnumerable<Domain.Models.DrinkStatus> GetDrinkStatus()
        {
            var response = GetDrinks();
            var drinkStatuses = DeserializeResponse(response);
            return drinkStatuses
                .Where(dr => dr.Quantity > 0);
        }

        private static IRestResponse GetDrinks()
        {
            var client = new RestClient("https://dryck.co/api/1.0/units/collector1/drinks");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            return response;
        }

        private static IEnumerable<Domain.Models.DrinkStatus> DeserializeResponse(IRestResponse response)
        {
           var drinkStatus = SimpleJson.SimpleJson.DeserializeObject<IEnumerable<DrinkStatus>>(response.Content);
            return drinkStatus.Select(dr => dr.ToDrinkStatus(dr));
        }
    }
}
