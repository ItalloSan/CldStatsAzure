
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CldServiceFactory.Interfaces.DataRetrieval;
using CldStatsData;
using CldStatsDto.Dto.Queries;
using Microsoft.EntityFrameworkCore;

namespace CldServiceFactory.Data.DataRetrieval
{
    public class ClusterRetrieval : IClusterRetrieval
    {
        private readonly CldStatsDbContext _cldStatsDbContext;
        public ClusterRetrieval(CldStatsDbContext cldStatsDbContext)
        {
            _cldStatsDbContext = cldStatsDbContext;
        }

        public async Task<List<ClusterDto>> GetClusters()
        {
            try
            {
                return await _cldStatsDbContext.Clusters
                    .Select(c => new ClusterDto()
                        {
                            Name = c.Name,
                            Id = c.Id
                        }
                    )
                    .ToListAsync(); ;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ApplicationException(e.Message, e);
            }
        }

    }
}
