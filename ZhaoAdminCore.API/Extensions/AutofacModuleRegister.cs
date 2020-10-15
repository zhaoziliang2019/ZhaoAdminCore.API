using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ZhaoAdminCore.API.Extensions
{
    public class AutofacModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var basePath = AppContext.BaseDirectory;
            #region 接口层注入
            var servicesDllFile = Path.Combine(basePath, "ZhaoAdminCore.API.Services.dll");
            var repositoryDllFile = Path.Combine(basePath, "ZhaoAdminCore.API.Repository.dll");
            // 获取 Service.dll 程序集服务，并注册
            var assemblysServices = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(assemblysServices)
                          .AsImplementedInterfaces()
                          .InstancePerDependency();

            // 获取 Repository.dll 程序集服务，并注册
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository)
                       .AsImplementedInterfaces()
                       .InstancePerDependency();
            #endregion
        }
    }
}
