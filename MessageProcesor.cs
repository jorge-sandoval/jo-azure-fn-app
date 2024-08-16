using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace JoAzureFnApp.QueueStorageTrigger
{
    public class MessageProcesor
    {
        [FunctionName("MessageProcesor")]
        public void Run([QueueTrigger("message-queue", Connection = "AzureWebJobsStorage")]string myQueueItem, ILogger log)
        {
            // Process
            log.LogInformation($">> QUEUE trigger. Function processed with Message: {myQueueItem}");
        }
    }
}
