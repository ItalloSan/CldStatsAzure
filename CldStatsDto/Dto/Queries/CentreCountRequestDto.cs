﻿using System.Collections.Generic;

namespace CldStatsDto.Dto
{
    public class CentreCountRequestDto
    {
        public int? QuarterId { get; set; }
        public List<ClusterDto> ClusterDtos { get; set; }
    }
}