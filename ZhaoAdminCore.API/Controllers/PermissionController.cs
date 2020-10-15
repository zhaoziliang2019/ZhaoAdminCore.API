using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhaoAdminCore.API.Common.Helper;
using ZhaoAdminCore.API.IServices.SysManage;
using ZhaoAdminCore.API.Model;

namespace ZhaoAdminCore.API.Controllers
{
    [Route("api/Permission/")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService permissionService;

        public PermissionController(IPermissionService _permissionService)
        {
            permissionService = _permissionService;
        }
        [HttpGet]
        [Route("navigation")]
        public async Task<MessageModel<NavigationBar>> GetNavigationBar()
        {
            var data = new MessageModel<NavigationBar>();
            var permissions = await permissionService.Query(t=>t.IsDeleted==false);
            var permissionTrees = (from child in permissions
                                   select new NavigationBar
                                   {
                                       id=child.ID,
                                       pid=child.Pid,
                                       order=child.OrderSort,
                                       name=child.Name,
                                       iconCls=child.Icon,
                                       path=child.Code
                                   }).ToList();
            NavigationBar rootRoot = new NavigationBar()
            {
                id = 0,
                pid = 0,
                order = 0,
                name = "根节点",
                path = "",
                iconCls = "",
            };
            RecursionHelper.LoopNaviBarAppendChildren(permissionTrees, rootRoot);

            data.success = true;
            if (data.success)
            {
                data.response = rootRoot;
                data.msg = "获取成功";
            }
            return data;
        }
    }
}
