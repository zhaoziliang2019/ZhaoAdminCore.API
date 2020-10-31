/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/29 21:39:07
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： CateGorieInfoService
** 描    述： CateGorieInfoService
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
    public class CateGorieInfoService:BaseService<CateGorieInfo>, ICateGorieInfoService
    {
        private readonly ICateGorieInfoRepository cateGorieInfoRepository;

        public CateGorieInfoService(ICateGorieInfoRepository _cateGorieInfoRepository)
        {
            cateGorieInfoRepository = _cateGorieInfoRepository;
            this.BaseDal = _cateGorieInfoRepository;
        }
    }
}
