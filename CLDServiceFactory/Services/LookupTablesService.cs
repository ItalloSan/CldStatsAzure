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
        private readonly IActivityTypeRetrieval _activityTypeRetrieval;
        private readonly IClusterRetrieval _clusterRetrieval;
        private readonly IUserRetrieval _userRetrieval;

        public LookupTablesService(CldStatsDbContext cldStatsDbContext,
            IQuarterRetrieval quarterRetrieval,
            IActivityTypeRetrieval activityTypeRetrieval,
            IClusterRetrieval clusterRetrieval,
            IUserRetrieval userRetrieval)
        {
            _cldStatsDbContext = cldStatsDbContext;
            _quarterRetrieval = quarterRetrieval;
            _activityTypeRetrieval = activityTypeRetrieval;
            _clusterRetrieval = clusterRetrieval;
            _userRetrieval = userRetrieval;
        }

       
        public async Task<LookupTablesDto> GetLookupTables()
        {
            try
            {
                var quarters = await _quarterRetrieval.GetQuarters();

                var users = await _userRetrieval.GetUsers(); 

                var activityTypes = await _activityTypeRetrieval.GetActivityTypes();

                var clusters = await _clusterRetrieval.GetClusters();

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
