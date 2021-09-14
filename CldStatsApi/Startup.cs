using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CldServiceFactory.Services;
using CldServiceFactory.Services.Interfaces;
using CldStatsData;
using Microsoft.EntityFrameworkCore;

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

            
            services.AddScoped<ILookupTablesService, LookupTablesService>();
            services.AddScoped<ICentreFootfallService, CentreFootfallService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CldStatsApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
