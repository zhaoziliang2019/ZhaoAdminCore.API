/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/30 13:47:51
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： CateParamInfo
** 描    述： CateParamInfo
********************************************************************/
using SqlSugar;

namespace ZhaoAdminCore.API.Model.Models
{
    /// <summary>
    /// 商品参数
    /// </summary>
    public class CateParamInfo
    {
        /// <summary>
        /// 分类参数id
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int attr_ID { get; set; }
        /// <summary>
        /// 分类参数名称
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
        public string attr_Name { get; set; }
        /// <summary>
        /// 分类参数所属分类
        /// </summary>
        public int cat_ID { get; set; }
        /// <summary>
        /// only:输入框唯一many:后台下拉列表/前台单选框
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 4, IsNullable = true)]
        public string attr_Sel { get; set; }
        /// <summary>
        /// manual:手工录入list:从列表选择
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 6, IsNullable = true)]
        public string attr_Write { get; set; }
        /// <summary>
        /// 如果attr_Write:list,那么有值，该值以逗号隔开
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string attr_Vals { get; set; }
    }
}
