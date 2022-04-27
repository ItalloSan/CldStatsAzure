using System;
using CldServiceFactory.Data.DataRetrieval;
using CldServiceFactory.Interfaces;
using CldServiceFactory.Interfaces.DataRetrieval;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using CldServiceFactory.Services;
using CldStatsData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CldStatsApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CldStatsApi", Version = "v1" });
            });

            //var connStr = "Server=BOSS-16;Initial Catalog=PIPStats;integrated security=True;Connect Timeout=20;";//Environment.GetEnvironmentVariable("sqldb_connection");
            var connStr = Configuration.GetConnectionString("sqldb_connection");
            services.AddDbContext<CldStatsDbContext>(options =>
                {
                    options.UseSqlServer(connStr);
                });

            
            services.AddTransient<ILookupTablesService, LookupTablesService>();
            services.AddTransient<ICentreFootfallService, CentreFootfallService>();
            services.AddTransient<IActivityService, ActivityService>();
            services.AddTransient<IQuarterRetrieval, QuarterRetrieval>();
            services.AddTransient<IActivityTypeRetrieval, ActivityTypeRetrieval>();
            services.AddTransient<IClusterRetrieval, ClusterRetrieval>();
            services.AddTransient<IUserRetrieval, UserRetrieval>();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder
                    //.AddDebug()
                    .AddConsole();
                // .Services..AddEventLog();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CldStatsDbContext cldStatsDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CldStatsApi v1"));
                cldStatsDbContext.Database.Migrate();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
       
    }
}
