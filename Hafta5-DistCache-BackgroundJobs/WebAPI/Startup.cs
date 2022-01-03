using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ActionFilters;
using WebAPI.Infrastructer;

namespace WebAPI
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
            var _mappingProfile = new MapperConfiguration(mp => { mp.AddProfile(new MappingProfile()); });
            IMapper mapper = _mappingProfile.CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IProductService, ProductManager>();
            services.AddTransient<IProductDal, ProductDal>();
            services.AddTransient<ICategoryService, CategoryManager>();
            services.AddTransient<ICategoryDal, CategoryDal>();
            services.AddTransient<IUserService, UserManager>();
            services.AddTransient<IUserDal, UserDal>();
            services.AddTransient<IAuthService, AuthManager>();
            services.AddScoped<ValidationFilterAttribute>();

            // services.AddScoped<IDistributedCache>();
            //InMemoryCache için inject
            //services.AddMemoryCache();
            //services.AddSingleton<IConnectionMultiplexer>(x =>
            //    ConnectionMultiplexer.Connect(Configuration.GetValue<string>("RedisConnection")));



            services.AddDistributedMemoryCache();
            services.AddStackExchangeRedisCache(options =>
            {

               options.Configuration = Configuration.GetConnectionString("Redis");
                
               //ConnectionMultiplexer.Connect("Redis");

            });




            // Hangfire injection backgorun job worker 
            services.AddHangfire(x => x.UseSqlServerStorage(@"Server=desktop-9d6tod0\sqlexpress;Database=Groot;Trusted_Connection=true"));
            services.AddHangfireServer();

            services.AddControllers();




            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }
            app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader());
            app.UseHangfireDashboard();
            app.UseHttpsRedirection();
            
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
