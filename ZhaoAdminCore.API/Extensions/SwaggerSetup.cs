using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace ZhaoAdminCore.API.Extensions
{
    /// <summary>
    /// 配置Swagger
    /// </summary>
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v0.1.0",
                    Title = "ZhaoAdminCore.API",
                    Description = "框架说明文档"
                });
                c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "ZhaoAdminCore.API.xml"),true);
                c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "ZhaoAdminCore.API.Model.xml"),true);
                //解决相同类名会报错的问题
                //c.CustomSchemaIds(type=>type.FullName);
                //添加对控制器标签的描述
               // c.DocumentFilter<ApplyTagDescriptions>();
            });

            #endregion
        }
    }
}
