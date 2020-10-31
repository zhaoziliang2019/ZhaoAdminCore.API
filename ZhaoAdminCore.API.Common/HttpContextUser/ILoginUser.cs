/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/28 9:20:06
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： IUser
** 描    述： IUser
********************************************************************/

using System.Collections.Generic;
using System.Security.Claims;

namespace ZhaoAdminCore.API.Common.HttpContextUser
{
    public interface ILoginUser
    {
        string Name { get; }
        int ID { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
        List<string> GetClaimValueByType(string ClaimType);

        string GetToken();
        List<string> GetUserInfoFromToken(string ClaimType);
    }
}
