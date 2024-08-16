using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace JoAzureFnApp.HttpFunction
{
    public static class MessageReceiver
    {
        [FunctionName("MessageReceiver")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log,
            [Queue("message-queue"), StorageAccount("AzureWebJobsStorage")] ICollector<string> msg
        )
        {
            log.LogInformation(">> HTTP trigger. Function processed in POST request.");

            string reqBody = await new StreamReader(req.Body).ReadToEndAsync();
            // Validate Data

            // AddMessague to storage Queuex
            msg.Add(reqBody);

            return new OkResult();
        }
    }
}
