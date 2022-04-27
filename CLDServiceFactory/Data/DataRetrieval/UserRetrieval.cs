
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
    public class UserRetrieval : IUserRetrieval
    {
        private readonly CldStatsDbContext _cldStatsDbContext;
        public UserRetrieval(CldStatsDbContext cldStatsDbContext)
        {
            _cldStatsDbContext = cldStatsDbContext;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            try
            {
                return await _cldStatsDbContext.AspNetUsers
                    .Select(u => new UserDto()
                    {
                        Id = u.Id,
                        Email = u.Email
                    })
                    .OrderBy(u => u.Email)
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
