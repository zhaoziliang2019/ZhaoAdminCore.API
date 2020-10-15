using Microsoft.Extensions.DependencyInjection;
using System;
using ZhaoAdminCore.API.Seed;

namespace ZhaoAdminCore.API.Extensions
{
    public static class DbSetup
    {
        public static void AddDbSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddScoped<MyDbContext>();
        }
    }
}
