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
            services.AddSingleton<IRedisCacheManager, RedisCacheManager>();//ע��redis
            services.AddSingleton(new AppsettingHelper(Configuration));//ע���ȡappsettings.json����
            services.AddMemoryCache();
            services.AddSqlsugarSetup();//ע��sqlsugar�����ַ���
            services.AddDbSetup();//ע�����ݿ�
            services.AddCorsSetup();//ע���Խ
            services.AddMiniProfilerSetup();
            services.AddHttpContextSetup();//��ȡ��ǰ��¼�û�
            services.AddSwaggerSetup();//����Swagger
            services.AddIpPolicyRateLimitSetup(Configuration);//ע��IP����
            services.AddControllers();
        }
        /// <summary>
        /// AutoFacע��ӿں�ʵ����
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModuleRegister());
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Ip����,�����Źܵ����
            app.UseIpRateLimiting();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //�����м����������Swagger��ΪJSON�ս��
            app.UseSwagger();
            //�����м�������swagger-ui��ָ��Swagger JSON�ս��
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZhaoAdminCore.API");
                c.IndexStream = () => GetType().GetTypeInfo().Assembly.GetManifestResourceStream("ZhaoAdminCore.API.index.html");
            });

            app.UseCors("LimitRequests");//������Խ
            app.UseRouting();

            app.UseAuthorization();
            // ���ܷ���
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
