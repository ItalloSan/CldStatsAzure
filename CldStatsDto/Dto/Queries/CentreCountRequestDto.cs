using System.Collections.Generic;

namespace CldStatsDto.Dto.Queries
{
    public class CentreCountRequestDto
    {
        public int? QuarterId { get; set; }
        public List<ClusterDto> ClusterDtos { get; set; }
    }
}
