using System;
using System.Collections.Generic;

#nullable disable

namespace CldStatsData.CldStatsModels
{
    public partial class CentreFootfall
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int CentreId { get; set; }
        public int QuarterId { get; set; }

        public virtual Centre Centre { get; set; }
        public virtual Quarter Quarter { get; set; }
    }
}
