
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

        public async Task<List<QuarterDto>> GetStartOfFinYearQuarters()
        {
            try
            {
                var currentQuarter = await _cldStatsDbContext.CurrerntQuarters
                    .Include(a => a.Quarter)
                    .FirstOrDefaultAsync();

                switch (currentQuarter!.Quarter.Name)
                {
                    case "1":
                        return new List<QuarterDto>()
                        {
                            new QuarterDto()
                            {
                                Id = currentQuarter.Quarter.Id
                            },
                        };

                    case "2":
                        return new List<QuarterDto>()
                        {
                            new QuarterDto()
                            {
                                Id = currentQuarter.Quarter.Id
                            },
                            new QuarterDto()
                            {
                                Id = currentQuarter.Quarter.Id - 1
                            },
                        };

                    case "3":
                        return new List<QuarterDto>()
                        {
                            new QuarterDto()
                            {
                                Id = currentQuarter.Quarter.Id
                            },
                            new QuarterDto()
                            {
                                Id = currentQuarter.Quarter.Id - 1
                            },
                            new QuarterDto()
                            {
                                Id = currentQuarter.Quarter.Id - 2
                            },
                        };

                    case "4":
                        return new List<QuarterDto>()
                        {
                            new QuarterDto()
                            {
                                Id = currentQuarter.Quarter.Id
                            },
                            new QuarterDto()
                            {
                                Id = currentQuarter.Quarter.Id - 1
                            },
                            new QuarterDto()
                            {
                                Id = currentQuarter.Quarter.Id - 2
                            },
                            new QuarterDto()
                            {
                                Id = currentQuarter.Quarter.Id - 3
                            },
                        };

                    default:
                        return new List<QuarterDto>();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex.InnerException);
            }
        }

    }
}
