using LJS.Core.IServices;
using LJS.Core.Model.Models;
using LJS.Core.Repository.Base;
using LJS.Core.Services.Base;
using System.Threading.Tasks;

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

        public async Task<bool> IsExist(string loginName)
        {
            var user = await _dal.Query(t => t.LoginName == loginName && t.IsDeleted == false && t.Status == 1);
            return user.Count > 0;
        }
    }
}
