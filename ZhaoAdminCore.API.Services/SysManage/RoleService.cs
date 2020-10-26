/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/16 17:32:26
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： RoleService
** 描    述： RoleService
********************************************************************/
using ZhaoAdminCore.API.IRepository.SysManage;
using ZhaoAdminCore.API.IServices.SysManage;
using ZhaoAdminCore.API.Model.Models;
using ZhaoAdminCore.API.Services.BASE;

namespace ZhaoAdminCore.API.Services.SysManage
{
    public class RoleService: BaseService<RoleInfo>,IRoleService
    {
        private readonly IRoleRepository roleRepository;

        public RoleService(IRoleRepository _roleRepository)
        {
            roleRepository = _roleRepository;
            this.BaseDal = _roleRepository;
        }
    }
}
