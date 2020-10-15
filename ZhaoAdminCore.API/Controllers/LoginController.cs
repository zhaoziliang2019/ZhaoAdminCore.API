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
    [Route("api/login")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly ISysUserService sysUserService;

        public LoginController(ISysUserService sysUserService)
        {
            this.sysUserService = sysUserService;
        }
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
                    new Claim(ClaimTypes.Name, username),
                    new Claim(JwtRegisteredClaimNames.Jti, user.FirstOrDefault().uID.ToString()),
                    new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(60).ToString()) };
                var token = JwtToken.BuildJwtToken(claims.ToArray());
                return new MessageModel<TokenInfoViewModel>()
                {
                    success = true,
                    msg = "获取成功",
                    response= token
                };
            }
            else
            {
                return new MessageModel<TokenInfoViewModel>()
                {
                    success = false,
                    msg = "认证失败",
                };
            }
        }
    }
}
