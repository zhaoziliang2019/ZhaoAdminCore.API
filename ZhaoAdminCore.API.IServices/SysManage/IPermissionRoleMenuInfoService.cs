/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/19 10:40:31
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： IPermissionRoleMenuInfoService
** 描    述： IPermissionRoleMenuInfoService
********************************************************************/

using System.Collections.Generic;
using System.Threading.Tasks;
using ZhaoAdminCore.API.IServices.BASE;
using ZhaoAdminCore.API.Model.Models;

namespace ZhaoAdminCore.API.IServices.SysManage
{
    public interface IPermissionRoleMenuInfoService : IBaseService<PermissionRoleMenuInfo>
    {
        public Task<List<PermissionRoleMenuInfo>> GetPermissionRoleMenuInfos(List<int> rids);
    }
}
