﻿/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/13 14:42:10
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： PermissionService
** 描    述： PermissionService
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
    public class PermissionService : BaseService<Permissioninfo>, IPermissionService
    {
        private readonly IPermissionRepository permissionRepository;

        public PermissionService(IPermissionRepository _permissionRepository)
        {
            permissionRepository = _permissionRepository;
            this.BaseDal = _permissionRepository;
        }
    }
}
