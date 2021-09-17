using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CldStatsDto.Dto.Commands;
using CldStatsDto.Dto.Queries;

namespace CldStatsClient.Core.Services.Activities
{
    public class ActivityService: IActivityService
    {
        private readonly HttpClient _httpClient;

        public ActivityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ActivityViewDto> GetActivityView(FindLookupTablesDto findLookupTablesDto)
        {
            //https://localhost:5001/api/activities
            try
            {
                var response = await _httpClient.GetAsync($"/api/activities");
                var tmp = new ActivityViewDto();
                return tmp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        public async Task<ActivityDto> CreateOrUpdateActivity(ActivityDto activityDto)
        {
            return null;
        }
    }
}
