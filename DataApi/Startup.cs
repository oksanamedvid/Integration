using System;
using DataApi.Helpers;
using DataApi.Models;
using DataApiDAL;
using DataApiDAL.Abstracts;
using DataApiDAL.Repositories;
using DataApiDLL.Abstracts;
using DataApiDLL.Services;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddHttpContextAccessor();
            services.AddDbContext<JobContext>(options =>
                    options.UseMySQL("server=localhost;userid=root;password=lv40-!R5;database=jobs"));
            services.AddTransient<IJobVacancyRepository, JobVacancyRepository>();
            services.AddTransient<IJobVacancyService, JobVacancyService>();
            services.AddSingleton<ContextServiceLocator>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<NhlStatsQuery>();
            services.AddSingleton<NhlStatsMutation>();
            services.AddSingleton<JobType>();
            services.AddSingleton<JobInputType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new NhlStatsSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();
           // app.UseGraphiQl();
            app.UseMvc();
        }
    }
}
