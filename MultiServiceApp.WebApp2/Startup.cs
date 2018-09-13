using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiServiceApp.Proxies.Module;
using MultiServiceApp.WebApp2.Extensions.ServiceCollection;
using MultiServiceApp.WebApp2.Logic;

namespace MultiServiceApp.WebApp2
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
            services.AddTransient<IApp2BusinessLogic, App2BusinessLogic>();

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var policies = services.AddCustomRetryPolicyRegistry();
            services.RegisterProxies(policies);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Console.WriteLine(Process.GetCurrentProcess().Id);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

   
    }
}
