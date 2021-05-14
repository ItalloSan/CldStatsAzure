using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using CldStatsData;
using Microsoft.EntityFrameworkCore;

namespace CldStatsFunctions
{
    public class GetData
    {
        private readonly CldStatsDbContext _cldStatsDbContext;
        public GetData(CldStatsDbContext cldStatsDbContext)
        {
            _cldStatsDbContext = cldStatsDbContext;
        }

        [FunctionName("ReadFromBus")]
        public async void Run([ServiceBusTrigger("cldsbqueue", Connection = "serviveBusConnection")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            await GetCentre(myQueueItem);
        }

        //[FunctionName("GetCentre")]
        //public async Task<IActionResult> GetCentre([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log)
        public async Task<IActionResult> GetCentre(string message)
        {
            try
            {
                //log.LogInformation($"C# ServiceBus message: {message}");
                var centres = await _cldStatsDbContext.Centres.ToListAsync();

                return new OkObjectResult(centres);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new BadRequestErrorMessageResult(e.Message);
            }


        }

        [FunctionName("GetCluster")]
        public async Task<IActionResult> GetCluster(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            /*string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name ??= data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";
            if (name != "quarters") return new OkObjectResult(responseMessage);

            */
            try
            {
                var quarters = await _cldStatsDbContext.Quarters.ToListAsync();

                return new OkObjectResult(quarters);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new BadRequestErrorMessageResult(e.Message);
            }

            
        }
    }
}
