using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhaoAdminCore.API.IServices.Order;
using ZhaoAdminCore.API.Model;
using ZhaoAdminCore.API.Model.Models;

namespace ZhaoAdminCore.API.Controllers
{
    /// <summary>
    /// 订单管理
    /// </summary>
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderInfoService _orderInfoService;

        public OrderController(IOrderInfoService orderInfoService)
        {
            _orderInfoService = orderInfoService;
        }
        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="pagenum"></param>
        /// <param name="pagesize"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        public async Task<MessageModel<PageModel<OrderInfo>>> GetOrderInfoList(int pagenum,int pagesize,string query)
        {
            var data = new MessageModel<PageModel<OrderInfo>>();
            if (string.IsNullOrEmpty(query) || string.IsNullOrWhiteSpace(query))
            {
                query = "";
            }
            var orders = await _orderInfoService.QueryPage(n=>n.order_number.Contains(query),pagenum,pagesize);
            data.success = true;
            data.response = orders;
            return data;
        }
    }
}
