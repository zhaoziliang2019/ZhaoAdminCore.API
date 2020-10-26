/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/16 10:05:21
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： InterfacesService
** 描    述： InterfacesService
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
    public class InterfacesService: BaseService<InterfacesInfo>,IInterfacesService
    {
        private readonly IInterfacesRepository interfacesRepository;

        public InterfacesService(IInterfacesRepository _interfacesRepository)
        {
            this.interfacesRepository = _interfacesRepository;
            this.BaseDal = _interfacesRepository;
        }
    }
}
