using System;
using System.Collections.Generic;

#nullable disable

namespace CldStatsData.CldStatsModels
{
    public partial class ActitityType
    {
        public ActitityType()
        {
            Activities = new HashSet<Acivity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }

        public virtual Priority Priority { get; set; }
        public virtual ActivityTypeStatus Status { get; set; }
        public virtual ICollection<Acivity> Activities { get; set; }
    }
}
