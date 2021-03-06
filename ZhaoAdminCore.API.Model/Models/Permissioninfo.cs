﻿/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/16 17:20:06
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： PermissionInfo
** 描    述： PermissionInfo
********************************************************************/
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZhaoAdminCore.API.Model.Models
{
    /// <summary>
    /// 权限
    /// </summary>
    public class PermissionInfo
    {
        /// <summary>
        /// 权限ID
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int pID { get; set; }
        /// <summary>
        /// 菜单id
        /// </summary>
        public int mID { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string pName { get; set; }
        /// <summary>
        /// 是否删除 bool 1是true, 0是false
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool pIsDelete { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime pCreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 创建ID
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? pCreateId { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string pCreateBy { get; set; }
        /// <summary>
        /// 修改ID
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? pModifyId { get; set; }
        /// <summary>
        /// 修改者
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
        public string pModifyBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public System.DateTime pUpdateTime { get; set; } = DateTime.Now;
    }
}
