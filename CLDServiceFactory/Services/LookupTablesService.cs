using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CldServiceFactory.Interfaces;
using CldServiceFactory.Interfaces.DataRetrieval;
using CldStatsData;
using CldStatsData.CldStatsModels;
using CldStatsDto.Dto;
using CldStatsDto.Dto.Queries;
using Microsoft.EntityFrameworkCore;

namespace CldServiceFactory.Services
{
    public class LookupTablesService : ILookupTablesService
    {
        private readonly CldStatsDbContext _cldStatsDbContext;
        private readonly IQuarterRetrieval _quarterRetrieval;
        public LookupTablesService(CldStatsDbContext cldStatsDbContext,
            IQuarterRetrieval quarterRetrieval)
        {
            _cldStatsDbContext = cldStatsDbContext;
            _quarterRetrieval = quarterRetrieval;
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
                var quarters = await _quarterRetrieval.GetQuarters();

                var users = await _cldStatsDbContext.AspNetUsers
                    .Select(u => new UserDto()
                    {
                        Id = u.Id,
                        Email = u.Email
                    })
                    .OrderBy(u => u.Email)
                    .ToListAsync();

                var activityTypes = await _cldStatsDbContext.ActitityTypes
                    .Select(a => new ActivityTypeDto()
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Description = a.Description,
                        PriorityId = a.PriorityId
                    })
                    .OrderBy(q => q.PriorityId)
                    .ThenBy(q => q.Name)
                    .ToListAsync();
                
                var clusters = await _cldStatsDbContext.Clusters
                    .Select(c => new ClusterDto()
                        {
                            Name = c.Name,
                            Id = c.Id
                        }
                    )
                    .ToListAsync();
                var lookupTablesDto = new LookupTablesDto()
                {
                    Quarters = quarters,
                    Users = users,
                    ActivityTypes = activityTypes,
                    Clusters = clusters
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
