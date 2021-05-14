using System;
using System.Collections.Generic;

#nullable disable

namespace CldStatsData.CldStatsModels
{
    public partial class Cluster
    {
        public Cluster()
        {
            ActivityClusters = new HashSet<ActivityCluster>();
            Centres = new HashSet<Centre>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ActivityCluster> ActivityClusters { get; set; }
        public virtual ICollection<Centre> Centres { get; set; }
    }
}
