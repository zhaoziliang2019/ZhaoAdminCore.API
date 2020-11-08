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
    public class LogisticsProgressInfo
    {
        public int id { get; set; }
        public DateTime? time { get; set; }
        public DateTime? ftime { get; set; }
        public string context { get; set; }
        public string location { get; set; }
        public string order_number { get; set; }
    }
}
