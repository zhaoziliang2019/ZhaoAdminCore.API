/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/10 16:37:04
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： BaseDBConfig
** 描    述： BaseDBConfig
********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZhaoAdminCore.API.Common.Helper;

namespace ZhaoAdminCore.API.Common.Db
{
    public class BaseDBConfig
    {
        public static List<MutiDBOperate> MutiConnectionString => MutiInitConn();
        public static List<MutiDBOperate> MutiInitConn()
        {
            List<MutiDBOperate> listdatabase = AppsettingHelper.GetValue<MutiDBOperate>("DBS")
                .Where(i => i.Enabled).ToList();
            foreach (var i in listdatabase)
            {
               // SpecialDbString(i);
            }
            List<MutiDBOperate> listdatabaseSimpleDB = new List<MutiDBOperate>();//单库
            return (listdatabase);
        }
    }
    public class MutiDBOperate
    {
        /// <summary>
        /// 连接启用开关
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// 连接ID
        /// </summary>
        public string ConnId { get; set; }
        /// <summary>
        /// 从库执行级别，越大越先执行
        /// </summary>
        public int HitRate { get; set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string Connection { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public DataBaseType DbType { get; set; }
    }
    public enum DataBaseType
    {
        MySql = 0,
        SqlServer = 1,
        Sqlite = 2,
        Oracle = 3,
        PostgreSQL = 4
    }
}
