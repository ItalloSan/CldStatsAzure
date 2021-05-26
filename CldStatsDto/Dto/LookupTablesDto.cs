using System.Collections.Generic;
using CldStatsData.CldStatsModels;

namespace CldStatsDto.Dto
{
    public class LookupTablesDto
    {
        public List<AspNetUser> AspNetUsers { get; set; }
        public List<ActitityType> ActitityTypes { get; set; }
        public List<Quarter> Quarters { get; set; }
    }
}
