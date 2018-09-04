
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;
using System.Threading.Tasks;
using testdbfirst.Authen;
using testdbfirst.ConfigService.CORS;
using testdbfirst.ConfigService.Swagger;
using testdbfirst.Repository.ImplRepository;
using testdbfirst.Repository.IRepository;
using testdbfirst.Repository.RepositoryConfig;

namespace testdbfirst
{
    public class Startup
    {
        
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(env.ContentRootPath)
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //authen azure ad b2c
            ConfigServiceAzureADB2C.configAzureActiveDirectoryB2C(services,Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //repository
            ConfigRepository.ConfigRepositoryService(services);
            //cors
            CorsConfig.CorsConfigService(services);
            //swagger
            ConfigSwagger.SwaggerConfigService(services);
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            ConfigAzureADB2C.ConfigAzureADB2CApp(app,Configuration);
            app.UseHttpsRedirection();
            CorsConfig.CorsConfigApp(app);
            app.UseMvc();
            ConfigSwagger.SwaggerConfigApp(app);
            ConfigAzureADCorsUser.AzureADCorsUserConfig(app);

        }
       
    }
}
