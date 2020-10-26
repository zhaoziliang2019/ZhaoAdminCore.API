/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/16 17:29:46
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： RoleRepository
** 描    述： RoleRepository
********************************************************************/
using ZhaoAdminCore.API.IRepository.SysManage;
using ZhaoAdminCore.API.IRepository.UnitOfWork;
using ZhaoAdminCore.API.Model.Models;
using ZhaoAdminCore.API.Repository.BASE;

namespace ZhaoAdminCore.API.Repository.SysManage
{
    public class RoleRepository : BaseRepository<RoleInfo>, IRoleRepository
    {
        public RoleRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }
    }
}
