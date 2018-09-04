using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testdbfirst.ConfigService.CORS
{
    public static class CorsConfig
    {
        public static void CorsConfigService(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                // BEGIN01
             options.AddPolicy("AllowSpecificOrigins",
             builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );



            });
        }

        public static void CorsConfigApp(IApplicationBuilder app)
        {
            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
        }
    }
}
