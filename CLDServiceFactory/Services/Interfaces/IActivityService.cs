
using System.Threading.Tasks;
using CldStatsDto.Dto.Commands;
using CldStatsDto.Dto.Queries;

namespace CldServiceFactory.Services.Interfaces
{
    public interface IActivityService
    {
        Task<ActivityViewDto> GetActivityView(FindLookupTablesDto findLookupTablesDto);
        Task<ActivityDto> CreateOrUpdateActivity(ActivityDto activityDto);
    }
}
