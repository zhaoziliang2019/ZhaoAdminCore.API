using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using ZhaoAdminCore.API.Common.Helper;
using ZhaoAdminCore.API.Common.HttpContextUser;
using ZhaoAdminCore.API.IRepository.UnitOfWork;
using ZhaoAdminCore.API.IServices.SysManage;
using ZhaoAdminCore.API.Model;
using ZhaoAdminCore.API.Model.Models;

namespace ZhaoAdminCore.API.Controllers
{
   /// <summary>
   /// 角色管理
   /// </summary>
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;
        private readonly IRoleMenuInfoService roleMenuInfoService;
        private readonly IMenuinfoService menuinfoService;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILoginUser loginUser;

        public RoleController(IRoleService _roleService, IRoleMenuInfoService _roleMenuInfoService, IMenuinfoService _menuinfoService, IUnitOfWork _unitOfWork, ILoginUser _loginUser)
        {
            roleService = _roleService;
            roleMenuInfoService = _roleMenuInfoService;
            menuinfoService = _menuinfoService;
            unitOfWork = _unitOfWork;
            loginUser = _loginUser;
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
            var rList = await roleService.Query(n => n.rIsDelete == false);
            var mList = await menuinfoService.Query(m => m.mIsDeleted == false);
            var rmList = await roleMenuInfoService.Query();
            data.success = true;
            data.response = RoleMenuHelper.GetRoleMenuList(rList, mList, rmList);
            return data;
        }
        /// <summary>
        /// 获取分配权限树
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("tree")]
        public async Task<MessageModel<List<RoleMenuTree>>> GetRoleMenuTree()
        {
            var data = new MessageModel<List<RoleMenuTree>>();
            var mList = await menuinfoService.Query(m => m.mIsDeleted == false);
            data.response = RoleMenuHelper.GetRoleMenuTree(mList);
            data.success = true;
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
            roleInfo.rCreateBy = loginUser.Name;
            roleInfo.rCreateId = loginUser.ID;
            data.success = await roleService.Add(roleInfo) > 0;
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
            if (rid == 0)
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
            roleInfo.rModifyBy = loginUser.Name;
            roleInfo.rModifyId = loginUser.ID;
            roleInfo.rUpdateTime = DateTime.Now;
            data.success = await roleService.Update(roleInfo);
            if (data.success)
            {
                data.msg = "更新角色信息成功！";
            }
            return data;
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        public async Task<MessageModel<string>> DeleteRoleInfo(int rid)
        {
            var data = new MessageModel<string>();
            if (rid == 0)
            {
                data.success = false;
                data.msg = "删除该角色失败！";
                return data;
            }
            //物理上的删除，不是真正删除
            var role = await roleService.QueryById(rid);
            if (role == null)
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
        /// <summary>
        /// 角色用户分配权限
        /// </summary>
        /// <param name="roleMenuInfo">角色信息</param>
        /// <returns></returns>
        [HttpPost]
        [Route("setrolemenu")]
        public async Task<MessageModel<string>> SetRoleMenuList(RoleMenuInfo roleMenuInfo)
        {
            var data = new MessageModel<string>();
            if (roleMenuInfo.rID == 0||string.IsNullOrEmpty(roleMenuInfo.mIDs))
            {
                data.success = false;
                data.msg = "分配权限失败！";
                return data;
            }
            try
            {
                unitOfWork.BeginTran();
                var rmids = (await roleMenuInfoService.Query(n => n.rID == roleMenuInfo.rID)).Select(n => n.rmID.ToString()).ToArray();
                //删除该角色下所有权限
                var res=await roleMenuInfoService.DeleteByIds(rmids);
                //添加该角色下所有的权限
                List<int> mRoot = new List<int>();
                //去掉父节点
                foreach (var item in roleMenuInfo.mIDs.Split(','))
                {
                    if((await menuinfoService.QueryById(item)).mPid != 0)
                    {
                        mRoot.Add(int.Parse(item));
                    }
                }
                data.success = true;
                mRoot.ForEach(async rm=>
                {
                    data.success=data.success&&await roleMenuInfoService.Add(new RoleMenuInfo(roleMenuInfo.rID, rm))>0;
                });
                if (data.success)
                {
                    data.msg = "分配权限成功！";
                }
                unitOfWork.CommitTran();
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTran();
            }
            return data;
        }

        /// <summary>
        /// 删除角色菜单关系
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("deletermp")]
        public async Task<MessageModel<List<RoleInfo>>> DeleteRoleMenuInfo(int rid,int mid)
        {
            var data = new MessageModel<List<RoleInfo>>();
            if (rid==0|| mid == 0)
            {
                data.success = false;
                data.msg = "删除权限失败！";
                return data;
            }
            var rmids = (await roleMenuInfoService.Query(n=>n.mID==mid)).Select(n=>n.rmID.ToString()).ToArray();
            data.success = await roleMenuInfoService.DeleteById(rmids);
            var rList = await roleService.Query(n =>n.rID==rid&&n.rIsDelete == false);
            var mList = await menuinfoService.Query(m => m.mIsDeleted == false);
            var rmList = await roleMenuInfoService.Query();
            data.response = RoleMenuHelper.GetRoleMenuList(rList, mList, rmList);
            return data;
        }
    }
}
