using Kylen.Domain.Models;
using Kylen.Domain.Repository;
using Kylen.Infrastructure.Models;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace Kylen.Infrastructure.Repository
{
    public class DrinksRepository : IRepository
    {

        public void TakeDrinks(DrinkRequest drinkRequest)
        {
            var client = new RestClient("https://dryck.co/api/1.0/units/collector1/drinks");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded",
                $"item={drinkRequest.Drinks.Name}&user={drinkRequest.User}&quantity={drinkRequest.Drinks.Quantity}", ParameterType.RequestBody);
            var response = client.Execute(request);
        }

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
            var drinkStatus = SimpleJson.SimpleJson.DeserializeObject<IEnumerable<Infrastructure.Models.DrinkStatus>>(response.Content);
            return drinkStatus.Select(dr => dr.ToDrinkStatus(dr));
        }
    }
}
