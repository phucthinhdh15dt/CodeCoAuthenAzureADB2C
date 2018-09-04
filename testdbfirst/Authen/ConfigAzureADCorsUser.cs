using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testdbfirst.Authen
{
    public static class ConfigAzureADCorsUser
    {
        public static void AzureADCorsUserConfig(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseCors(builder =>
            builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());
        }
    }
}
