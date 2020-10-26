/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/13 14:05:14
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： Permissioninfo
** 描    述： Permissioninfo
********************************************************************/
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZhaoAdminCore.API.Model.Models
{
    public class MenuInfo
    {
        /// <summary>
        /// 菜单id
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int mID { get; set; }
        /// <summary>
        /// 路由
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string mPath { get; set; }
        /// <summary>
        /// 菜单显示名
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string mName { get; set; }
        /// <summary>
        /// 上一级菜单（0表示上一级无菜单）
        /// </summary>
        public int mPid { get; set; }


        /// <summary>
        /// 接口api
        /// </summary>
        public int mMid { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int mOrderSort { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
        public string mIcon { get; set; }
        /// <summary>
        /// 菜单描述    
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
        public string mDescription { get; set; }

        /// <summary>
        ///获取或设置是否禁用，逻辑上的删除，非物理删除
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool mIsDeleted { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime mCreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 创建ID
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? mCreateId { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string mCreateBy { get; set; }
        /// <summary>
        /// 修改ID
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? mModifyId { get; set; }
        /// <summary>
        /// 修改者
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
        public string mModifyBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public System.DateTime mUpdateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 父节点列表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<int> arrPid { get; set; }
    }
}
