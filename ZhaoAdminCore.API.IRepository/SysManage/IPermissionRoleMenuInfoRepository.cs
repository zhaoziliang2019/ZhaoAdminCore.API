/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/19 10:36:57
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： IPermissionRoleMenuInfoRepository
** 描    述： IPermissionRoleMenuInfoRepository
********************************************************************/

using System.Collections.Generic;
using System.Threading.Tasks;
using ZhaoAdminCore.API.IRepository.BASE;
using ZhaoAdminCore.API.Model.Models;

namespace ZhaoAdminCore.API.IRepository.SysManage
{
    public interface IPermissionRoleMenuInfoRepository : IBaseRepository<PermissionRoleMenuInfo>
    {
        public Task<List<PermissionRoleMenuInfo>> GetPermissionRoleMenuInfos(List<int> rids);
    }
}
