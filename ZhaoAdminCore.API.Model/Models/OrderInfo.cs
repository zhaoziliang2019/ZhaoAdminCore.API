/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/11/8 16:04:47
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： OrderInfo
** 描    述： OrderInfo
********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace ZhaoAdminCore.API.Model.Models
{
    /// <summary>
    /// 订单
    /// </summary>
    public class OrderInfo
    {
        public int order_id { get; set; }
        public int user_id { get; set; }
        public string order_number { get; set; }
        public decimal order_price { get; set; }
        public int order_pay { get; set; }
        public int Is_send { get; set; }
        public string trade_no { get; set; }

        public string order_fapiao_title { get; set; }
        public string order_fapiao_company { get; set; }
        public string  order_fapiao_content { get; set; }
        public string consignee_addr { get; set; }
        public int pay_status { get; set; }
        public DateTime? creat_time { get; set; }
        public DateTime? update_time { get; set; }
    }
}
