using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using ZhaoAdminCore.API.Common.Helper;
using ZhaoAdminCore.API.IRepository.UnitOfWork;
using ZhaoAdminCore.API.IServices.SysManage;
using ZhaoAdminCore.API.Model;
using ZhaoAdminCore.API.Model.Models;

namespace ZhaoAdminCore.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class SysUserController : ControllerBase
    {
        private readonly ISysUserService sysUserService;
        private readonly IUnitOfWork unitOfWork;

        public SysUserController(ISysUserService _sysUserService, IRepository.UnitOfWork.IUnitOfWork _unitOfWork)
        {
            sysUserService = _sysUserService;
            unitOfWork = _unitOfWork;
        }
        /// <summary>
        /// 获取所有用户数据
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
            return new MessageModel<PageModel<SysUserInfo>>()
            {
                msg = "获取成功",
                success = users.dataCount >= 0,
                response = users
            };
        }
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
            data.success = userinfo.uID > 0;
            data.response = userinfo;
            return data;
        }
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
            data.success = await sysUserService.Update(sysUserInfo);
            if (data.success)
            {
                data.msg = "更新用户信息成功";
            }
            return data;
        }
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
