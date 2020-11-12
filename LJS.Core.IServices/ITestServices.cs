using LJS.Core.IServices.Base;
using LJS.Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJS.Core.IServices
{
    public interface ITestServices : IBaseSqlSugarServices<TestModel>
    {
        Task<List<TestModel>> GetTests();

        Task<TestModel> GetById(long id);
    }
}
