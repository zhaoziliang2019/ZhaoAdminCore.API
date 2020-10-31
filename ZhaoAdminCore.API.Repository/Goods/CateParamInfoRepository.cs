/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/30 14:01:43
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： CateParamInfoRepository
** 描    述： CateParamInfoRepository
********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZhaoAdminCore.API.IRepository.Goods;
using ZhaoAdminCore.API.IRepository.UnitOfWork;
using ZhaoAdminCore.API.Model.Models;
using ZhaoAdminCore.API.Repository.BASE;

namespace ZhaoAdminCore.API.Repository.Goods
{
    public class CateParamInfoRepository: BaseRepository<CateParamInfo>,ICateParamInfoRepository
    {
        public CateParamInfoRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }
    }
}
