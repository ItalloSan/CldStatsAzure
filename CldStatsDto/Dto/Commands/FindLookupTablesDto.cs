using System.Collections.Generic;
using CldStatsDto.Dto.Queries;

namespace CldStatsDto.Dto.Commands
{
    public class FindLookupTablesDto
    {
        public List<ClusterDto> Clusters { get; set; }

        public List<ActivityTypeDto> ActivityTypes { get; set; }

        public List<QuarterDto> Quarters { get; set; }

        public List<UserDto> Users { get; set; }
    }
}
