/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/21 18:08:30
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： UserRoleRepository
** 描    述： UserRoleRepository
********************************************************************/
using ZhaoAdminCore.API.IRepository.SysManage;
using ZhaoAdminCore.API.IRepository.UnitOfWork;
using ZhaoAdminCore.API.Model.Models;
using ZhaoAdminCore.API.Repository.BASE;

namespace ZhaoAdminCore.API.Repository.SysManage
{
    public class UserRoleRepository : BaseRepository<UserRoleInfo>, IUserRoleRepository
    {
        public UserRoleRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }
    }
}
