﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CldServiceFactory.Services.Interfaces;
using CldStatsData;
using CldStatsDto.Dto;
using CldStatsDto.Dto.Commands;
using CldStatsDto.Dto.Queries;
using Microsoft.EntityFrameworkCore;

namespace CldServiceFactory.Services
{
    public class ActivityService :IActivityService
    {
        private readonly CldStatsDbContext _cldStatsDbContext;

        public ActivityService(CldStatsDbContext cldStatsDbContext)
        {
            _cldStatsDbContext = cldStatsDbContext;
        }

        public async Task<ActivityViewDto> GetActivityView(FindLookupTablesDto findLookupTablesDto)
        {
            try
            {
                var activities = await _cldStatsDbContext.Acivities
                    .Where(a => findLookupTablesDto.ActivityTypes.Select(x => x.Id).Contains(a.ActivityType.Id) || findLookupTablesDto.ActivityTypes.Count == 0)
                    .Where(a => findLookupTablesDto.Quarters.Select(x => x.Id).Contains(a.Quarter.Id) || findLookupTablesDto.Quarters.Count  == 0)
                    .Where(a => findLookupTablesDto.Users.Select(x => x.Id).Contains(a.PipUser.Id) || findLookupTablesDto.Users.Count  == 0)
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
          
        }
    }
}
