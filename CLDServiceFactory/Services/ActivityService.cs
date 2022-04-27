using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CldServiceFactory.Interfaces;
using CldServiceFactory.Interfaces.DataRetrieval;
using CldStatsData;
using CldStatsData.CldStatsModels;
using CldStatsDto.Dto.Commands;
using CldStatsDto.Dto.Queries;
using Microsoft.EntityFrameworkCore;  

namespace CldServiceFactory.Services
{
    public class ActivityService : IActivityService
    {
        private readonly CldStatsDbContext _cldStatsDbContext;
        private readonly IQuarterRetrieval _quarterRetrieval;
        private readonly IActivityRetrieval _activityRetrieval;

        public ActivityService(CldStatsDbContext cldStatsDbContext,
            IQuarterRetrieval quarterRetrieval,
            IActivityRetrieval activityRetrieval)
        {
            _cldStatsDbContext = cldStatsDbContext;
            _quarterRetrieval = quarterRetrieval;
            _activityRetrieval = activityRetrieval;

        }

        #region gets
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
                var startOfFinYearQuarters = await _quarterRetrieval.GetStartOfFinYearQuarters();
                return await _activityRetrieval.GetActivityView(findLookupTablesDto,startOfFinYearQuarters);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message, e);
            }

        }
      
        #endregion

        #region upserts

        //add return type for error messages !!
        public async Task<ActivityDto> CreateOrUpdateActivity(ActivityDto activityDto)
        {
            try
            {
                var currentQuarterId =
                    await _cldStatsDbContext.CurrerntQuarters.Select(q => q.QuarterId).FirstOrDefaultAsync();

                if (activityDto.QuarterDto.Id != currentQuarterId)
                    throw new ApplicationException("e.Message"); //proper error message
                
                var activity = await _cldStatsDbContext.Acivities
                    .Where(a => a.Id == activityDto.Id)
                    .FirstOrDefaultAsync();
                if (activity == null) //new activity
                {
                    var newActivity = new Acivity()
                    {
                        Amount = activityDto.Amount,
                        VolunteerAmount = activityDto.VolunteerAmount,
                        VolunteerHours = activityDto.VolunteerHours,
                        Note = activityDto.Note,
                        QuarterId = currentQuarterId,
                        ActivityTypeId = activityDto.ActivityTypeDto.Id, 
                        PipUserId = activityDto.UserDto.Id,
                        
                    };
                    await _cldStatsDbContext.Acivities.AddAsync(newActivity);
                    await _cldStatsDbContext.SaveChangesAsync();

                    var activityClusters = MapActivityClusters(activityDto.ClusterDtos, newActivity.Id);

                    await _cldStatsDbContext.ActivityClusters.AddRangeAsync(activityClusters);
                    await _cldStatsDbContext.SaveChangesAsync();

                    activityDto.Id = newActivity.Id;
                    return activityDto;
                }
                //edit
                activity.Amount = activityDto.Amount;
                activity.VolunteerAmount = activityDto.VolunteerAmount;
                activity.VolunteerHours = activityDto.VolunteerHours;
                activity.Note = activityDto.Note;
                activity.QuarterId = activityDto.QuarterDto.Id;
                activity.ActivityTypeId = activityDto.ActivityTypeDto.Id;

                await _cldStatsDbContext.SaveChangesAsync();
                var activityClustersToRemove =
                    await _cldStatsDbContext.ActivityClusters.Where(a => a.ActivityId == activityDto.Id).ToListAsync();

                var activityClustersToAdd = MapActivityClusters(activityDto.ClusterDtos, activityDto.Id);

                _cldStatsDbContext.ActivityClusters.RemoveRange(activityClustersToRemove);
                _cldStatsDbContext.ActivityClusters.AddRange(activityClustersToAdd);
                await _cldStatsDbContext.SaveChangesAsync();


                return activityDto;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message, e);
            }
        }

        private List<ActivityCluster> MapActivityClusters(IEnumerable<ClusterDto> clusterDtos, int activityId)
        {
            var activityClusters = new List<ActivityCluster>();
            foreach (var clusterDto in clusterDtos)
            {
                activityClusters.Add(new ActivityCluster()
                {
                    ActivityId = activityId,
                    ClusterId = clusterDto.Id
                });
            }

            return activityClusters;
        }

        #endregion

    }
}
