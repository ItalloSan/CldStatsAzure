using System.Threading.Tasks;
using CldStatsDto.Dto.Queries;

namespace CldStatsClient.Core.Services.Interfaces
{
    public interface IGetLookupTablesService
    {
        Task<LookupTablesDto> GetLookupTables();
    }
}
