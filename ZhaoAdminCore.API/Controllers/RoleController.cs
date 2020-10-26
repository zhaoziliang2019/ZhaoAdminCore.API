using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using ZhaoAdminCore.API.Common.Helper;
using ZhaoAdminCore.API.IServices.SysManage;
using ZhaoAdminCore.API.Model;
using ZhaoAdminCore.API.Model.Models;

namespace ZhaoAdminCore.API.Controllers
{
    //角色管理
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;
        private readonly IPermissionRoleMenuInfoService permissionRoleMenuInfoService;
        private readonly IMenuinfoService menuinfoService;
        private readonly IPermissionInfoService permissionInfoService;

        public RoleController(IRoleService _roleService, IPermissionRoleMenuInfoService _permissionRoleMenuInfoService, IMenuinfoService _menuinfoService, IPermissionInfoService _permissionInfoService)
        {
            roleService = _roleService;
            permissionRoleMenuInfoService = _permissionRoleMenuInfoService;
            menuinfoService = _menuinfoService;
            permissionInfoService = _permissionInfoService;
        }
        /// <summary>
        /// 获取所有的角色下的权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        public async Task<MessageModel<RoleMenuPermission>> Get()
        {
            var data = new MessageModel<RoleMenuPermission>();
            var roles = await roleService.Query(n => n.rIsDelete == false);
            var pRMlist = await permissionRoleMenuInfoService.GetPermissionRoleMenuInfos(roles.Select(n => n.rID).ToList());
            //if (pRMlist.Count == 0)
            //{
            //    data.success = false;
            //    data.msg = "未配置该用户的权限";
            //    return data;
            //}
            var mList = await menuinfoService.Query(n => n.mIsDeleted == false);

            var pList = await permissionInfoService.QueryByIDs(pRMlist.Select(n => n.pID.ToString()).Distinct().ToArray());

            RoleMenuPermission roleMenuPermission = RoleMenuPermissionHelper.GetRoleMenuPermissions(roles, pRMlist, mList, pList);
            data.success = true;
            data.response = roleMenuPermission;
            data.msg = "获取权限列表成功！";
            return data;
        }
        /// <summary>
        /// 获取所有的角色供用户绑定
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("rolelist")]
        public async Task<MessageModel<List<RoleInfo>>> GetRoles()
        {
            var data = new MessageModel<List<RoleInfo>>();
            var rolelist= await roleService.Query(n => n.rIsDelete == false);
            data.success = rolelist.Count > 0;
            if (data.success)
            {
                data.msg = "获取角色列表成功！";
                data.response = rolelist;
            }
            return data;
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("addrole")]
        public async Task<MessageModel<string>> Post(RoleInfo roleInfo)
        {
            var data = new MessageModel<string>();
            data.success=await roleService.Add(roleInfo)>0;
            if (data.success)
            {
                data.msg = "添加角色成功！";
            }
            return data;
        }
        /// <summary>
        /// 获取单个角色信息
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getrole")]
        public async Task<MessageModel<RoleInfo>> GetRoleInfoById(int rid)
        {
            var data = new MessageModel<RoleInfo>();
            if (rid==0)
            {
                data.success = false;
                data.msg = "获取该角色的信息失败！";
                return data;
            }
            var model = await roleService.QueryById(rid);
            data.success = model != null;
            if (data.success)
            {
                data.msg = "获取该角色的信息成功!";
                data.response = model;
            }
            return data;
        }
        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updaterole")]
        public async Task<MessageModel<string>> UpdateRoleInfo(RoleInfo roleInfo)
        {
            var data = new MessageModel<string>();
            data.success = await roleService.Update(roleInfo);
            if (data.success)
            {
                data.msg = "更新角色信息成功！";
            }
            return data;
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<MessageModel<string>> DeleteRoleInfo(int rid)
        {
            var data = new MessageModel<string>();
            if (rid==0)
            {
                data.success = false;
                data.msg = "删除该角色失败！";
                return data;
            }
            //物理上的删除，不是真正删除
            var role = await roleService.QueryById(rid);
            if (role==null)
            {
                data.success = false;
                data.msg = "删除该角色失败！";
                return data;
            }
            role.rIsDelete = true;
            data.success = await roleService.Update(role);
            if (data.success)
            {
                data.msg = "删除该角色成功！";
            }
            return data;
        }
    }
}
