/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/19 13:40:07
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： PermissionInfoRepository
** 描    述： PermissionInfoRepository
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
    public class PermissionInfoRepository: BaseRepository<PermissionInfo>, IPermissionInfoRepository
    {
        public PermissionInfoRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }
    }
}
