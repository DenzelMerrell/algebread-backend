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

namespace backend
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "backend", Version = "v1" });
            });

            //cors
            /*
             var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

             services.AddCors(options =>
             {
                 options.AddPolicy(MyAllowSpecificOrigins,
                                       policy =>
                                       {
                                           policy.WithOrigins("https://localhost:5000",
                                                               "https://localhost:50001",
                                                               "https://localhost:44315")
                                                               .AllowAnyHeader()
                                                               .AllowAnyMethod();
                                       });
             });
            */
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "backend v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(
                options => options.WithOrigins("https://localhost:5000",
                                                               "https://localhost:50001",
                                                               "https://localhost:44315").AllowAnyMethod()
            );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //cors
            //var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            //app.UseCors(MyAllowSpecificOrigins);
            
        }
    }
}
