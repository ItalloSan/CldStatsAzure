using System;
using System.Threading.Tasks;
using System.Web.Http;
using CldServiceFactory.Services.Interfaces;
using CldStatsDto.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CldStatsFunctions
{
    //CI Test
    public class GetCentreFootfalls
    {
        private readonly ICentreFootfallService _centreFootfallService;

        public GetCentreFootfalls(ICentreFootfallService centreFootfallService)
        {
            _centreFootfallService = centreFootfallService;
        }
        
        [FunctionName("GetCentreFootfalls")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP GetCentreFootfalls trigger function processed a request.");

            try
            {
                var centerCountRequestDto = new CentreCountRequestDto()
                {
                    ClusterDtos = null,
                    QuarterId = null
                };
                var centreFootfallDtos = await _centreFootfallService.GetCentreFootfalls(centerCountRequestDto);

                return new OkObjectResult(centreFootfallDtos);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new BadRequestErrorMessageResult(e.Message);
            }
        }
    }
}
