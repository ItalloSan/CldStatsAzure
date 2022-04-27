using System.Collections.Generic;
using System.Threading.Tasks;
using CldStatsDto.Dto.Queries;

namespace CldServiceFactory.Interfaces.DataRetrieval
{
    public interface IClusterRetrieval
    {
        Task<List<ClusterDto>> GetClusters();
    }
}
