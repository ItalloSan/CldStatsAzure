using System;
using System.Collections.Generic;

#nullable disable

namespace CldStatsData.CldStatsModels
{
    public partial class Centre
    {
        public Centre()
        {
            CentreFootfalls = new HashSet<CentreFootfall>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ClusterId { get; set; }

        public virtual Cluster Cluster { get; set; }
        public virtual ICollection<CentreFootfall> CentreFootfalls { get; set; }
    }
}
