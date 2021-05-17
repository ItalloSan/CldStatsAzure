using System;
using System.Threading.Tasks;
using System.Web.Http;
using CldServiceFactory.Interfaces;
using CldStatsData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CldStatsFunctions
{
    public class GetClusters
    {
        //private readonly CldStatsDbContext _cldStatsDbContext;
        private readonly ILookupTables _lookupTables;
        
        public GetClusters(CldStatsDbContext cldStatsDbContext, ILookupTables lookupTables)
        {
            //_cldStatsDbContext = cldStatsDbContext;
            _lookupTables = lookupTables;
        }
        
        [FunctionName("GetClusters")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger GetClusters processed a request.");

            try
            {
                //var clusters = await _cldStatsDbContext.Clusters.ToListAsync();
                var clusters = await _lookupTables.GetClusters();
                return new OkObjectResult(clusters);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new BadRequestErrorMessageResult(e.Message);
            }
        }
    }
}
