using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ZhaoAdminCore.API.Common.Helper;
using ZhaoAdminCore.API.Common.Redis;
using ZhaoAdminCore.API.Extensions;

namespace ZhaoAdminCore.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRedisCacheManager, RedisCacheManager>();//注册redis
            services.AddSingleton(new AppsettingHelper(Configuration));//注册读取appsettings.json服务
            services.AddMemoryCache();
            services.AddSqlsugarSetup();//注册sqlsugar连接字符串
            services.AddDbSetup();//注册数据库
            services.AddCorsSetup();//注册跨越
            services.AddMiniProfilerSetup();
            services.AddHttpContextSetup();//获取当前登录用户
            services.AddSwaggerSetup();//配置Swagger
            services.AddIpPolicyRateLimitSetup(Configuration);//注入IP限流
            services.AddControllers();
        }
        /// <summary>
        /// AutoFac注册接口和实现类
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModuleRegister());
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Ip限流,尽量放管道外层
            app.UseIpRateLimiting();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //启用中间件服务生成Swagger作为JSON终结点
            app.UseSwagger();
            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZhaoAdminCore.API");
                c.IndexStream = () => GetType().GetTypeInfo().Assembly.GetManifestResourceStream("ZhaoAdminCore.API.index.html");
            });

            app.UseCors("LimitRequests");//开启跨越
            app.UseRouting();

            app.UseAuthorization();
            // 性能分析
            app.UseMiniProfiler();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
