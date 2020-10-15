/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/10/10 18:10:02
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： IUnitOfWork
** 描    述： IUnitOfWork
********************************************************************/

using SqlSugar;

namespace ZhaoAdminCore.API.IRepository.UnitOfWork
{
    public interface IUnitOfWork
    {
        SqlSugarClient GetDbClient();

        void BeginTran();

        void CommitTran();
        void RollbackTran();
    }
}
