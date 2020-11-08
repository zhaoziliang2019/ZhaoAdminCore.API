/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/11/1 10:12:26
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： CateListInfo
** 描    述： CateListInfo
********************************************************************/
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZhaoAdminCore.API.Model.Models
{
    /// <summary>
    /// 商品列表
    /// </summary>
    public class GoodsListInfo
    {
        /// <summary>
        /// 商品主键
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int goods_ID { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string goods_Name { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal goods_Price { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int goods_Number { get; set; }
        /// <summary>
        /// 商品重量
        /// </summary>
        public int goods_Weight { get; set; }
        /// <summary>
        /// 以逗号分割的分类列表
        /// </summary>
        public string goods_Cat { get; set; }
        public int? goods_State { get; set; }
        /// <summary>
        /// 商品添加时间
        /// </summary>
        public DateTime? add_Time { get; set; } = System.DateTime.Now;
       /// <summary>
       /// 商品更新时间
       /// </summary>
        public DateTime? upd_Time { get; set; } = System.DateTime.Now;

        public int hot_Number { get; set; }
        public bool is_Promote { get; set; }
        /// <summary>
        /// 图片数组
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string goods_Pics { get; set; }
        /// <summary>
        /// 商品介绍
        /// </summary>

        public string goods_Introduce { get; set; }
        /// <summary>
        /// 动态参数呵静态属性
        /// </summary>
        public string goods_Attrs { get; set; }
    }

    public class Goods_PicsInfo
    {
        public string goods_Pics { get; set; }
    }
}
