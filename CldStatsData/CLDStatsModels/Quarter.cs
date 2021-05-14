using System;
using System.Collections.Generic;

#nullable disable

namespace CldStatsData.CldStatsModels
{
    public partial class Quarter
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
    }
}
