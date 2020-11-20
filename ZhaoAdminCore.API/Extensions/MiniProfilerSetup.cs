using Microsoft.Extensions.DependencyInjection;
using StackExchange.Profiling.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZhaoAdminCore.API.Extensions
{
    //MiniProfiler 启动服务
    public static class MiniProfilerSetup
    {
        //官网https://miniprofiler.com/dotnet/AspDotNetCore
        public static void AddMiniProfilerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddMiniProfiler(options =>
            {
                options.RouteBasePath = "/profiler";
                options.PopupRenderPosition = StackExchange.Profiling.RenderPosition.Left;
                options.PopupShowTimeWithChildren = true;
            }
           );
        }
    }
}
