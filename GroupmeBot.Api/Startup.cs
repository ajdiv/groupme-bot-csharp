using GroupmeBot.Data.Commands;
using GroupmeBot.Data.Models.GroupMe;
using GroupmeBot.Data.Models.Thesaurus;
using GroupmeBot.Data.Tools;
using GroupmeBot.WebHelpers.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

            // Configure and register "secrets" object 
            services.Configure<GroupmeBotAccountDetails>(Configuration.GetSection("GroupmeCreds"));
            services.Configure<ThesaurusAccountDetails>(Configuration.GetSection("ThesaurusCreds"));

            // Inject all services and tools
            services.AddScoped<ICommandFactory, CommandFactory>();
            services.AddScoped<IHttpClientWrapper, HttpClientWrapper>();
            services.AddScoped<IBotTool, BotTool>();
            services.AddScoped<ICoolGuyTool, CoolGuyTool>();
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
