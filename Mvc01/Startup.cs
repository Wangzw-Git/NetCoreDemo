using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mvc01
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                //bind方法读取appsettings.json
                AppSettingsModel appSettings = new AppSettingsModel();
                Configuration.Bind(appSettings);

                await context.Response.WriteAsync($"BarnchId:{appSettings.BranchId}\r\n");
                await context.Response.WriteAsync($"BarnchName:{appSettings.BranchName}\r\n");
                foreach (var item in appSettings.UserAccounts)
                {
                    await context.Response.WriteAsync($"UserId:{item.UserId}，UserName:{item.UserName}\r\n");
                }
            });
        }
    }
}
