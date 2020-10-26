/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/16 16:48:43
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： RoleHelper
** 描    述： RoleHelper
********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZhaoAdminCore.API.Model.Models;

namespace ZhaoAdminCore.API.Common.Helper
{
    public class RoleMenuPermissionHelper
    {
        /// <summary>
        /// 获取角色菜单权限列表
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="pRMlist"></param>
        /// <param name="mList"></param>
        /// <param name="pList"></param>
        /// <returns></returns>
        public static RoleMenuPermission GetRoleMenuPermissions(List<RoleInfo> roles, List<PermissionRoleMenuInfo> pRMlist, List<MenuInfo> mList, List<PermissionInfo> pList)
        {
            RoleMenuPermission roleMenuPermission = new RoleMenuPermission();
            roleMenuPermission.data = new List<Role>();
            foreach (var item in roles)
            {
                Role role = new Role();
                role.ID = item.rID;
                var roleinfos = roles.Single(n => n.rID == item.rID);
                role.Name = roleinfos.rName;
                role.CreateTime = roleinfos.rCreateTime;
                role.CreateBy = roleinfos.rCreateBy;
                role.UpdateTime = roleinfos.rUpdateTime;
                role.Description = roleinfos.rDescription;
                role.ModifyBy = roleinfos.rModifyBy;
                role.children = new List<RoleMenuRoot>();
                //菜单根节点
                if (pRMlist.Exists(n=>n.rID==item.rID))
                {
                    var mrGroup = pRMlist.GroupBy(n => n.mID);
                    RoleMenuRoot roleMenuRoot = null;
                    foreach (var mritem in mrGroup)
                    {
                        var mritems = mritem.FirstOrDefault();
                        var mchildren = mList.Single(n => n.mID == mritems.mID);
                        var pid = mchildren.mPid;
                        var menuinfo = mList.Single(n => n.mID == pid);
                        if (!role.children.Exists(n => n.ID == menuinfo.mID))
                        {
                            roleMenuRoot = new RoleMenuRoot();
                            roleMenuRoot.ID = menuinfo.mID;
                            roleMenuRoot.Name = menuinfo.mName;
                            //菜单列表
                            roleMenuRoot.children = new List<RoleMenu>();
                        }
                        RoleMenu roleMenu = new RoleMenu();
                        roleMenu.ID = mchildren.mID;
                        roleMenu.Name = mchildren.mName;
                        roleMenu.children = new List<MenuPermission>();
                        foreach (var pitem in mritem.ToList())
                        {
                            MenuPermission menuPermission = new MenuPermission();
                            var permissioninfo = pList.Single(n => n.pID == pitem.pID);
                            menuPermission.ID = permissioninfo.pID;
                            menuPermission.Name = permissioninfo.pName;
                            roleMenu.children.Add(menuPermission);
                        }
                        roleMenuRoot.children.Add(roleMenu);
                        if (!role.children.Exists(n => n.ID == roleMenuRoot.ID))
                        {
                            role.children.Add(roleMenuRoot);
                        }
                    }
                }
                roleMenuPermission.data.Add(role);
            }

            //var Root = pRMlist.GroupBy(n => n.rID);
            //foreach (var item in Root)
            //{
            //    var ritem = item.FirstOrDefault();
            //    Role role = new Role();
            //    role.ID = ritem.rID;
            //    var roleinfos = roles.Single(n => n.rID == ritem.rID);
            //    role.Name = roleinfos.rName;
            //    role.CreateTime = roleinfos.rCreateTime;
            //    role.CreateBy = roleinfos.rCreateBy;
            //    role.UpdateTime = roleinfos.rUpdateTime;
            //    role.ModifyBy = roleinfos.rModifyBy;
            //    role.children = new List<RoleMenuRoot>();
            //    //菜单根节点
            //    var mrGroup = pRMlist.GroupBy(n => n.mID);
            //    RoleMenuRoot roleMenuRoot = null;
            //    foreach (var mritem in mrGroup)
            //    {
            //        var mritems = mritem.FirstOrDefault();
            //        var mchildren = mList.Single(n => n.ID == mritems.mID);
            //        var pid = mchildren.Pid;
            //        var menuinfo = mList.Single(n => n.ID == pid);
            //        if (!role.children.Exists(n=>n.ID==menuinfo.ID))
            //        {
            //            roleMenuRoot = new RoleMenuRoot();
            //            roleMenuRoot.ID = menuinfo.ID;
            //            roleMenuRoot.Name = menuinfo.Name;
            //            //菜单列表
            //            roleMenuRoot.children = new List<RoleMenu>();
            //        }
            //        RoleMenu roleMenu = new RoleMenu();
            //        roleMenu.ID = mchildren.ID;
            //        roleMenu.Name = mchildren.Name;
            //        roleMenu.children = new List<MenuPermission>();
            //        foreach (var pitem in mritem.ToList())
            //        {
            //            MenuPermission menuPermission = new MenuPermission();
            //            var permissioninfo = pList.Single(n=>n.ID== pitem.pID);
            //            menuPermission.ID = permissioninfo.ID;
            //            menuPermission.Name = permissioninfo.pName;
            //            roleMenu.children.Add(menuPermission);
            //        }
            //        roleMenuRoot.children.Add(roleMenu);
            //        if (!role.children.Exists(n=>n.ID==roleMenuRoot.ID))
            //        {
            //            role.children.Add(roleMenuRoot);
            //        }
            //    }
            //    roleMenuPermission.data.Add(role);
            //}

            return roleMenuPermission;
        }
        /// <summary>
        /// 获取所有的菜单权限
        /// </summary>
        /// <param name="mList"></param>
        /// <param name="pList"></param>
        /// <returns></returns>
        public static MenuPermissionRoot GetAllMenuPermissions(List<MenuInfo> mList, List<PermissionInfo> pList)
        {
            MenuPermissionRoot root = new MenuPermissionRoot();
            root.data = new List<RoleMenuRoot>();
            var mroot = mList.Where(n => n.mPid == 0).ToList();
            foreach (var item in mroot)
            {
                RoleMenuRoot roleMenuroot = new RoleMenuRoot();
                roleMenuroot.ID = item.mID;
                roleMenuroot.Name = item.mName;
                var mchildrens= mList.FindAll(n => n.mPid == item.mID);
                //菜单列表
                roleMenuroot.children = new List<RoleMenu>();
                foreach (var citem in mchildrens)
                {
                    RoleMenu roleMenu = new RoleMenu();
                    roleMenu.ID = citem.mID;
                    roleMenu.Name = citem.mName;
                    //权限列表
                    roleMenu.children = new List<MenuPermission>();
                    foreach (var pitem in pList.FindAll(f=>f.mID== citem.mID))
                    {
                        MenuPermission menuPermission = new MenuPermission();
                        menuPermission.ID = pitem.pID;
                        menuPermission.Name = pitem.pName;
                        roleMenu.children.Add(menuPermission);
                    }
                    roleMenuroot.children.Add(roleMenu);
                }
                root.data.Add(roleMenuroot);
            }
            return root;
        }

        /// <summary>
        /// 获取所有的菜单权限列表
        /// </summary>
        /// <returns></returns>
        public static List<MenuPermissionRootList> GetMenuPermissionList(List<MenuInfo> mList, List<PermissionInfo> pList)
        {
            List<MenuPermissionRootList> RootList = new List<MenuPermissionRootList>();
            var mroot = mList.Where(n => n.mPid == 0).ToList();
            foreach (var item in mroot)
            {
                MenuPermissionRootList root = new MenuPermissionRootList();
                root.id = item.mID;
                root.name = item.mName;
                var mchildrens = mList.FindAll(n => n.mPid == item.mID);
                //菜单列表
                root.children = new List<MenuChildren>();
                foreach (var citem in mchildrens)
                {
                    MenuChildren menuChildren = new MenuChildren();
                    menuChildren.name = citem.mName;
                    menuChildren.id = citem.mID;
                    //权限列表
                    menuChildren.children = new List<PermissionInfoChildren>();
                    pList.ForEach(n=> {
                        PermissionInfoChildren pChildren = new PermissionInfoChildren();
                        pChildren.id = n.pID;
                        pChildren.name = n.pName;
                        menuChildren.children.Add(pChildren);
                    });
                    root.children.Add(menuChildren);
                }
                RootList.Add(root);
            }
            return RootList;
        }
    }
    #region 树形菜单实体
    /// <summary>
    /// 角色菜单权限
    /// </summary>
    public class RoleMenuPermission
    {
       public List<Role> data { get; set; }
    }
    /// <summary>
    /// 菜单权限
    /// </summary>
    public class MenuPermissionRoot
    {
        public List<RoleMenuRoot> data { get; set; }
    }
    /// <summary>
    /// 角色
    /// </summary>
    public class Role
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// 修改者
        /// </summary>
        /// 
        public string ModifyBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public System.DateTime UpdateTime { get; set; }
        /// <summary>
        ///描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 角色下菜单孩子
        /// </summary>
        public List<RoleMenuRoot> children { get; set; }
    }


    /// <summary>
    /// 角色菜单
    /// </summary>
    public class RoleMenuRoot
    {
        /// <summary>
        /// 菜单id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 菜单显示名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 菜单下权限孩子
        /// </summary>
        public List<RoleMenu> children { get; set; }
    }
    /// <summary>
    /// 角色菜单
    /// </summary>
    public class RoleMenu
    {
        /// <summary>
        /// 菜单id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 菜单显示名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 菜单下权限孩子
        /// </summary>
        public List<MenuPermission> children { get; set; }
    }
    /// <summary>
    /// 菜单权限
    /// </summary>
    public class MenuPermission
    {
        /// <summary>
        /// 权限ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }
    }
    #endregion

    #region 菜单权限列表实体
    public class MenuPermissionRootList
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<MenuChildren> children { get; set; }
    }
    public class MenuChildren:MenuInfo
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<PermissionInfoChildren> children { get; set; }
    }
    public class PermissionInfoChildren : PermissionInfo
    {
        public int id { get; set; }
        public string name { get; set; }

    }
    #endregion
}
