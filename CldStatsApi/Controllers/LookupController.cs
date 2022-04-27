using System;
using System.Threading.Tasks;
using CldServiceFactory.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CldStatsDto.Dto.Commands;
using Microsoft.AspNetCore.Authorization;

namespace CldStatsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : Controller
    {
        private readonly ILookupTablesService _lookupTablesService;

        public LookupController(
            ILookupTablesService lookupTablesService
            )
        {
            _lookupTablesService = lookupTablesService;   
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
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Find the lookup tables depending on what has been selected
        /// </summary>
        /// <param name="findLookupTables"></param>
        /// <returns></returns>
        
        [HttpPost]
        [Route("FindLookupTables")]
        public async Task<IActionResult> FindLookupTables(FindLookupTablesDto findLookupTables)
        {
            try
            {
                var lookLookupTablesDtos = await _lookupTablesService.GetLookupTables();
                return Ok(lookLookupTablesDtos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
