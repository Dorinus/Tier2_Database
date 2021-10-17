using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Simple_booking_system.Models;
using Tier2_Database.DataAccess;
using Tier2_Database.Services;

namespace Tier2_Database
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            DataGeneration();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Tier2_Database", Version = "v1"});
            });
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IResourceService, ResourceService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tier2_Database v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        // Generating database
        public async void DataGeneration()
        {
            Random random = new Random();
            Resource resource = new Resource();
            IList<Resource> resourcesToDB = new List<Resource>();

            String[] resourses = {"Grains", "Vegetables", "Meat", "Wood", "Honey", "Minerals", "Crude oil"};

            using (SimpleBookingDBContext dbContext = new SimpleBookingDBContext())
            {
                foreach (var resourseName in resourses)
                {
                    resource.Id = 0;
                    resource.Name = resourseName;
                    resource.Quantity = random.Next(20, 101);
                    dbContext.Resources.Add(resource);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}