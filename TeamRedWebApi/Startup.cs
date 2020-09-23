using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TeamRedProject.Enitites;
using TeamRedProject.DbContexts;
using TeamRedProject.Services;
using Microsoft.AspNetCore.Identity;

namespace TeamRedWebApi
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
            //services.AddIdentityCore<IdentityUser>(options => 
            //{
            //    options.SignIn.RequireConfirmedEmail = true;
            //})
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<RealEstateContext>();

            services.AddControllers();
            //added automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //added scope
            services.AddScoped<IRealEstateRepo,RealEstateRepo>();
            //added policy
            services.AddCors(policy =>
            {
                policy.AddPolicy("NewPolicy", opt =>
                opt.AllowAnyOrigin().
                AllowAnyMethod().
                AllowAnyMethod());
            });
            //added database connection
            services.AddDbContext<RealEstateContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors("NewPolicy");

            app.UseRouting();
          
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
