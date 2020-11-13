using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhaoAdminCore.API.IServices.LogisticsProgress;
using ZhaoAdminCore.API.Model;
using ZhaoAdminCore.API.Model.Models;

namespace ZhaoAdminCore.API.Controllers
{
    /// <summary>
    /// 物流信息
    /// </summary>
    [Route("api/logisticsprogresss")]
    [ApiController]
    public class LogisticsProgressController : ControllerBase
    {
        private readonly ILogisticsProgressInfoService _logisticsProgressInfoService;

        public LogisticsProgressController(ILogisticsProgressInfoService logisticsProgressInfoService)
        {
            _logisticsProgressInfoService = logisticsProgressInfoService;
        }
        /// <summary>
        /// 快递
        /// </summary>
        /// <param name="order_number"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("kuaidi")]
        public async Task<MessageModel<List<LogisticsProgressInfo>>> GetLogisticsProgressInfosByOrderNumber(string order_number)
        {
            var data = new MessageModel<List<LogisticsProgressInfo>>();
            if (string.IsNullOrEmpty(order_number) ||string.IsNullOrWhiteSpace(order_number))
            {
                data.success = false;
                data.msg = "订单号不能为空！";
                return data;
            }
           var list= await _logisticsProgressInfoService.Query(n=>n.order_number== order_number);
            if (list.Count>0)
            {
                data.success = true;
                data.response = list;
                data.msg = "获取物流进度成功！";
            }
            return data;
        }
    }
}
