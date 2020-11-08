/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/11/8 16:29:22
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： OrderInfoService
** 描    述： OrderInfoService
********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZhaoAdminCore.API.IRepository.Order;
using ZhaoAdminCore.API.IServices.Order;
using ZhaoAdminCore.API.Model.Models;
using ZhaoAdminCore.API.Services.BASE;

namespace ZhaoAdminCore.API.Services.Order
{
    public class OrderInfoService:BaseService<OrderInfo>, IOrderInfoService
    {
        private readonly IOrderInfoRepository _orderInfoRepository;

        public OrderInfoService(IOrderInfoRepository orderInfoRepository)
        {
            _orderInfoRepository = orderInfoRepository;
            this.BaseDal = orderInfoRepository;
        }
    }
}
