using System;
using System.Collections.Generic;

#nullable disable

namespace CldStatsData.CldStatsModels
{
    public partial class PipUser
    {
        public string Id { get; set; }
        public string AuthId { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PipUserStatusId { get; set; }
        public string Email { get; set; }
    }
}
