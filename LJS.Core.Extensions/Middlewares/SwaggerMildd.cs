using LJS.Core.Common;
using Microsoft.AspNetCore.Builder;
using System;
using System.IO;
using System.Linq;
using static LJS.Core.Extensions.CustomApiVersion;

namespace LJS.Core.Extensions
{
    /// <summary>
    /// Swagger中间件
    /// </summary>
    public static class SwaggerMildd
    {
        public static void UseSwaggerMildd(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                var ApiName = AppSettings.app(new string[] { "Startup", "ApiName" });
                typeof(ApiVersions).GetEnumNames().OrderByDescending(e => e).ToList().ForEach(version =>
                {
                    c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{ApiName} {version}");
                });
                c.RoutePrefix = "";
            });
        }
    }
}
