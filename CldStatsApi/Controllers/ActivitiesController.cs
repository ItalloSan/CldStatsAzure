
using Microsoft.AspNetCore.Mvc;
using System;

using System.Threading.Tasks;
using CldServiceFactory.Services.Interfaces;
using CldStatsDto.Dto.Commands;
using CldStatsDto.Dto.Queries;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult HealthCheck()
        {
            return Ok("foo");
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

        [HttpPost]
        [Route("CreateOrUpdateActivity")]
        public async Task<IActionResult> CreateOrUpdateActivity(ActivityDto activityDto)
        {
            try
            {
                //!TODO - pull user from identity
                var userDto = new UserDto()
                {
                    Id = "244c545a-f665-47fc-87e3-d5943207c5a0"
                };
                activityDto.UserDto = userDto;
                var activity = await _activityService.CreateOrUpdateActivity(activityDto);
                return Ok(activity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
