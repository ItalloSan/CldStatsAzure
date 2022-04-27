
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
    public class QuarterRetrieval : IQuarterRetrieval
    {
        private readonly CldStatsDbContext _cldStatsDbContext;
        public QuarterRetrieval(CldStatsDbContext cldStatsDbContext)
        {
            _cldStatsDbContext = cldStatsDbContext;
        }

        public async Task<List<QuarterDto>> GetQuarters()
        {
            try
            {
                return await _cldStatsDbContext.Quarters
                    .Select(q => new QuarterDto()
                    {
                        Id = q.Id,
                        Name = q.Name,
                        StartDate = q.StartDate,
                        EndDate = q.EndDate
                    })
                    .ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ApplicationException(e.Message, e);
            }
        }

    }
}
