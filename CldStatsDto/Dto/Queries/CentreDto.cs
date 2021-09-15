using System.Collections.Generic;

namespace CldStatsDto.Dto.Queries
{
    public class CentreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CentreCountDto> CentreCountDtos { get; set; }
    }
}
