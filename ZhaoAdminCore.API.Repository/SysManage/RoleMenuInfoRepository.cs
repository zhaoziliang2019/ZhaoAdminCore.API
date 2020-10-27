/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/19 10:38:32
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： PermissionRoleMenuInfoRepository
** 描    述： PermissionRoleMenuInfoRepository
********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZhaoAdminCore.API.IRepository.SysManage;
using ZhaoAdminCore.API.IRepository.UnitOfWork;
using ZhaoAdminCore.API.Model.Models;
using ZhaoAdminCore.API.Repository.BASE;

namespace ZhaoAdminCore.API.Repository.SysManage
{
    public class RoleMenuInfoRepository: BaseRepository<RoleMenuInfo>, IRoleMenuInfoRepository
    {
        public RoleMenuInfoRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }
        /// <summary>
        /// 根据角色id获取权限列表
        /// </summary>
        /// <param name="rids"></param>
        /// <returns></returns>
        public async Task<List<RoleMenuInfo>> GetRoleMenuInfos(List<int> rids)
        {
            return await Task.Run(()=>Db.Queryable<RoleMenuInfo>().In(n=>n.rID, rids).ToList());
        }
    }
}
