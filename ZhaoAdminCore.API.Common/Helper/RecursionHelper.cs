/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/13 14:52:56
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： RecursionHelper
** 描    述： RecursionHelper
********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZhaoAdminCore.API.Common.Helper
{
    /// <summary>
    /// 递归帮助类
    /// </summary>
    public class RecursionHelper
    {
        public static void LoopNaviBarAppendChildren(List<NavigationBar> all, NavigationBar curItem)
        {

            var subItems = all.Where(ee => ee.pid == curItem.id).ToList();

            if (subItems.Count > 0)
            {
                curItem.children = new List<NavigationBar>();
                curItem.children.AddRange(subItems);
            }
            else
            {
                curItem.children = null;
            }


            foreach (var subItem in subItems)
            {
                LoopNaviBarAppendChildren(all, subItem);
            }
        }
    }

    public class NavigationBar
    {
        public int id { get; set; }
        public int pid { get; set; }
        public int order { get; set; }
        public string name { get; set; }
        public bool IsHide { get; set; } = false;
        public bool IsButton { get; set; } = false;
        public string path { get; set; }
        public string Func { get; set; }
        public string iconCls { get; set; }
        public List<NavigationBar> children { get; set; }
    }
}
