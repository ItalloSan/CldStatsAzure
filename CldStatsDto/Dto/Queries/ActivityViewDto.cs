
using System.Collections.Generic;

namespace CldStatsDto.Dto.Queries
{
    public class ActivityViewDto
    {
        public List<ActivityDto> Activities { get; set; }
        public ActivityTotalDto ActivityTotal { get; set; }
        public ActivityTotalDto ActivityTotalYtd { get; set; }
    }
}
