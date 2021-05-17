using System.Collections.Generic;
using System.Threading.Tasks;
using CldStatsData.CldStatsModels;

namespace CldServiceFactory.Interfaces
{
    public interface ILookupTables
    {
        Task<List<Cluster>> GetClusters();
    }
}
