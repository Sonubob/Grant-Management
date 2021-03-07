using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.FactoryLayer;
using Business.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Business
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
          //  services.Add(new ServiceDescriptor(typeof(ILoginRegisterRepository), new LoginRegisterRepository()));
           // services.Add(new ServiceDescriptor(typeof(ILoginRegisterFactory), new LoginRegisterFactory()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            app.Run(async( context) =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
        }
    }
}
