/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/21 18:11:18
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： UserRoleService
** 描    述： UserRoleService
********************************************************************/
using ZhaoAdminCore.API.IRepository.SysManage;
using ZhaoAdminCore.API.IServices.SysManage;
using ZhaoAdminCore.API.Model.Models;
using ZhaoAdminCore.API.Services.BASE;

namespace ZhaoAdminCore.API.Services.SysManage
{
    public class UserRoleService: BaseService<UserRoleInfo>,IUserRoleService
    {
        private readonly IUserRoleRepository userRoleRepository;

        public UserRoleService(IUserRoleRepository _userRoleRepository)
        {
            userRoleRepository = _userRoleRepository;
            this.BaseDal = _userRoleRepository;
        }
    }
}
