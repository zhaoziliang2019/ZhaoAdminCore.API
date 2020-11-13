/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/11/8 21:39:50
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： LogisticsProgressInfo
** 描    述： LogisticsProgressInfo
********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace ZhaoAdminCore.API.Model.Models
{
    /// <summary>
    /// 物流信息
    /// </summary>
    public class LogisticsProgressInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? time { get; set; }
        /// <summary>
        /// 到达时间
        /// </summary>
        public DateTime? ftime { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string context { get; set; }
        /// <summary>
        /// 当前位置
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string order_number { get; set; }
    }
}
