/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/16 16:52:08
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： RoleInfo
** 描    述： RoleInfo
********************************************************************/
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZhaoAdminCore.API.Model.Models
{
    /// <summary>
    /// 角色类
    /// </summary>
    public class RoleInfo
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int rID { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string rName { get; set; }
        /// <summary>
        /// 是否删除 bool 1是true, 0是false
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool rIsDelete { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime rCreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 创建ID
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? rCreateId { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string rCreateBy { get; set; }
        /// <summary>
        /// 修改ID
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? rModifyId { get; set; }
        /// <summary>
        /// 修改者
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
        public string rModifyBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public System.DateTime rUpdateTime { get; set; } = DateTime.Now;
        /// <summary>
        ///描述
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
        public string rDescription { get; set; }
        /// <summary>
        /// 角色下面的菜单列表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<MenuInfo> children { get; set; }

    }
}
