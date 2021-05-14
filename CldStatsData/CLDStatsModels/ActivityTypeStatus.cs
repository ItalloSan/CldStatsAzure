using System;
using System.Collections.Generic;

#nullable disable

namespace CldStatsData.CldStatsModels
{
    public partial class ActivityTypeStatus
    {
        public ActivityTypeStatus()
        {
            ActitityTypes = new HashSet<ActitityType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ActitityType> ActitityTypes { get; set; }
    }
}
