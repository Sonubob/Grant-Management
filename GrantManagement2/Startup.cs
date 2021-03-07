using Business.BusinessLayer;
using Business.FactoryLayer;
using Business.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using GrantManagement.Middlewares;
using GrantManagement.LoggerModule;
using Microsoft.Extensions.Logging;

namespace GrantManagement2
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
            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",
                    builder => builder.WithOrigins("https://localhost:44379/", "http://localhost:59649").AllowAnyHeader().AllowAnyMethod());
            });
            services.AddControllersWithViews();
            
                services.Add(new ServiceDescriptor(typeof(ILoginRegisterRepository),
                new LoginRepository()));
            services.Add(new ServiceDescriptor(typeof(IRegisterRepository),
                new RegisterRepository()));
            services.Add(new ServiceDescriptor(typeof(IReviewRepository),
               new ReviewRepository()));
            services.Add(new ServiceDescriptor(typeof(IGrantRepository),
               new GrantRepository()));
            services.Add(new ServiceDescriptor(typeof(IApplicantRepository),
               new ApplicantRepository()));

            services.AddSingleton<ILoginRegisterFactory, LoginRegisterFactory>();
            services.AddSingleton<IApplicantFactory, ApplicantFactory>();
            services.AddSingleton<IGrantFactory, GrantFactory>();
            services.AddSingleton<IReviewFactory, ReviewFactory>();

            services.AddSingleton<ILoginRegistrationBL, LoginRegistrationBL>();
            services.AddSingleton<IApplicantBL, ApplicantBL>();
            services.AddSingleton<IGrantBL, GrantBL>();
            services.AddSingleton<IReviewBL, ReviewBL>();
            services.AddSingleton<IRegistrationBL, RegistrationBL>();

         
            // services.AddSingleton<ILogProvider, LogProvider>();
            //services.Add(new ServiceDescriptor(typeof(ILoginRegistrationBL), 
            //    new LoginRegistrationBL()));
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JwtToken:Issuer"],
                    ValidAudience = Configuration["JwtToken:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtToken:SecretKey"]))
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
                app.UseExceptionHandlerMiddleware();
            }
            else
            {
                //app.UseExceptionHandler("/Error");
                app.UseExceptionHandlerMiddleware();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //  app.UseHsts();
            }

            //   app.UseHttpsRedirection();
           
            app.UseStaticFiles();
            //if (!env.IsDevelopment())
            //{
            //    app.UseSpaStaticFiles();
            //}
          

            loggerFactory.AddProvider(new LogProvider(new LogOptions
            {
                FilePath = Configuration["LogFile:Options:FilePath"],
                FolderPath = Configuration["LogFile:Options:FolderPath"]
            }));


            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("MyPolicy");
            app.UseEndpoints(endpoints =>
            {
               
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
               
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                //spa.Options.SourcePath = "ClientApp";

                //if (env.IsDevelopment())
                //{
                //    spa.UseAngularCliServer(npmScript: "start");
                //}
                spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");

            });
        }
    }
}
