using Kylen.Function.Contracts;
using Kylen.Function.Factories;
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
            var slack = new SlackCommandPayload(req.Form);
            var factory = new Factory();
            var result = factory.GetResult(slack.command);
            if (result == null) return new NotFoundResult();
            return new OkObjectResult(result);
        }
    }
}
