/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/18 17:21:05
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： PermissionMenuInfo
** 描    述： PermissionMenuInfo
********************************************************************/
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZhaoAdminCore.API.Model.Models
{
    public class RoleMenuInfo
    {
        public RoleMenuInfo()
        {

        }
        public RoleMenuInfo(int rid,int mid)
        {
            this.rID = rid;
            this.mID = mid;
        }
        /// <summary>
        /// 角色菜单id
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int rmID { get; set; }
        /// <summary>
        /// 菜单id
        /// </summary>
        public int mID { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int rID { get; set; }
        /// <summary>
        /// 菜单列表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string mIDs { get; set; }
    }
}
