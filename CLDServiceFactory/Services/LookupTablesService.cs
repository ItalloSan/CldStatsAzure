using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CldServiceFactory.Interfaces;
using CldStatsData;
using CldStatsData.CldStatsModels;
using CldStatsData.Dto;
using Microsoft.EntityFrameworkCore;

namespace CldServiceFactory.Services
{
    public class LookupTablesService : ILookupTablesService
    {
        private readonly CldStatsDbContext _cldStatsDbContext;
        public LookupTablesService(CldStatsDbContext cldStatsDbContext)
        {
            _cldStatsDbContext = cldStatsDbContext;
        }

        public async Task<List<Cluster>> GetClusters()
        {
            try
            {
                var clusters = await _cldStatsDbContext.Clusters.ToListAsync();
                return clusters;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ApplicationException(e.Message, e);
            }
            
        }

        public async Task<LookupTablesDto> GetLookupTables()
        {
            try
            {
                //var lookupTablesDto = await _cldStatsDbContext.Clusters.ToListAsync();
                var quarters = await _cldStatsDbContext.Quarters.OrderBy(q => q.StartDate).ToListAsync();
                var users = await _cldStatsDbContext.AspNetUsers.OrderBy(u => u.UserName).ToListAsync();
                var activityTypes = await _cldStatsDbContext.ActitityTypes.OrderBy(q => q.Description).ToListAsync();
                var lookupTablesDto = new LookupTablesDto()
                {
                    Quarters = quarters,
                    AspNetUsers = users,
                    ActitityTypes = activityTypes
                };
                return lookupTablesDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ApplicationException(e.Message, e);
            }
        }
    }
}
