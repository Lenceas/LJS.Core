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
    public class TestServices : BaseServices<TestModel>, ITestServices
    {
        IBaseRepository<TestModel> _dal;

        public TestServices(IBaseRepository<TestModel> dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }

        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<TestModel>> GetTests()
        {
            return await base.Query(a => a.Id > 0, a => a.Id);
        }
    }
}
