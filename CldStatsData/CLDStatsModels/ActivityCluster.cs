using System;
using System.Collections.Generic;

#nullable disable

namespace CldStatsData.CldStatsModels
{
    public partial class ActivityCluster
    {
        public int ActivityId { get; set; }
        public int ClusterId { get; set; }

        public virtual Acivity Activity { get; set; }
        public virtual Cluster Cluster { get; set; }
    }
}
