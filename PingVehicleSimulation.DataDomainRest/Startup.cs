using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PingVehicleSimulation.Core.Entities;
using PingVehicleSimulation.Core.Interfaces;
using PingVehicleSimulation.Infrastructure.DataContext;
using PingVehicleSimulation.Infrastructure.Repositories;
using PingVehicleSimulation.Infrastructure.UnitOfWork;

namespace PingVehicleSimulation.DataDomainRest
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

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped(typeof(DbContext), typeof(ALTENStockholmChallengeContext));

            services.AddSwaggerGen(s =>
            {
	            s.SwaggerDoc("v1", new OpenApiInfo
	            {
                    Title = "Data domain API",
                    Version = "v1",
                    Description = "Receives API request from the API Gateway and push it to the queue."
	            });
            });
            services.ConfigureSwaggerGen(s =>
            {
	            s.ResolveConflictingActions(x => x.FirstOrDefault());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
	            s.SwaggerEndpoint("swagger/v1/swagger.json", "PingVehicleSimulation Data Domain API V1");
	            s.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
