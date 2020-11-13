using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ZhaoAdminCore.API.AuthHelper;
using ZhaoAdminCore.API.Common.Helper;
using ZhaoAdminCore.API.IServices.SysManage;
using ZhaoAdminCore.API.Model;

namespace ZhaoAdminCore.API.Controllers
{
    /// <summary>
    /// 登录管理
    /// </summary>
    [Route("api/login")]
    [ApiController]
    [AllowAnonymous]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly ISysUserService sysUserService;

        public LoginController(ISysUserService sysUserService)
        {
            this.sysUserService = sysUserService;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("login1.0")]
        public async Task<MessageModel<TokenInfoViewModel>> GetLogin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) &&string.IsNullOrWhiteSpace(password))
            {
                return new MessageModel<TokenInfoViewModel>()
                {
                    success = false,
                    msg = "用户名或者密码为空"
                };
            }
            password = MD5Helper.MD5Encrypt32(password);
            
            var user =await sysUserService.Query(n=>n.uLoginName== username && n.uPassWord== password && n.uIsDelete==false);
            if (user.Count>0)
            {
                //查询该用户所属的角色

                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, user.FirstOrDefault().uRealName),
                    new Claim(JwtRegisteredClaimNames.Jti, user.FirstOrDefault().uID.ToString()),
                    new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(60).ToString()) };
                var token = JwtToken.BuildJwtToken(claims.ToArray());
                //更新登录用户的最近一次登录时间
                user.FirstOrDefault().uLastErrTime = DateTime.Now;
                await sysUserService.Update(user.FirstOrDefault());
                return new MessageModel<TokenInfoViewModel>()
                {
                    success = true,
                    msg = "获取成功",
                    response= token
                };
            }
            else
            {
                user = await sysUserService.Query(n => n.uLoginName == username&& n.uIsDelete == false);
                //错误一次减去一次机会
                user.FirstOrDefault().uLastErrTime = DateTime.Now;
                if (user.FirstOrDefault().uErrorCount>0)
                {
                    user.FirstOrDefault().uErrorCount -= 1;
                    await sysUserService.Update(user.FirstOrDefault());
                    return new MessageModel<TokenInfoViewModel>()
                    {
                        success = false,
                        msg = $"认证失败,还有{user.FirstOrDefault().uErrorCount}登录机会",
                    };
                }
                else
                {
                    return new MessageModel<TokenInfoViewModel>()
                    {
                        success = false,
                        msg = $"认证失败,此账号错误次数太多已被锁定!",
                    };
                }
               
            }
        }
    }
}
