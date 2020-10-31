using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using ZhaoAdminCore.API.Common.HttpContextUser;

namespace ZhaoAdminCore.API.Extensions
{
    //注入获取登录用户接口类
    public static class HttpContextSetup
    {
        public static void AddHttpContextSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ILoginUser, LoginUser>();
        }
    }
}
