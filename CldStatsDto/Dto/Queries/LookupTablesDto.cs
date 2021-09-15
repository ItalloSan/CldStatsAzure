﻿using System.Collections.Generic;

namespace CldStatsDto.Dto.Queries
{
    public class LookupTablesDto
    {
        public List<UserDto> Users { get; set; }
        public List<ActivityTypeDto> ActivityTypes { get; set; }
        public List<QuarterDto> Quarters { get; set; }
        public List<ClusterDto> Clusters { get; set; }
    }
}
