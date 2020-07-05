using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParkingExpert.DB;
using ParkingExpert.Repositories.Abstractions;
using ParkingExpert.Repositories.Implementations;
using ApiVersion = Microsoft.AspNetCore.Mvc.ApiVersion;

namespace ParkingExpert
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
            var connectionString = Configuration.GetConnectionString("PEConnectionString");
            services.AddDbContext<PEDataContext>(options =>
                options.UseSqlServer(connectionString,
                    optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(PEDataContext).GetTypeInfo().Assembly.GetName().Name)));
            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddApiVersioning(x =>  
            {  
                x.DefaultApiVersion = new ApiVersion(1, 0);  
                x.AssumeDefaultVersionWhenUnspecified = true;  
                x.ReportApiVersions = true;  
            });  
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}