﻿using LJS.Core.IRepository.UnitOfWork;
using SqlSugar;
using System;

namespace LJS.Core.Repository.UnitOfWork
{
    public class SqlSugarUnitOfWork : ISqlSugarUnitOfWork
    {
        private readonly ISqlSugarClient _sqlSugarClient;

        public SqlSugarUnitOfWork(ISqlSugarClient sqlSugarClient)
        {
            _sqlSugarClient = sqlSugarClient;
        }

        /// <summary>
        /// 获取DB，保证唯一性
        /// </summary>
        /// <returns></returns>
        public SqlSugarClient GetDbClient()
        {
            // 必须要as，后边会用到切换数据库操作
            return _sqlSugarClient as SqlSugarClient;
        }

        public void BeginTran()
        {
            GetDbClient().BeginTran();
        }

        public void CommitTran()
        {
            try
            {
                GetDbClient().CommitTran(); //
            }
            catch (Exception ex)
            {
                GetDbClient().RollbackTran();
                throw new Exception(ex.Message);
            }
        }

        public void RollbackTran()
        {
            GetDbClient().RollbackTran();
        }

    }
}
