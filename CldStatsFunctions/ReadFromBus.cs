using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace CldStatsFunctions
{
    public static class ReadFromBus
    {
        [FunctionName("ReadFromBus")]
        public static void Run([ServiceBusTrigger("cldsbqueue", Connection = "serviveBusConnection")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            
        }
    }
}
