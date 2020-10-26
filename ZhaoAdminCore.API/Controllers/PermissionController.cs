using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhaoAdminCore.API.Common.Helper;
using ZhaoAdminCore.API.IServices.SysManage;
using ZhaoAdminCore.API.Model;
using ZhaoAdminCore.API.Model.Models;

namespace ZhaoAdminCore.API.Controllers
{
    [Route("api/permissions")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IRoleService roleService;
        private readonly IPermissionRoleMenuInfoService permissionRoleMenuInfoService;
        private readonly IMenuinfoService menuinfoService;
        private readonly IPermissionInfoService permissionInfoService;

        public PermissionController(IRoleService _roleService, IPermissionRoleMenuInfoService _permissionRoleMenuInfoService, IMenuinfoService _menuinfoService, IPermissionInfoService _permissionInfoService)
        {
            roleService = _roleService;
            permissionRoleMenuInfoService = _permissionRoleMenuInfoService;
            menuinfoService = _menuinfoService;
            permissionInfoService = _permissionInfoService;
        }
        [HttpGet]
        [Route("trees")]
        public async Task<MessageModel<MenuPermissionRoot>> GetAllPermissions()
        {
            var data = new MessageModel<MenuPermissionRoot>();
            var mList = await menuinfoService.Query(n => n.mIsDeleted == false);
            var pList = await permissionInfoService.Query(n=>n.pIsDelete==false);
            if (mList.Count==0)
            {
                data.success = false;
                data.msg = "获取权限失败!";
            }
            data.success = true;
            data.msg = "获取权限树成功！";
            data.response = RoleMenuPermissionHelper.GetAllMenuPermissions(mList,pList);
            return data;
        }
        /// <summary>
        /// 删除角色菜单权限三者关系
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deletermp")]
        public async Task<MessageModel<RoleMenuPermission>> DeleteRoleMenuPermission(int roleid,int rid=0,int mid=0,int pid=0)
        {
            var data = new MessageModel<RoleMenuPermission>();
            if (rid==0&&mid==0&&pid==0)
            {
                data.success = false;
                data.msg = "删除权限失败！";
                return data;
            }
            List<PermissionRoleMenuInfo> result = null;
            if (rid!=0)
            {
                result=await permissionRoleMenuInfoService.Query(n=>n.rID==rid);
            }
            else if (mid!=0)
            {
                result = await permissionRoleMenuInfoService.Query(n => n.mID == mid);
            }
            else
            {
                result = await permissionRoleMenuInfoService.Query(n => n.pID == pid);
            }
            data.success=await permissionRoleMenuInfoService.DeleteByIds(result.Select(n=>n.pmID.ToString()).ToArray());
            if (data.success)
            {
                data.msg = "删除权限成功！";
                var roles = await roleService.Query(n =>n.rID==roleid &&n.rIsDelete == false);
                var pRMlist = await permissionRoleMenuInfoService.GetPermissionRoleMenuInfos(roles.Select(n => n.rID).ToList());
                if (pRMlist.Count == 0)
                {
                    data.success = false;
                    data.msg = "未配置该用户的权限";
                    return data;
                }
                var mList = await menuinfoService.Query(n => n.mIsDeleted == false);

                var pList = await permissionInfoService.QueryByIDs(pRMlist.Select(n => n.pID.ToString()).Distinct().ToArray());

              data.response=RoleMenuPermissionHelper.GetRoleMenuPermissions(roles, pRMlist, mList, pList);
            }
            return data;
        }
        /// <summary>
        /// 根据key获取所有的权限
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        public async Task<MessageModel<List<MenuPermissionRootList>>> GetPermissionListByKey(string key)
        {
            var data = new MessageModel<List<MenuPermissionRootList>>();
            if (string.IsNullOrEmpty(key)||string.IsNullOrWhiteSpace(key))
            {
                key = "";
            }
            data.success = true;
            var mList = await menuinfoService.Query(n=>n.mIsDeleted==false);
            var pList=await permissionInfoService.Query(n =>n.pIsDelete==false&& (n.pName.Contains(key)||
            n.pCreateBy.Contains(key)));
            data.response = RoleMenuPermissionHelper.GetMenuPermissionList(mList, pList);
            return data;
        }
    }
}
