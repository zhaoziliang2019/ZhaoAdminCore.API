/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/26 15:16:35
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： RoleMenuHelper
** 描    述： RoleMenuHelper
********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZhaoAdminCore.API.Model.Models;

namespace ZhaoAdminCore.API.Common.Helper
{
    /// <summary>
    /// 角色菜单帮助类
    /// </summary>
    public class RoleMenuHelper
    {
        /// <summary>
        /// 获取分配权限树
        /// </summary>
        /// <returns></returns>
        public static List<RoleMenuTree> GetRoleMenuTree(List<MenuInfo> mlist)
        {
            var root = new List<RoleMenuTree>();
            foreach (var item in mlist.FindAll(m => m.mPid == 0))
            {
                RoleMenuTree mroot = new RoleMenuTree();
                mroot.id = item.mID;
                mroot.name = item.mName;
                mroot.children = new List<RoleMenuTree>();
                foreach (var citem in mlist.FindAll(m => m.mPid == item.mID))
                {
                    RoleMenuTree croot = new RoleMenuTree();
                    croot.id = citem.mID;
                    croot.name = citem.mName;
                    croot.children = new List<RoleMenuTree>();
                    foreach (var ccitem in mlist.FindAll(m => m.mPid == citem.mID))
                    {
                        RoleMenuTree ccroot = new RoleMenuTree();
                        ccroot.id = ccitem.mID;
                        ccroot.name = ccitem.mName;
                        croot.children.Add(ccroot);
                    }
                    mroot.children.Add(croot);
                }
                root.Add(mroot);
            }
            return root;
        }
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="rlist"></param>
        /// <param name="mlist"></param>
        /// <returns></returns>
        public static List<RoleMenuList> GetRoleMenuList(List<RoleInfo> rlist, List<MenuInfo> mlist, List<RoleMenuInfo> rmlist)
        {
            var root = new List<RoleMenuList>();
            
            foreach (var item in rlist)
            {
                RoleMenuList Root = new RoleMenuList()
                {
                    rID = item.rID,
                    rName=item.rName,
                    rCreateBy=item.rCreateBy,
                    rCreateId=item.rCreateId,
                    rCreateTime=item.rCreateTime,
                    rDescription=item.rDescription,
                    rIsDelete=item.rIsDelete,
                    rModifyBy=item.rModifyBy,
                    rModifyId=item.rModifyId,
                    rUpdateTime=item.rUpdateTime,
                };
                Root.children = new List<MenuChildrenList>();
                List<int> RmList = new List<int>();
                //找父节点
                foreach (var ritem in rmlist.FindAll(n=>n.rID==item.rID))
                {
                    var rMenuInfo = mlist.Single(n => n.mID == ritem.mID);//子节点
                    if (rMenuInfo.mPid == 0)
                    {
                        RmList.Add(ritem.mID);
                    }
                    else
                    {
                        var MenuInfo = mlist.Single(n => n.mID == ritem.mID);//节点
                        var RmenuInfo = mlist.Single(n => n.mID == MenuInfo.mPid);//父节点
                        if (RmenuInfo.mPid == 0)
                        {
                            if (!RmList.Exists(n => n == RmenuInfo.mID))
                            {
                                RmList.Add(RmenuInfo.mID);
                            }

                        }
                    }

                }
                foreach (var citem in RmList)
                {
                    var cMenuInfo = mlist.Single(n => n.mID == citem);//父节点
                    MenuChildrenList mRoot = new MenuChildrenList()
                    {
                        mID = cMenuInfo.mID,
                        mName = cMenuInfo.mName,
                        mPid = cMenuInfo.mPid,
                        mCreateBy = cMenuInfo.mCreateBy,
                        mCreateId = cMenuInfo.mCreateId,
                        mCreateTime = cMenuInfo.mCreateTime,
                        mDescription = cMenuInfo.mDescription,
                        mIcon = cMenuInfo.mIcon,
                        mIsDeleted = cMenuInfo.mIsDeleted,
                        mMid = cMenuInfo.mMid,
                        mModifyBy = cMenuInfo.mModifyBy,
                        mModifyId = cMenuInfo.mModifyId,
                        mOrderSort = cMenuInfo.mOrderSort,
                        mPath = cMenuInfo.mPath,
                        mUpdateTime = cMenuInfo.mUpdateTime,
                        arrPid = cMenuInfo.arrPid
                    };
                    mRoot.children = new List<MenuChildrenList>();
                    var cmlist = new List<MenuInfo>();
                    mlist.FindAll(m => m.mPid == cMenuInfo.mID).ForEach(m=> {
                        if (rmlist.Exists(n=>n.mID== m.mID))
                        {
                            cmlist.Add(m);
                        }
                    });
                    foreach (var ccitem in cmlist)
                    {
                        MenuChildrenList cmRoot = new MenuChildrenList()
                        {
                            mID = ccitem.mID,
                            mName = ccitem.mName,
                            mPid = ccitem.mPid,
                            mCreateBy = ccitem.mCreateBy,
                            mCreateId = ccitem.mCreateId,
                            mCreateTime = ccitem.mCreateTime,
                            mDescription = ccitem.mDescription,
                            mIcon = ccitem.mIcon,
                            mIsDeleted = ccitem.mIsDeleted,
                            mMid = ccitem.mMid,
                            mModifyBy = ccitem.mModifyBy,
                            mModifyId = ccitem.mModifyId,
                            mOrderSort = ccitem.mOrderSort,
                            mPath = ccitem.mPath,
                            mUpdateTime = ccitem.mUpdateTime,
                            arrPid = ccitem.arrPid
                        };
                        cmRoot.children = new List<MenuChildrenList>();
                        var ccmlist = new List<MenuInfo>();
                        mlist.FindAll(m => m.mPid == ccitem.mID).ForEach(m => {
                            if (rmlist.Exists(n => n.mID == m.mID))
                            {
                                ccmlist.Add(m);
                            }
                        });
                        foreach (var cccitem in ccmlist)
                        {
                            MenuChildrenList ccmRoot = new MenuChildrenList()
                            {
                                mID = cccitem.mID,
                                mName = cccitem.mName,
                                mPid = cccitem.mPid,
                                mCreateBy = cccitem.mCreateBy,
                                mCreateId = cccitem.mCreateId,
                                mCreateTime = cccitem.mCreateTime,
                                mDescription = cccitem.mDescription,
                                mIcon = cccitem.mIcon,
                                mIsDeleted = cccitem.mIsDeleted,
                                mMid = cccitem.mMid,
                                mModifyBy = cccitem.mModifyBy,
                                mModifyId = cccitem.mModifyId,
                                mOrderSort = cccitem.mOrderSort,
                                mPath = cccitem.mPath,
                                mUpdateTime = cccitem.mUpdateTime,
                                arrPid = cccitem.arrPid
                            };
                            cmRoot.children.Add(ccmRoot);
                        }
                        mRoot.children.Add(cmRoot);
                    }
                    Root.children.Add(mRoot);
                }
                root.Add(Root);
            }
            return root;
        }

    }
    #region 角色菜单树类
    public class RoleMenuTree
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<RoleMenuTree> children { get; set; }
    }
    #endregion
     
    #region 角色菜单列表
    public class RoleMenuList:RoleInfo
    {
        public List<MenuChildrenList> children { get; set; }
    }

    public class MenuChildrenList:MenuInfo
    {
        public List<MenuChildrenList> children { get; set; }
    }
    #endregion
}
