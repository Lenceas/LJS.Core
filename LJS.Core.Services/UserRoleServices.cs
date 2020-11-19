using LJS.Core.IServices;
using LJS.Core.Model.Models;
using LJS.Core.Repository.Base;
using LJS.Core.Services.Base;
using System.Linq;
using System.Threading.Tasks;

namespace LJS.Core.Services
{
    public class UserRoleServices : BaseSqlSugarServices<UserRole>, IUserRoleServices
    {
        IBaseSqlSugarRepository<UserRole> _dal;

        public UserRoleServices(IBaseSqlSugarRepository<UserRole> dal)
        {
            _dal = dal;
            BaseDal = dal;
        }
    }
}
