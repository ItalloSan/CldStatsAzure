using System.Collections.Generic;
using System.Threading.Tasks;
using CldStatsDto.Dto.Commands;
using CldStatsDto.Dto.Queries;

namespace CldServiceFactory.Interfaces.DataRetrieval
{
    public interface IActivityTypeRetrieval
    {
        Task<List<ActivityTypeDto>> GetActivityTypes();

    }
}
