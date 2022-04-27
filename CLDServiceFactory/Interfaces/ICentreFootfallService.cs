using System.Collections.Generic;
using System.Threading.Tasks;
using CldStatsDto.Dto.Queries;

namespace CldServiceFactory.Interfaces
{
    public interface ICentreFootfallService
    {
        Task<List<CentreDto>> GetCentreFootfalls(CentreCountRequestDto centreCountRequestDto);
    }
}
