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
using System.ComponentModel;
using System.Linq;
using System.Text;
using ZhaoAdminCore.API.Model.Models;

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
        /// <summary>
        /// 获取菜单选择列表
        /// </summary>
        /// <param name="menulist"></param>
        /// <returns></returns>
        public static MenuOptions GetMenuListOptions(List<MenuInfo> menulist)
        {
            MenuOptions Mroot = new MenuOptions();
            Mroot.children = new List<MenuOptions>();
            MenuOptions root = new MenuOptions();
            root.value = 0;
            root.label = "根节点";
            root.children = new List<MenuOptions>();
            var mRoot = menulist.FindAll(n=>n.mPid==0);//根节点
            foreach (var item in mRoot)
            {
                MenuOptions cRoot = new MenuOptions();
                cRoot.value = item.mID;
                cRoot.label = item.mName;
                root.children.Add(cRoot);
            }
            Mroot.children.Add(root);
            return Mroot;
        }
        /// <summary>
        /// 获取带子菜单的菜单列表
        /// </summary>
        /// <param name="menulist"></param>
        /// <returns></returns>
        public static List<MenuList> GetMenuList(List<MenuInfo> menulist)
        {
            List<MenuList> Mlist = new List<MenuList>();
            var mRoot = menulist.FindAll(n => n.mPid == 0);//根节点
            foreach (var item in mRoot)
            {
                MenuList menuList = new MenuList()
                {
                    mID = item.mID,
                    mName=item.mName,
                    mPid=item.mPid,
                    mCreateBy=item.mCreateBy,
                    mCreateId=item.mCreateId,
                    mCreateTime=item.mCreateTime,
                    mDescription=item.mDescription,
                    mIcon=item.mIcon,
                    mIsDeleted=item.mIsDeleted,
                    mMid=item.mMid,
                    mModifyBy=item.mModifyBy,
                    mModifyId=item.mModifyId,
                    mOrderSort=item.mOrderSort,
                    mPath=item.mPath,
                    mUpdateTime=item.mUpdateTime,
                    arrPid=item.arrPid
                };
                menuList.children = new List<MenuList>();
                var cRoot = menulist.FindAll(n=>n.mPid==item.mID);
                foreach (var citem in cRoot)
                {
                    MenuList cmenuList = new MenuList()
                    {
                        mID = citem.mID,
                        mName = citem.mName,
                        mPid = citem.mPid,
                        mCreateBy = citem.mCreateBy,
                        mCreateId = citem.mCreateId,
                        mCreateTime = citem.mCreateTime,
                        mDescription = citem.mDescription,
                        mIcon = citem.mIcon,
                        mIsDeleted = citem.mIsDeleted,
                        mMid = citem.mMid,
                        mModifyBy = citem.mModifyBy,
                        mModifyId = citem.mModifyId,
                        mOrderSort = citem.mOrderSort,
                        mPath = citem.mPath,
                        mUpdateTime = citem.mUpdateTime,
                        arrPid = citem.arrPid
                    };
                    menuList.children.Add(cmenuList);
                }
                Mlist.Add(menuList);
            }
            return Mlist;
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
    /// <summary>
    /// 选择菜单项
    /// </summary>
    public class MenuOptions
    {
        /// <summary>
        /// 值
        /// </summary>
        public int value { set; get; }
        /// <summary>
        /// 名称
        /// </summary>
        public string label { get; set; }
        /// <summary>
        /// 孩子节点
        /// </summary>
        public List<MenuOptions> children { get; set; }
    }
    /// <summary>
    /// 菜单列表带子菜单
    /// </summary>
    public class MenuList:MenuInfo
    {
       public  List<MenuList> children { get; set; }
    }
}
