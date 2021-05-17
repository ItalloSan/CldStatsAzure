using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using CldStatsData;
using System;
using CldServiceFactory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(Startup))]
namespace CldServiceFactory
{
    class Startup
    {
    }
}
