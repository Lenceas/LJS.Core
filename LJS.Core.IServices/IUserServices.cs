using LJS.Core.IServices.Base;
using LJS.Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJS.Core.IServices
{
    public interface IUserServices : IBaseSqlSugarServices<User>
    {
        Task<bool> IsExist(string loginName);
    }
}
