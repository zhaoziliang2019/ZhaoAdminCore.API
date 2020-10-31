/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/28 9:20:35
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： AspNetUser
** 描    述： AspNetUser
********************************************************************/
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using ZhaoAdminCore.API.Common.Helper;

namespace ZhaoAdminCore.API.Common.HttpContextUser
{
    public class LoginUser : ILoginUser
    {
        private readonly IHttpContextAccessor accessor;

        public LoginUser(IHttpContextAccessor _accessor)
        {
            accessor = _accessor;
        }
        public string Name => GetName();

        private string GetName()
        {
            if (IsAuthenticated())
            {
                return accessor.HttpContext.User.Identity.Name;
            }
            else
            {
                if (!string.IsNullOrEmpty(GetToken()))
                {
                    return GetUserInfoFromToken("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").FirstOrDefault().ObjToString();
                }
            }

            return "";
        }
        public int ID => GetUserInfoFromToken("jti").FirstOrDefault().ObjToInt();

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return accessor.HttpContext.User.Claims;
        }

        public List<string> GetClaimValueByType(string ClaimType)
        {
            return (from item in GetClaimsIdentity()
                    where item.Type == ClaimType
                    select item.Value).ToList();
        }

        public string GetToken()
        {
            return accessor.HttpContext.Request.Headers["Authorization"].ObjToString().Replace("Bearer ", "");
        }

        public List<string> GetUserInfoFromToken(string ClaimType)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            if (!string.IsNullOrEmpty(GetToken()))
            {
                JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(GetToken());

                return (from item in jwtToken.Claims
                        where item.Type == ClaimType
                        select item.Value).ToList();
            }
            else
            {
                return new List<string>() { };
            }
        }

        public bool IsAuthenticated()
        {
            return accessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
