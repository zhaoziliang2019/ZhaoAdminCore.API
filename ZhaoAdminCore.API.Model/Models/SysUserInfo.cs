/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/10 11:14:11
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： sysUserInfo
** 描    述： sysUserInfo
********************************************************************/
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZhaoAdminCore.API.Model.Models
{
    public class SysUserInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int uID { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 10, IsNullable = true)]
        public string uLoginName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 36, IsNullable = true)]
        public string uPassWord { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
        public string uRealName { get; set; }
        // 性别
        [SugarColumn(IsNullable = true)]
        public int uSex { get; set; } = 0;
        // 地址
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string uAddress { get; set; }
        // 邮箱
        [SugarColumn(ColumnDataType = "nvarchar", Length = 20, IsNullable = true)]
        public string uEmail { get; set; }
        // 手机号
        [SugarColumn(ColumnDataType = "nvarchar", Length = 11, IsNullable = true)]
        public string uPhone { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime uCreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 更新时间
        /// </summary>
        public System.DateTime uUpdateTime { get; set; } = DateTime.Now;

        /// <summary>
        ///最后登录时间 
        /// </summary>
        public DateTime uLastErrTime { get; set; } = DateTime.Now;

        /// <summary>
        ///错误次数 
        /// </summary>
        public int uErrorCount { get; set; }
        /// <summary>
        /// 是否删除 bool 1是true, 0是false
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool uIsDelete { get; set; }
        /// <summary>
        /// 角色id
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<int> rIDs { get; set; }

    }
}
