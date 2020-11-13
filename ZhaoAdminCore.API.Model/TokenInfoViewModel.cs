/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/9 11:26:48
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： TokenInfoViewModel
** 描    述： TokenInfoViewModel
********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace ZhaoAdminCore.API.Model
{
    /// <summary>
    /// token信息
    /// </summary>
    public class TokenInfoViewModel
    {
        /// <summary>
        /// 成功失败
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// token值
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// token有效时长
        /// </summary>
        public double expires_in { get; set; }
        /// <summary>
        /// token类型
        /// </summary>
        public string token_type { get; set; }
    }
}
