using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CldServiceFactory.Services.Interfaces;
using CldStatsData;
using CldStatsDto.Dto;
using CldStatsDto.Dto.Queries;
using Microsoft.EntityFrameworkCore;

namespace CldServiceFactory.Services
{
    public class CentreFootfallService: ICentreFootfallService
    {
        private readonly CldStatsDbContext _cldStatsDbContext;
        public CentreFootfallService(CldStatsDbContext cldStatsDbContext)
        {
            _cldStatsDbContext = cldStatsDbContext;
        }

        public async Task<List<CentreDto>> GetCentreFootfalls(CentreCountRequestDto centreCountRequestDto)
        {
            try
            {
                // ReSharper disable once PossibleNullReferenceException
                var quarterId = centreCountRequestDto.QuarterId ?? await _cldStatsDbContext.CurrerntQuarters
                    .Select(x => x.QuarterId).FirstOrDefaultAsync();
                
                var quarters = _cldStatsDbContext.Quarters
                    .Where(q => q.Id <= quarterId && q.Id > quarterId - 10);

                var centres = _cldStatsDbContext.Centres
                    .Include(c => c.CentreFootfalls)
                    .OrderBy(c => c.Name).ToList();

                return null;

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message, e);
            }
        }
    }
}
