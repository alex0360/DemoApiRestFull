using Microsoft.AspNetCore.Mvc;

namespace WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddApiVersion(this IServiceCollection services)
        {
            services.AddApiVersioning(configuration =>
            {
                configuration.DefaultApiVersion = new ApiVersion(1, 0);

                configuration.AssumeDefaultVersionWhenUnspecified = true;

                configuration.ReportApiVersions = true;
            });
        }
    }
}