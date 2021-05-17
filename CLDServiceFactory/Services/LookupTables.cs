using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CldServiceFactory.Interfaces;
using CldStatsData;
using CldStatsData.CldStatsModels;
using Microsoft.EntityFrameworkCore;

namespace CldServiceFactory.Services
{
    public class LookupTables : ILookupTables
    {
        private readonly CldStatsDbContext _cldStatsDbContext;
        public LookupTables(CldStatsDbContext cldStatsDbContext)
        {
            _cldStatsDbContext = cldStatsDbContext;
        }

        public async Task<List<Cluster>> GetClusters()
        {
            var clusters = await _cldStatsDbContext.Clusters.ToListAsync();
            return clusters;
        }
    }
}
