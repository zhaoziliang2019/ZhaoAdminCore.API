/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/19 10:41:19
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： PermissionRoleMenuInfoService
** 描    述： PermissionRoleMenuInfoService
********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZhaoAdminCore.API.IRepository.SysManage;
using ZhaoAdminCore.API.IServices.SysManage;
using ZhaoAdminCore.API.Model.Models;
using ZhaoAdminCore.API.Services.BASE;

namespace ZhaoAdminCore.API.Services.SysManage
{
    public class PermissionRoleMenuInfoService: BaseService<PermissionRoleMenuInfo>, IPermissionRoleMenuInfoService
    {
        private readonly IPermissionRoleMenuInfoRepository permissionRoleMenuInfoRepository;

        public PermissionRoleMenuInfoService(IPermissionRoleMenuInfoRepository _permissionRoleMenuInfoRepository)
        {
            permissionRoleMenuInfoRepository = _permissionRoleMenuInfoRepository;
            this.BaseDal = _permissionRoleMenuInfoRepository;
        }

        public async Task<List<PermissionRoleMenuInfo>> GetPermissionRoleMenuInfos(List<int> rids)
        {
            return await permissionRoleMenuInfoRepository.GetPermissionRoleMenuInfos(rids);
        }
    }
}
