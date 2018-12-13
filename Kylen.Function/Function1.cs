using Kylen.Domain.Factories;
using Kylen.Function.Contracts;
using Kylen.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Threading.Tasks;

namespace Kylen.Function
{
    public static class Function1
    {
        [FunctionName("kylen")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            var repository = new DrinksRepository();
            var factory = new Factory(repository);
            var request = new SlackRequest(req.Form);
            try
            {
                var result = factory.GetResult(request.ToDrinkRequest(request));
                var response = new SlackResponse
                {
                    Text = result.Message
                };
                return new OkObjectResult(response);
            }
            catch (System.Exception)
            {
                var response = new SlackResponse
                {
                    Text = "Tyvärr gick något fel."
                };

                return new OkObjectResult(response);
            }
        }
    }
}
