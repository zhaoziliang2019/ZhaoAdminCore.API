using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZhaoAdminCore.API.Common.Helper;
using ZhaoAdminCore.API.Model;

namespace ZhaoAdminCore.API.AuthHelper
{
    public class JwtToken
    {
        /// <summary>
        /// 获取基于JWT的Token
        /// </summary>
        /// <param name="claims">需要在登陆的时候配置</param>
        /// <returns></returns>
        public static TokenInfoViewModel BuildJwtToken(Claim[] claims)
        {
            var symmetricKeyAsBase64 = "sdfsdfsrty45634kkhllghtdgdfss345t678fs";
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            var Issuer = AppsettingHelper.GetValue(new string[] { "Audience", "Issuer" });
            var Audience = AppsettingHelper.GetValue(new string[] { "Audience", "Audience" });

            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var now = DateTime.Now;
            // 实例化JwtSecurityToken
            var jwt = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(new TimeSpan(60)),
                signingCredentials: signingCredentials
            );
            // 生成 Token
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            //打包返回前台
            var responseJson = new TokenInfoViewModel
            {
                success = true,
                token = encodedJwt,
                expires_in = 60,
                token_type = "Bearer"
            };
            return responseJson;
        }
    }
}
