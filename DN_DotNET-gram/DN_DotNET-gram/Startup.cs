using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DN_DotNET_gram.Data;
using DN_DotNET_gram.Models.Interfaces;
using DN_DotNET_gram.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DN_DotNET_gram
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<DotNetgramDBContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"])
            );

            services.AddScoped<IPostManager, PostManagementService>();           
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}