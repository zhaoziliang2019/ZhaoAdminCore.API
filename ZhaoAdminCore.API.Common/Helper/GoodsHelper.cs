/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/29 22:04:12
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： GoodsHelper
** 描    述： GoodsHelper
********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZhaoAdminCore.API.Model.Models;

namespace ZhaoAdminCore.API.Common.Helper
{
    public class GoodsHelper
    {
        /// <summary>
        /// 获取所以的分类父级
        /// </summary>
        /// <param name="cList"></param>
        /// <returns></returns>
        public static List<CateGorieInfo> GetParentCateGorieInfos(List<CateGorieInfo> cList)
        {
            List<CateGorieInfo> Root = new List<CateGorieInfo>();
            foreach (var item in cList.FindAll(n=>n.cat_Pid==0))
            {
                AppendChildren(cList,item);
                Root.Add(item);
            }
            return Root;
        }
        /// <summary>
        /// 获取分页分类父级和子级
        /// </summary>
        /// <param name="cList"></param>
        /// <param name="allList"></param>
        /// <returns></returns>
        public static List<CateGorieInfo> GetCateGorieInfoLists(List<CateGorieInfo> cList,List<CateGorieInfo> allList)
        {
            List<CateGorieInfo> Root = new List<CateGorieInfo>();
            foreach (var item in cList.FindAll(n => n.cat_Pid == 0))
            {
                AppendChildren(allList, item);
                Root.Add(item);
            }
            return Root;
        }
        //递归所有的孩子
        private static void AppendChildren(List<CateGorieInfo> all, CateGorieInfo Item)
        {

            var subItems = all.Where(ee => ee.cat_Pid == Item.cat_ID).ToList();

            if (subItems.Count > 0)
            {
                Item.children = new List<CateGorieInfo>();
                Item.children.AddRange(subItems);
            }
            else
            {
                Item.children = null;
            }

            foreach (var subItem in subItems)
            {
                AppendChildren(all, subItem);
            }
        }
    }
}
