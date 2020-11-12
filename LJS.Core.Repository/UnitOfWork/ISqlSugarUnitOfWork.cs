using SqlSugar;

namespace LJS.Core.IRepository.UnitOfWork
{
    public interface ISqlSugarUnitOfWork
    {
        SqlSugarClient GetDbClient();
        void BeginTran();
        void CommitTran();
        void RollbackTran();
    }
}
