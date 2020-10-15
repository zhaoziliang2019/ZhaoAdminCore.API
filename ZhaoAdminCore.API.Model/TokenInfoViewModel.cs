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
    public class TokenInfoViewModel
    {
        public bool success { get; set; }
        public string token { get; set; }
        public double expires_in { get; set; }
        public string token_type { get; set; }
    }
}
