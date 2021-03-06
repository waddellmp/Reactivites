
using Application.Activities;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;

namespace API
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
            // Add the DataContext object as a service
            services.AddDbContext<DataContext>(dbContextOptionsBuilder =>
            {
                dbContextOptionsBuilder.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            });
            
            // Add a new CORS policy to service collection
            services.AddCors(opt => opt.AddPolicy("CorsPolicy", configurePolicy => 
                {
                    // Trust localhost:3000, accept any method (GET, POST, PUT, etc), any header
                   configurePolicy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                }));
            
            // In C#, types are inherited from the System.Type 
            // typeof() returns the System.Type at compile time
            services.AddMediatR(typeof(List.Handler).Assembly);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

             // Configure the app runtime to use the CORS policy registered in ConfigureServices as a middleware
            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
