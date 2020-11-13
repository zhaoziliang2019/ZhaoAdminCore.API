/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/21 18:03:56
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： UserRoleInfo
** 描    述： UserRoleInfo
********************************************************************/
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZhaoAdminCore.API.Model.Models
{
    /// <summary>
    /// 用户角色信息
    /// </summary>
    public class UserRoleInfo
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public UserRoleInfo()
        {
            
        }
        /// <summary>
        /// 带参数构造函数
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="rid"></param>
        public UserRoleInfo(int uid,int rid)
        {
            uID = uid;
            rID = rid;
        }
        /// <summary>
        /// 用户角色id
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int uID { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int rID { get; set; }
    }
}
