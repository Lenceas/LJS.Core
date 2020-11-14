using LJS.Core.IServices;
using LJS.Core.Model.Models;
using LJS.Core.Repository.Base;
using LJS.Core.Services.Base;

namespace LJS.Core.Services
{
    public class UserServices : BaseSqlSugarServices<User>, IUserServices
    {
        IBaseSqlSugarRepository<User> _dal;

        public UserServices(IBaseSqlSugarRepository<User> dal)
        {
            _dal = dal;
            BaseDal = dal;
        }
    }
}
