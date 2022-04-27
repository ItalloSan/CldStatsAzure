using System.Collections.Generic;
using System.Threading.Tasks;
using CldStatsData.CldStatsModels;
using CldStatsDto.Dto.Queries;

namespace CldServiceFactory.Interfaces
{
    public interface ILookupTablesService
    {
        
            Task<List<Cluster>> GetClusters();
        Task<LookupTablesDto> GetLookupTables();
    }
}
