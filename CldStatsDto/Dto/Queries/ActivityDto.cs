

using System.Collections.Generic;

namespace CldStatsDto.Dto.Queries
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int? VolunteerAmount { get; set; }
        public float? VolunteerHours { get; set; }
        public string Note { get; set; }
            
        public ActivityTypeDto ActivityTypeDto { get; set; }
        
        public UserDto UserDto { get; set; }
        public QuarterDto QuarterDto { get; set; }

    }
}
