using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZhaoAdminCore.API.Common.Helper;
using ZhaoAdminCore.API.IRepository.UnitOfWork;
using ZhaoAdminCore.API.IServices.SysManage;
using ZhaoAdminCore.API.Model;
using ZhaoAdminCore.API.Model.Models;

namespace ZhaoAdminCore.API.Controllers
{
    /// <summary>
    /// 系统用户管理
    /// </summary>
    [Route("api/user")]
    [ApiController]
    public class SysUserController : ControllerBase
    {
        private readonly ISysUserService sysUserService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRoleService userRoleService;
        private readonly IRoleService roleService;

        public SysUserController(ISysUserService _sysUserService, IRepository.UnitOfWork.IUnitOfWork _unitOfWork, IUserRoleService _userRoleService, IRoleService _roleService)
        {
            sysUserService = _sysUserService;
            unitOfWork = _unitOfWork;
            userRoleService = _userRoleService;
            roleService = _roleService;
        }
        /// <summary>
        /// 获取系统所有用户数据
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="pagesize">页数</param>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        [HttpGet]
        [Route("users")]
        public async Task<MessageModel<PageModel<SysUserInfo>>> getUsers(int page=1,int pagesize=20,string key="")
        {
            if (string.IsNullOrWhiteSpace(key)||string.IsNullOrEmpty(key))
            {
                key = "";
            }
            var users = await sysUserService.QueryPage(n=>n.uIsDelete==false&&(n.uLoginName.Contains(key)),page,pagesize);
            var roles = await roleService.Query(d => d.rIsDelete == false);
            foreach (var item in users.data)
            {
                var rids = (await userRoleService.Query(r => r.uID == item.uID)).Select(r=>r.rID).ToList();
                item.rIDs = rids;
                item.rNames = roles.Where(n => rids.Contains(n.rID)).Select(n => n.rName).ToList();
            }
            return new MessageModel<PageModel<SysUserInfo>>()
            {
                msg = "获取成功",
                success = users.dataCount >= 0,
                response = users
            };
        }
        /// <summary>
        /// 更新系统用户状态信息
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("userstate")]
        public async Task<MessageModel<string>> ChangeUserState(int userid, bool status)
        {
            var data = new MessageModel<string>();
            if (userid==0)
            {
                data.success = false;
                data.msg = "更新失败，参数错误";
                return data;
            }
            try
            {
                unitOfWork.BeginTran();
                var user = await sysUserService.QueryById(userid);
                if (user==null)
                {
                    data.success = false;
                    data.msg = "更新失败,该用户不存在";
                    return data;
                }
                user.uIsDelete=status;
                data.success = await sysUserService.Update(user);
                unitOfWork.CommitTran();
                if (data.success)
                {
                    data.msg = "更新成功";
                }
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTran();
            }
            return data;
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sysUserInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("adduser")]
        public async Task<MessageModel<string>> AddUserInfo(SysUserInfo sysUserInfo)
        {
            var data = new MessageModel<string>();
            data.success = false;
            data.msg = "添加失败";
            try
            {
                unitOfWork.BeginTran();
                sysUserInfo.uPassWord = MD5Helper.MD5Encrypt32(sysUserInfo.uPassWord);
                //默认有5次机会登录
                sysUserInfo.uErrorCount = 5;
                var id = await sysUserService.Add(sysUserInfo);
                data.success = id > 0;
                if (data.success)
                {
                    data.msg = "添加成功";
                }
                unitOfWork.CommitTran();
            }
            catch (Exception)
            {
                unitOfWork.RollbackTran();
            }
            return data;
        }
        /// <summary>
        /// 根据id获取用户
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("userinfo")]
        public async Task<MessageModel<SysUserInfo>> GetUserInfo(int uid)
        {
            var data = new MessageModel<SysUserInfo>();
            if (uid==0)
            {
                data.success = false;
                data.msg = "获取用户信息失败！";
                return data;
            }
            var userinfo = await sysUserService.QueryById(uid);
            if (userinfo==null)
            {
                data.success = false;
                data.msg = "该用户信息不存在！";
                return data;
            }
            var userroleids = (await userRoleService.Query(n => n.uID == userinfo.uID)).Select(n => n.rID).ToList();
            userinfo.rIDs = new List<int>();
            userinfo.rIDs = userroleids;
            data.success = userinfo.uID > 0;
            data.response = userinfo;
            return data;
        }
        /// <summary>
        /// 更新系统用户信息
        /// </summary>
        /// <param name="sysUserInfo"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateuser")]
        public async Task<MessageModel<string>> UpdateUserInfo(SysUserInfo sysUserInfo)
        {
            var data = new MessageModel<string>();
            if (sysUserInfo==null||sysUserInfo.uID==0)
            {
                data.success = false;
                data.msg = "更新用户信息失败！";
                return data;
            }
            try
            {
                unitOfWork.BeginTran();
                if (sysUserInfo.rIDs.Count > 0)
                {
                    //该用户下所有的角色都删除
                    var userroleids = (await userRoleService.Query(n => n.uID == sysUserInfo.uID)).Select(n => n.ID.ToString()).ToArray();
                    if (userroleids.Count()>0)
                    {
                        var alluserroleid = await userRoleService.DeleteByIds(userroleids);
                    }
                    //该用户下添加角色
                    var UserRoleAdd = new List<UserRoleInfo>();
                    sysUserInfo.rIDs.ForEach(rid=> {
                        UserRoleAdd.Add(new UserRoleInfo(sysUserInfo.uID,rid));
                    });
                    var addUserRoles = await userRoleService.Add(UserRoleAdd);
                }
                sysUserInfo.uUpdateTime = DateTime.Now;
                data.success = await sysUserService.Update(sysUserInfo);
                unitOfWork.BeginTran();
                if (data.success)
                {
                    data.msg = "更新用户信息成功";
                }
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTran();
            }
            return data;
        }
        /// <summary>
        /// 删除系统用户
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deleteuser")]
        public async Task<MessageModel<string>> DeleteUserInfo(int uid)
        {
            var data = new MessageModel<string>();
            if (uid == 0)
            {
                data.success = false;
                data.msg = "删除该用户信息失败！";
                return data;
            }
            data.success = await sysUserService.DeleteById(uid);
            if (data.success)
            {
                data.msg = "删除该用户信息成功!";
            }
            return data;
        }
    }
}
