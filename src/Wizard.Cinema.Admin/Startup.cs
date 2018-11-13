using System;
using System.Collections.Generic;
using Infrastructures;
using Infrastructures.JsonConverters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Wizard.Cinema.Admin.Extensions;
using Wizard.Cinema.Admin.Quartz;
using Wizard.Cinema.Admin.Quartz.Jobs;
using Wizard.Cinema.Application.Services.Extensions;
using Wizard.Cinema.Remote;

namespace Wizard.Cinema.Admin
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
            services.AddRemote();
            services.AddApplicationService();
            services.AddAutoServices();

            services.AddQuartz();

            services.AddJwtAuthentication(Configuration);

            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.Converters.Add(new Int64JsonConverter());//解决js不支持int64的问题
                    options.SerializerSettings.Converters.Add(new NullableInt64JsonConverter());
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHeaderExceptionHandler();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseAuthentication();

            app.UseMvc();

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core, see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp/dist";

                if (env.IsDevelopment())
                {
                    //spa.UseAngularCliServer(npmScript: "start");
                    //   OR
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });

            app.UseQuartz();
        }
    }
}
