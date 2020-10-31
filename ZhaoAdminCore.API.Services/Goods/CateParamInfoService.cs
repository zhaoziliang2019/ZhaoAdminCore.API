/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/30 14:04:56
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： CateParamInfoService
** 描    述： CateParamInfoService
********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZhaoAdminCore.API.IRepository.Goods;
using ZhaoAdminCore.API.IServices.Goods;
using ZhaoAdminCore.API.Model.Models;
using ZhaoAdminCore.API.Services.BASE;

namespace ZhaoAdminCore.API.Services.Goods
{
    public class CateParamInfoService:BaseService<CateParamInfo>, ICateParamInfoService
    {
        private readonly ICateParamInfoRepository _cateParamInfoRepository;

        public CateParamInfoService(ICateParamInfoRepository cateParamInfoRepository)
        {
            _cateParamInfoRepository = cateParamInfoRepository;
            this.BaseDal = cateParamInfoRepository;
        }
    }
}
