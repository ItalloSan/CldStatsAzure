﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CldStatsData.CldStatsModels
{
    public partial class Quarter
    {

        public Quarter()
        {
            Acivities = new HashSet<Acivity>();
            CentreFootfalls = new HashSet<CentreFootfall>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual CurrerntQuarter CurrerntQuarter { get; set; }
        public virtual ICollection<Acivity> Acivities { get; set; }
        public virtual ICollection<CentreFootfall> CentreFootfalls { get; set; }

    }
}
