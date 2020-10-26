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
    public class PermissionRoleMenuInfo
    {
        /// <summary>
        /// 权限菜单id
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int pmID { get; set; }
        /// <summary>
        /// 权限id
        /// </summary>
        public int pID { get; set; }
        /// <summary>
        /// 菜单id
        /// </summary>
        public int mID { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int rID { get; set; }
    }
}
