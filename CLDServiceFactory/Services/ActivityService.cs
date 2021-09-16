using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CldServiceFactory.Services.Interfaces;
using CldStatsData;
using CldStatsDto.Dto.Commands;
using CldStatsDto.Dto.Queries;
using Microsoft.EntityFrameworkCore;

namespace CldServiceFactory.Services
{
    public class ActivityService : IActivityService
    {
        private readonly CldStatsDbContext _cldStatsDbContext;

        public ActivityService(CldStatsDbContext cldStatsDbContext)
        {
            _cldStatsDbContext = cldStatsDbContext;
        }

        /*public async Task<ActivityViewDto> GetActivityView(FindLookupTablesDto findLookupTablesDto)
        {
            try
            {
                var activities = await _cldStatsDbContext.Acivities
                    .Where(a => findLookupTablesDto.ActivityTypes.Select(x => x.Id).Contains(a.ActivityType.Id) || findLookupTablesDto.ActivityTypes.Count == 0)
                    .Where(a => findLookupTablesDto.Quarters.Select(x => x.Id).Contains(a.Quarter.Id) || findLookupTablesDto.Quarters.Count  == 0)
                    .Where(a => findLookupTablesDto.Users.Select(x => x.Id)
                        .Contains(a.PipUser.Id) || findLookupTablesDto.Users.Count  == 0
                        )
                    /*.Where(a => findLookupTablesDto.Clusters.Select(x => x.Id)
                        .Contains(a.ActivityClusters.Select(y => y.ClusterId)))#1#

                    .Select(a => new ActivityDto()
                        {
                            Id = a.Id,
                            Amount = a.Amount,
                            VolunteerAmount = a.VolunteerAmount,
                            VolunteerHours = a.VolunteerHours,
                            Note = a.Note,
                            QuarterDto = new QuarterDto(){ Id = a.Quarter.Id, Name = a.Quarter.Name, StartDate = a.Quarter.StartDate, EndDate = a.Quarter.EndDate},
                            ActivityTypeDto = new ActivityTypeDto(){Id = a.ActivityType.Id, Name = a.ActivityType.Name, Description = a.ActivityType.Description, PriorityId = a.ActivityType.PriorityId},
                            UserDto = new UserDto(){ Id = a.PipUser.Id, Email = a.PipUser.Email},
                            //ClusterDtos = new List<ClusterDto>(){ a.ActivityClusters.}
                        }
                    )
                    .ToListAsync();

                var activityViewDto = new ActivityViewDto()
                {
                    Activities = activities,
                    ActivityTotal = new ActivityTotalDto(),
                    ActivityTotalYtd = new ActivityTotalDto()
                };
                return activityViewDto;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message, e);
            }
          
        }*/

        public async Task<ActivityViewDto> GetActivityView(FindLookupTablesDto findLookupTablesDto)
        {
            try
            {
                var activities = await (
                        from a in _cldStatsDbContext.Acivities
                        join ac in _cldStatsDbContext.ActivityClusters on a.Id equals ac.ActivityId
                        join at in _cldStatsDbContext.ActitityTypes on a.ActivityTypeId equals at.Id
                        join q in _cldStatsDbContext.Quarters on a.QuarterId equals q.Id
                        join u in _cldStatsDbContext.AspNetUsers on a.PipUserId equals u.Id
                        where (findLookupTablesDto.ActivityTypes.Select(x => x.Id).Contains(a.ActivityTypeId) || findLookupTablesDto.ActivityTypes.Count == 0)

                              && (findLookupTablesDto.Quarters.Select(x => x.Id).Contains(a.QuarterId) || findLookupTablesDto.Quarters.Count == 0)

                              && (findLookupTablesDto.Users.Select(x => x.Id).Contains(a.PipUserId) || findLookupTablesDto.Users.Count == 0)

                              && (findLookupTablesDto.Clusters.Select(x => x.Id).Contains(ac.ClusterId) || findLookupTablesDto.Clusters.Count == 0)
                                    
                        select new ActivityDto
                        {
                            Id = a.Id,
                            Amount = a.Amount,
                            VolunteerAmount = a.VolunteerAmount,
                            VolunteerHours = a.VolunteerHours,
                            Note = a.Note,
                            QuarterDto = new QuarterDto()
                            {
                                Id = a.Quarter.Id, Name = a.Quarter.Name, StartDate = a.Quarter.StartDate,
                                EndDate = a.Quarter.EndDate
                            },
                            ActivityTypeDto = new ActivityTypeDto()
                            {
                                Id = a.ActivityType.Id, Name = a.ActivityType.Name,
                                Description = a.ActivityType.Description, PriorityId = a.ActivityType.PriorityId
                            },
                            UserDto = new UserDto() {Id = a.PipUser.Id, Email = a.PipUser.Email},
                        }
                    )
                    .ToListAsync();

                var activityViewDto = new ActivityViewDto()
                {
                    Activities = activities,
                    ActivityTotal = new ActivityTotalDto()
                    {
                        Opportunities = activities.Select(a => a.Amount).Sum(),
                        Volunteers = activities.Select(a => a.VolunteerAmount).Sum(),
                        VolunteerHours = activities.Select(a => a.VolunteerHours).Sum()
                    },
                    ActivityTotalYtd = await GetYtdTotals(findLookupTablesDto),
                };
                return activityViewDto;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message, e);
            }

        }

        private async Task<ActivityTotalDto> GetYtdTotals(FindLookupTablesDto findLookupTablesDto)
        {
            try
            {
                var quarters = await GetStartOfFinYearQuarters();

                var activities = await (
                        from a in _cldStatsDbContext.Acivities
                        join ac in _cldStatsDbContext.ActivityClusters on a.Id equals ac.ActivityId
                        join at in _cldStatsDbContext.ActitityTypes on a.ActivityTypeId equals at.Id
                        join q in _cldStatsDbContext.Quarters on a.QuarterId equals q.Id
                        join u in _cldStatsDbContext.AspNetUsers on a.PipUserId equals u.Id
                        where (findLookupTablesDto.ActivityTypes.Select(x => x.Id).Contains(a.ActivityTypeId) || findLookupTablesDto.ActivityTypes.Count == 0)

                              && quarters.Select(x => x.Id).Contains(a.QuarterId)

                              && (findLookupTablesDto.Users.Select(x => x.Id).Contains(a.PipUserId) || findLookupTablesDto.Users.Count == 0)

                              && (findLookupTablesDto.Clusters.Select(x => x.Id).Contains(ac.ClusterId) || findLookupTablesDto.Clusters.Count == 0)

                        select new ActivityDto
                        {
                            Id = a.Id,
                            Amount = a.Amount,
                            VolunteerAmount = a.VolunteerAmount,
                            VolunteerHours = a.VolunteerHours
                        }
                    )
                    .ToListAsync();

                return new ActivityTotalDto()
                {
                    Opportunities = activities.Select(a => a.Amount).Sum(),
                    Volunteers = activities.Select(a => a.VolunteerAmount).Sum(),
                    VolunteerHours = activities.Select(a => a.VolunteerHours).Sum()
                };
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message, e);
            }
        }

        private async Task<List<QuarterDto>> GetStartOfFinYearQuarters()
        {
            try
            {
                var currentQuarter = await _cldStatsDbContext.CurrerntQuarters
                    .Include(a => a.Quarter)
                    .FirstOrDefaultAsync();

                switch (currentQuarter.Quarter.Name)
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
