/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/28 20:56:30
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： CateGorieInfo
** 描    述： CateGorieInfo
********************************************************************/
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZhaoAdminCore.API.Model.Models
{
    /// <summary>
    /// 商品分类
    /// </summary>
    public class CateGorieInfo
    {
        /// <summary>
        /// 分类ID
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int cat_ID { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string cat_Name { get; set; }
        /// <summary>
        /// /分类父节点
        /// </summary>
        public int cat_Pid { get; set; }
        /// <summary>
        /// 分类当前级别
        /// </summary>
        public int cat_Level { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool cat_IsDelete { get; set; }
        /// <summary>
        /// 孩子节点
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<CateGorieInfo> children { get; set; }
    }
}
