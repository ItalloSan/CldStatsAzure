
using CldStatsData.CldStatsModels;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CldStatsData
{
    public partial class CldStatsDbContext : DbContext
    {
        
        public CldStatsDbContext(DbContextOptions<CldStatsDbContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Quarter> Quarter { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:cldscot.database.windows.net,1433;Initial Catalog=PIPStats;Persist Security Info=False;User ID=itallosan;Password=Itall0{}$$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }
    }
}