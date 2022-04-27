using System.Collections.Generic;
using System.Threading.Tasks;
using CldStatsDto.Dto.Commands;
using CldStatsDto.Dto.Queries;

namespace CldServiceFactory.Interfaces.DataRetrieval
{
    public interface IActivityRetrieval
    {
        Task<ActivityViewDto> GetActivityView(FindLookupTablesDto findLookupTablesDto, List<QuarterDto> startOfFinYearQuarters);

    }
}
