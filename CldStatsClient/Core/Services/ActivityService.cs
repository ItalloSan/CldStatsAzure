using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CldStatsClient.Core.Services.Activities;
using CldStatsDto.Dto.Commands;
using CldStatsDto.Dto.Queries;
using Newtonsoft.Json;

namespace CldStatsClient.Core.Services
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
            try
            {
                var path = $@"api/activities/GetActivityView";
                var request = new HttpRequestMessage(HttpMethod.Post, path)
                {
                    Content = new StringContent(
                        JsonConvert.SerializeObject(findLookupTablesDto),
                        Encoding.UTF8, "application/json")
                };

                var response = await _httpClient.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ActivityViewDto>(responseBody);
                //var tmp = new ActivityViewDto();
                //return tmp;
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

        private async Task<HttpResponseMessage> PostRequest(HttpRequestMessage request, string url)
        {
            try
            {
                var response = await _httpClient.SendAsync(request);
                if (response.StatusCode != HttpStatusCode.Unauthorized) return response;

                //await _httpClient.HandleToken();

                var newRequest = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = request.Content
                };
                response = await _httpClient.SendAsync(newRequest);
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
    }
}
