
using Microsoft.AspNetCore.Mvc;
using System;

using System.Threading.Tasks;
using CldServiceFactory.Services.Interfaces;
using CldStatsDto.Dto.Commands;

namespace CldStatsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivitiesController(
            IActivityService activityService
        )
        {
            _activityService = activityService;
        }

        [HttpPost]

        [Route("GetActivityView")]
        public async Task<IActionResult> GetActivityView(FindLookupTablesDto findLookupTablesDto)
        {
            try
            {
                var activityView = await _activityService.GetActivityView(findLookupTablesDto);
                return Ok(activityView);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
