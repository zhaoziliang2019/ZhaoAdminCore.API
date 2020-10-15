/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/10 10:22:37
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： SysUserService
** 描    述： SysUserService
********************************************************************/
using ZhaoAdminCore.API.IRepository.SysManage;
using ZhaoAdminCore.API.IServices.SysManage;
using ZhaoAdminCore.API.Model.Models;
using ZhaoAdminCore.API.Services.BASE;

namespace ZhaoAdminCore.API.Services.SysManage
{
    public class SysUserService : BaseService<SysUserInfo>, ISysUserService
    {
        private readonly ISysUserRepository sysUserRepository;

        public SysUserService(ISysUserRepository _sysUserRepository)
        {
            base.BaseDal = _sysUserRepository;
            sysUserRepository = _sysUserRepository;
        }
    }
}
