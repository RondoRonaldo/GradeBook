using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Services;
using DAL.EF;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;



namespace Project
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
            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
          //  ConfigureCors(services);
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IUnitOfWork, IdentityUnitOfWork>();
            services.AddMvc();
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutoMapperProfile()); });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);            
        
            

        }

        private void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
                options.AddPolicy("AllowOrigins",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:443")
                            .AllowAnyMethod()
                            .AllowAnyHeader().
                            AllowCredentials().
                            WithExposedHeaders();
                    }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
        



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {              
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}");
            });
        }
    }
}
