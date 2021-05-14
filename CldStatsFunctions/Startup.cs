using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using CldStatsData;
using System;
using CldStatsFunctions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(Startup))]
namespace CldStatsFunctions
{
    class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddDbContext<CldStatsDbContext>(options1 =>
            {
                options1.UseSqlServer("Server=tcp:cldscot.database.windows.net,1433;Initial Catalog=PIPStats;Persist Security Info=False;User ID=itallosan;Password=Itall0{}$$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                    //
                    //
                    //
                    // config["sqldb_connection"],
                    // builder =>
                    // {
                    //     builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                    //     builder.CommandTimeout(10);
                    // }
                );
            });
        }
    }
}
//optionsBuilder.UseSqlServer("Server=tcp:cldscot.database.windows.net,1433;Initial Catalog=PIPStats;Persist Security Info=False;User ID=itallosan;Password=Itall0{}$$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
