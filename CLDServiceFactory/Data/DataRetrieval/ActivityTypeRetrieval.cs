using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CldServiceFactory.Interfaces.DataRetrieval;
using CldStatsData;
using CldStatsDto.Dto.Commands;
using CldStatsDto.Dto.Queries;
using Microsoft.EntityFrameworkCore;

namespace CldServiceFactory.Data.DataRetrieval
{
    public class ActivityTypeRetrieval : IActivityTypeRetrieval
    {
        private readonly CldStatsDbContext _cldStatsDbContext;

        public ActivityTypeRetrieval(CldStatsDbContext cldStatsDbContext)
        {
            _cldStatsDbContext = cldStatsDbContext;
        }

        public async Task<List<ActivityTypeDto>> GetActivityTypes()
        {
            return await _cldStatsDbContext.ActitityTypes
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
        }
    }
}
