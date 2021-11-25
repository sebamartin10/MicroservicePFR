using MicroservicePFR.Domain.RepositoryContracts;
using MicroservicePFR.Infraestructure.Repository;
using MicroservicePFR.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicePFR
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
            services.AddScoped<IRecommendedService, RecommendedService>();
            services.AddScoped<IRecommendedRepository, SqlServerRecommendedRepository>();
            services.AddScoped<IInterestCategoryRepository, SqlServerInterestCategoryRepository>();
            services.AddScoped<IInterestCategoryService, InterestCategoryService>();
            services.AddScoped<IUserProfileRepository, SqlServerUserProfileRepository>();
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IFavouriteRepository, SqlServerFavouriteRepository>();
            services.AddScoped<IFavouriteService, FavouriteService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddDbContext<SqlServerDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MicroservicePFR", Version = "v1" });
            });
            services.AddHttpClient("Catalog",client => {
                client.BaseAddress = new Uri("http://localhost:3002");
            });
            services.AddHttpClient("Auth", client => {
                client.BaseAddress = new Uri("http://localhost:3000");
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MicroservicePFR v1"));
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
