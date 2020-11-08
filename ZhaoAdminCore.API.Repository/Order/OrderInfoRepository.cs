/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/11/8 16:26:15
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： OrderInfoRepository
** 描    述： OrderInfoRepository
********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZhaoAdminCore.API.IRepository.Order;
using ZhaoAdminCore.API.IRepository.UnitOfWork;
using ZhaoAdminCore.API.Model.Models;
using ZhaoAdminCore.API.Repository.BASE;

namespace ZhaoAdminCore.API.Repository.Order
{
    public class OrderInfoRepository:BaseRepository<OrderInfo>, IOrderInfoRepository
    {
        public OrderInfoRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }
    }
}
