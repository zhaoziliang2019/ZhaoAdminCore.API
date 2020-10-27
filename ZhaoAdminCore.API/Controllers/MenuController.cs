using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhaoAdminCore.API.Common.Helper;
using ZhaoAdminCore.API.IServices.SysManage;
using ZhaoAdminCore.API.Model;
using ZhaoAdminCore.API.Model.Models;

namespace ZhaoAdminCore.API.Controllers
{
    [Route("api/menus")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuinfoService menuService;

        public MenuController(IMenuinfoService _menuService)
        {
            menuService = _menuService;
        }
        /// <summary>
        /// 获取菜单树
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        public async Task<MessageModel<NavigationBar>> Get()
        {
            var data = new MessageModel<NavigationBar>();
            var menus = await menuService.Query(t => t.mIsDeleted == false);
            var menuTrees = (from child in menus
                             select new NavigationBar
                             {
                                 id = child.mID,
                                 pid = child.mPid,
                                 order = child.mOrderSort,
                                 name = child.mName,
                                 iconCls = child.mIcon,
                                 path = child.mPath
                             }).ToList();
            NavigationBar rootRoot = new NavigationBar()
            {
                id = 0,
                pid = 0,
                order = 0,
                name = "根节点",
                path = "",
                iconCls = "",
            };
            RecursionHelper.LoopNaviBarAppendChildren(menuTrees, rootRoot);

            data.success = true;
            if (data.success)
            {
                data.response = rootRoot;
                data.msg = "获取成功";
            }
            return data;
        }
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        public async Task<MessageModel<List<MenuList>>> GetMenuList()
        {
            var data = new MessageModel<List<MenuList>>();
            var menulist = await menuService.Query(n => n.mIsDeleted == false);
            data.success = true;
            data.response = RecursionHelper.GetMenuList(menulist);
            return data;
        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="menuInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addmenu")]
        public async Task<MessageModel<string>> AddMenuInfo(MenuInfo menuInfo)
        {
            var data = new MessageModel<string>();
            data.success = await menuService.Add(menuInfo) > 0;
            if (data.success)
            {
                data.msg = "添加菜单成功！";
            }
            return data;
        }
        [HttpGet]
        [Route("menu")]
        public async Task<MessageModel<MenuInfo>> GetMenuInfoById(int mid)
        {
            var data = new MessageModel<MenuInfo>();
            if (mid == 0)
            {
                data.success = false;
                data.msg = "获取菜单数据失败！";
                return data;
            }
            var menuinfo = await menuService.QueryById(mid);
            if (menuinfo.mPid==0)
            {
                menuinfo.arrPid = new List<int>() { 0 };
            }
            else
            {
                var cmenuinfo= await menuService.QueryById(menuinfo.mPid);
                if (cmenuinfo.mPid==0)
                {
                    menuinfo.arrPid = new List<int>() { 0, menuinfo.mPid };
                }
                else
                {
                    var ccmenuinfo = await menuService.QueryById(cmenuinfo.mPid);
                    menuinfo.arrPid = new List<int>() { 0, ccmenuinfo.mID,menuinfo.mPid };
                }
            }
            data.success = menuinfo.mID>0;
            if (data.success)
            {
                data.msg = "获取菜单数据成功！";
                data.response = menuinfo;
            }
            return data;
        }
        /// <summary>
        /// 更新菜单列表
        /// </summary>
        /// <param name="menuInfo"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updatemenu")]
        public async Task<MessageModel<string>> UpdateMenuInfo(MenuInfo menuInfo)
        {
            var data = new MessageModel<string>();
            data.success = await menuService.Update(menuInfo);
            if (data.success)
            {
                data.msg = "更新菜单成功！";
            }
            return data;
        }
        /// <summary>
        /// 删除菜单根据id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        public async Task<MessageModel<string>> DeleteMenuInfoById(int id)
        {
            var data = new MessageModel<string>();
            data.success = await menuService.DeleteById(id);
            if (data.success)
            {
                data.msg = "删除菜单成功!";
            }
            return data;
        }
        /// <summary>
        /// 获取选择父节点列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("rootlist")]
        public async Task<MessageModel<MenuOptions>> GetMenuRoot()
        {
            var data = new MessageModel<MenuOptions>();
            var menulist = await menuService.Query(n => n.mIsDeleted == false);
            data.success = true;
            data.response = RecursionHelper.GetMenuListOptions(menulist);
            return data;
        }

    }
}
