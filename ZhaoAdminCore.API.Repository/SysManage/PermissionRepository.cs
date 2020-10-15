/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/13 14:30:42
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： PermissionRepository
** 描    述： PermissionRepository
********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZhaoAdminCore.API.IRepository.SysManage;
using ZhaoAdminCore.API.IRepository.UnitOfWork;
using ZhaoAdminCore.API.Model.Models;
using ZhaoAdminCore.API.Repository.BASE;

namespace ZhaoAdminCore.API.Repository.SysManage
{
    public class PermissionRepository: BaseRepository<Permissioninfo>, IPermissionRepository
    {
        public PermissionRepository(IUnitOfWork unitOfWork) :base(unitOfWork)
        {

        }
    }
}
