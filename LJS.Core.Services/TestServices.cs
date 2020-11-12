using LJS.Core.IServices;
using LJS.Core.Model.Models;
using LJS.Core.Repository.Base;
using LJS.Core.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJS.Core.Services
{
    public class TestServices : BaseSqlSugarServices<TestModel>, ITestServices
    {
        IBaseSqlSugarRepository<TestModel> _dal;

        public TestServices(IBaseSqlSugarRepository<TestModel> dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }

        public async Task<List<TestModel>> GetTests()
        {
            return await base.Query(a => a.Id > 0, a => a.Id);
        }

        public async Task<TestModel> GetById(long id)
        {
            return await base.QueryById(id);
        }
    }
}
