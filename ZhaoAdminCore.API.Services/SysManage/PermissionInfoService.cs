/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/19 13:42:52
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： PermissionInfoService
** 描    述： PermissionInfoService
********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZhaoAdminCore.API.IRepository.SysManage;
using ZhaoAdminCore.API.IServices.SysManage;
using ZhaoAdminCore.API.Model.Models;
using ZhaoAdminCore.API.Services.BASE;

namespace ZhaoAdminCore.API.Services.SysManage
{
    public class PermissionInfoService: BaseService<PermissionInfo>, IPermissionInfoService
    {
        private readonly IPermissionInfoRepository permissionInfoRepository;

        public PermissionInfoService(IPermissionInfoRepository _permissionInfoRepository)
        {
            permissionInfoRepository = _permissionInfoRepository;
            this.BaseDal = _permissionInfoRepository;
        }
    }
}
