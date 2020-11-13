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
        /// <summary>
        /// 主键
        /// </summary>
        public int order_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int user_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string order_number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal order_price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int order_pay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Is_send { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string trade_no { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string order_fapiao_title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string order_fapiao_company { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string  order_fapiao_content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string consignee_addr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pay_status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? creat_time { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? update_time { get; set; }
    }
}
