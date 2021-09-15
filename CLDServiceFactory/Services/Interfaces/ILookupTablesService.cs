using System.Collections.Generic;
using System.Threading.Tasks;
using CldStatsData.CldStatsModels;
using CldStatsDto.Dto;
using CldStatsDto.Dto.Queries;

namespace CldServiceFactory.Services.Interfaces
{
    public interface ILookupTablesService
    {
        
        Task<List<Cluster>> GetClusters();
        Task<LookupTablesDto> GetLookupTables();
    }
}
