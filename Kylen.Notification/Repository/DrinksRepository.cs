using Kylen.Domain.Models;
using Kylen.Domain.Repository;
using Kylen.Infrastructure.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kylen.Infrastructure.Repository
{
    public class DrinksRepository : IRepository
    {

        public Domain.Models.Response TakeDrinks(DrinkRequest drinkRequest)
        {
            var response = PostDrinks(drinkRequest);
            if (!response.IsSuccessful) return new Response("Kunde tyvärr inte servera dig.");
            var postDrinkResponse = SimpleJson.SimpleJson.DeserializeObject<PostDrinkResponse>(response.Content);
            return new Response($"Njut av drycken nu. Så du vet återstår det nu {postDrinkResponse.quantity} av {postDrinkResponse.item}.");
        }

        public Domain.Models.Response AddDrinks(DrinkRequest drinkRequest)
        {
            var response = PostDrinks(drinkRequest);
            if (!response.IsSuccessful) return new Response($"Tyvärr kunde jag inte lägga till {drinkRequest.Drinks.Quantity} stycken {drinkRequest.Drinks.Quantity}.");
            var postDrinkResponse = SimpleJson.SimpleJson.DeserializeObject<PostDrinkResponse>(response.Content);
            return new Response($"Bra där! Nu finns det {postDrinkResponse.quantity} av {postDrinkResponse.item}.");
        }

        private static IRestResponse PostDrinks(DrinkRequest drinkRequest)
        {
            var client = new RestClient("https://dryck.co/api/1.0/units/collector1/drinks");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded",
                $"item={drinkRequest.Drinks.Name}&user={drinkRequest.User}&quantity={drinkRequest.Drinks.Quantity}", ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }

        public Response GetParticipantStatus()
        {
            var response = Get("https://dryck.co/api/1.0/units/collector1/status");
            var participantStatuses = DeserializeResponse(response);
            return new Response("");
        }

        public Response GetDrinkStatus()
        {
            var response = Get("https://dryck.co/api/1.0/units/collector1/drinks");
            var drinkStatuses = DeserializeResponse(response);

            var message = String.Join(", ", drinkStatuses
                .Where(dr => dr.Quantity > 0)
                .Select(p => String.Format("{0}", $"{p.Name} {p.Quantity}")));

            return new Response(message);
        }

        private static IRestResponse Get(string uri)
        {
            var client = new RestClient(uri);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            return response;
        }

        private static IEnumerable<Domain.Models.DrinkStatus> DeserializeResponse(IRestResponse response)
        {
            var drinkStatus = SimpleJson.SimpleJson.DeserializeObject<IEnumerable<Infrastructure.Models.GetDrinkResponse>>(response.Content);
            return drinkStatus.Select(dr => dr.ToDrinkStatus(dr));
        }
    }
}
