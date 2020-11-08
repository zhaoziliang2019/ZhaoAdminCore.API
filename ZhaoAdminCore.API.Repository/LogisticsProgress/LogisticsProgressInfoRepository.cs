/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/11/8 21:51:36
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： LogisticsProgressInfoRepository
** 描    述： LogisticsProgressInfoRepository
********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZhaoAdminCore.API.IRepository.LogisticsProgress;
using ZhaoAdminCore.API.IRepository.UnitOfWork;
using ZhaoAdminCore.API.Model.Models;
using ZhaoAdminCore.API.Repository.BASE;

namespace ZhaoAdminCore.API.Repository.LogisticsProgress
{
    public class LogisticsProgressInfoRepository:BaseRepository<LogisticsProgressInfo>,ILogisticsProgressInfoRepository
    {
        public LogisticsProgressInfoRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }
    }
}
