/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/11/8 21:54:10
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： LogisticsProgressInfoService
** 描    述： LogisticsProgressInfoService
********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZhaoAdminCore.API.IRepository.LogisticsProgress;
using ZhaoAdminCore.API.IServices.LogisticsProgress;
using ZhaoAdminCore.API.Model.Models;
using ZhaoAdminCore.API.Services.BASE;

namespace ZhaoAdminCore.API.Services.LogisticsProgress
{
    public class LogisticsProgressInfoService:BaseService<LogisticsProgressInfo>, ILogisticsProgressInfoService
    {
        private readonly ILogisticsProgressInfoRepository _logisticsProgressInfoRepository;

        public LogisticsProgressInfoService(ILogisticsProgressInfoRepository logisticsProgressInfoRepository)
        {
            _logisticsProgressInfoRepository = logisticsProgressInfoRepository;
            this.BaseDal = logisticsProgressInfoRepository;
        }
    }
}
