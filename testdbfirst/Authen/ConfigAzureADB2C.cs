using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testdbfirst.Authen
{
    public class ConfigAzureADB2C
    {
        public static string ScopeRead;
        public static string ScopeWrite;
        public static void ConfigAzureADB2CApp(IApplicationBuilder app, IConfiguration Configuration)
        {
            ScopeRead = Configuration["AzureAdB2C:ScopeRead"];
            ScopeWrite = Configuration["AzureAdB2C:ScopeWrite"];
            app.UseAuthentication();

        }
    }
}
