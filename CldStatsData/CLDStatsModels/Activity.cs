using System;
using System.Collections.Generic;

#nullable disable

namespace CldStatsData.CldStatsModels
{
    public partial class Acivity
    {
        public Acivity()
        {
            ActivityClusters = new HashSet<ActivityCluster>();
        }

        public int Id { get; set; }
        public int Amount { get; set; }
        public int? VolunteerAmount { get; set; }
        public float? VolunteerHours { get; set; }
        public int ActivityTypeId { get; set; }
        public int QuarterId { get; set; }
        public string PipUserId { get; set; }
        public string Note { get; set; }

        public virtual ActitityType ActivityType { get; set; }
        public virtual AspNetUser PipUser { get; set; }
        public virtual Quarter Quarter { get; set; }
        public virtual ICollection<ActivityCluster> ActivityClusters { get; set; }
    }
}
