using System;
using System.Collections.Generic;

#nullable disable

namespace CldStatsData.CldStatsModels
{
    public partial class CurrerntQuarter
    {
        public int QuarterId { get; set; }

        public virtual Quarter Quarter { get; set; }
    }
}
