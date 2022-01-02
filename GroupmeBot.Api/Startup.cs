using GroupmeBot.Data.Commands;
using GroupmeBot.Data.Models.GroupMe;
using GroupmeBot.Data.Models.Site;
using GroupmeBot.Data.Models.Thesaurus;
using GroupmeBot.Data.Mongo;
using GroupmeBot.Data.Mongo.Repositories;
using GroupmeBot.Data.Tools;
using GroupmeBot.WebHelpers.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json.Serialization;

namespace GroupmeBot.Api
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
            // HTTP Clients are meant to be singletons - let .NET Core figure out when to inject them
            services.AddHttpClient();

            services.AddControllersWithViews();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            // Configure and register "secrets" object 
            services.Configure<GroupmeBotAccountDetails>(Configuration.GetSection("GroupmeCreds"));
            services.Configure<ThesaurusAccountDetails>(Configuration.GetSection("ThesaurusCreds"));
            services.Configure<SiteDetails>(Configuration.GetSection("SiteCreds"));
            services.Configure<MongoSettings>(Configuration.GetSection("DatabaseSettings"));

            // Inject all services and tools
            services.AddSingleton<SpewRepository>();

            services.AddScoped<ICommandFactory, CommandFactory>();
            services.AddScoped<IHttpClientWrapper, HttpClientWrapper>();
            services.AddScoped<IBotTool, BotTool>();
            services.AddScoped<ITextTool, TextTool>();
            services.AddScoped<IGroupmeTool, GroupmeTool>();
            services.AddScoped<IAwardsTool, AwardsTool>();
            services.AddScoped<IThesaurusTool, ThesaurusTool>();
            services.AddScoped<ITwitchTool, TwitchTool>();

            // Add ability to parse JSON to C# enums
            services.AddControllers().AddJsonOptions(x => { x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";
                spa.Options.StartupTimeout = new TimeSpan(0, 5, 0);

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
