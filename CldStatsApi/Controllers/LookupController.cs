using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CldServiceFactory.Services.Interfaces;
using CldStatsData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CldStatsApi.Controllers
{
    public class LookupController : Controller
    {
        private readonly ILookupTablesService _lookupTablesService;
        //private readonly CldStatsDbContext _cldStatsDbContext;

        public LookupController(
            ILookupTablesService lookupTablesService
            //,CldStatsDbContext cldStatsDbContext
            // 
            //,ILogger logger
            )
        {
            _lookupTablesService = lookupTablesService;
            //_cldStatsDbContext = cldStatsDbContext;
            //_logger = logger;
        }

        [HttpGet]
        [Route("GetLookupTables")]
        public async Task<IActionResult> GetLookupTables()
        {
            try
            {
                var lookLookupTablesDtos = await _lookupTablesService.GetLookupTables();
                return Ok(lookLookupTablesDtos);
            }
            catch (Exception e)
            {
                //_logger.LogError(e.Message, e);
                return BadRequest(e.Message);
            }
        }
    }
}
