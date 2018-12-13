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
            var factory = StartUp();
            var request = new SlackRequest(req.Form);
            try
            {
                log.Info(request.user_name);
                var result = factory.GetResult(request.ToDrinkRequest(request));
                return new OkObjectResult(new SlackResponse(result.Message));
            }
            catch (System.Exception)
            {
                return new OkObjectResult(new SlackResponse("Tyvärr gick något fel."));
            }
        }

        private static Factory StartUp()
        {
            var repository = new DrinksRepository();
            var factory = new Factory(repository);
            return factory;
        }
    }
}
