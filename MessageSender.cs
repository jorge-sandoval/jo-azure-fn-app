using System;
using System.Net.Http;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace JoAzureFnApp.TriggerFunction
{
    public class MessageSender
    {
        [FunctionName("MessageSender")]
        public void Run([TimerTrigger("*/45 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($">> TIMER trigger. Function executed at: {DateTime.Now}");

            HttpClient http = new();
            HttpRequestMessage req = new HttpRequestMessage(
                HttpMethod.Post, "http://localhost:7071/api/MessageReceiver"
            );
            
            Random rnd = new Random();
            var msg = $"Message sent from MessageSender {rnd.Next(100)}";
            req.Content = new StringContent(
                JsonConvert.SerializeObject(msg),
                Encoding.UTF8,
                "application/json"
            );
            
            http.Send(req);
        }
    }
}
