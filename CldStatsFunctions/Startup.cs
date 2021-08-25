using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using CldStatsData;
using CldServiceFactory.Services;
using System;
using CldServiceFactory.Services.Interfaces;
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

            var connStr = Environment.GetEnvironmentVariable("sqldb_connection");
            builder.Services.AddDbContext<CldStatsDbContext>(options1 =>
            {
                options1.UseSqlServer(connStr ?? throw new InvalidOperationException());
            });

            builder.Services.AddScoped<ILookupTablesService, LookupTablesService>();
            builder.Services.AddScoped<ICentreFootfallService, CentreFootfallService>();
        }
    }
}
