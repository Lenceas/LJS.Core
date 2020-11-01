using LJS.Core.Model;
using LJS.Core.Repository.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LJS.Core.Repository.Mongo
{
    public interface IMongoRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        #region 同步方法
        /// <summary>
        /// 通过查询条件获取实体集合
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 通过查询条件获取第一个实体
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns></returns>
        TEntity GetSingle(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 获取实体集合数量
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns></returns>
        long Count(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Mongo分页查询
        /// </summary>
        /// <param name="page">页码，从1开始</param>
        /// <param name="pageSize">页大小建议值10</param>
        /// <returns></returns>
        PageModel<TEntity> GetPageEntitiy(int page, int pageSize);

        /// <summary>
        /// 根据批定查询条件返回分页集合
        /// </summary>
        /// <param name="page">页码，从1开始</param>
        /// <param name="pageSize">页大小建议值10</param>
        /// <param name="filter">过滤条件</param>
        /// <returns></returns>
        PageModel<TEntity> GetPageEntitiy(int page, int pageSize, Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 根据批定查询条件及字段列表返回分页集合
        /// </summary>
        /// <param name="page">页码，从1开始</param>
        /// <param name="pageSize">页大小建议值10</param>
        /// <param name="filter">过滤条件</param>
        /// <param name="sortFieldList">排序字段列表：字段，升(true)降(false)序</param>
        /// <returns></returns>
        PageModel<TEntity> GetPageEntitiy(int page, int pageSize, Expression<Func<TEntity, bool>> filter, Dictionary<Expression<Func<TEntity, object>>, bool> sortFieldList);

        /// <summary>
        /// 获得前N条实体
        /// </summary>
        /// <param name="topNumber">TopN记录，建议不超过1000</param>
        /// <param name="filter">过滤条件</param>
        /// <returns></returns>
        IList<TEntity> GetTopEntitiy(int topNumber, Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 获得前N条实体
        /// </summary>
        /// <param name="topNumber">TopN记录，建议不超过1000</param>
        /// <param name="filter">过滤条件</param>
        /// <param name="sortFieldList">排序字段列表：字段，升(true)降(false)序</param>
        /// <returns></returns>
        IList<TEntity> GetTopEntitiy(int topNumber, Expression<Func<TEntity, bool>> filter, Dictionary<Expression<Func<TEntity, object>>, bool> sortFieldList);

        /// <summary>
        /// 批量添加集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns></returns>
        int Insert(IEnumerable<TEntity> entities);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="updateFields">仅更新的字段(小写字段名)，为NULL时更新所有字段</param>
        /// <returns></returns>
        int Update(TEntity entity, string[] updateFields);

        /// <summary>
        /// 批量更新集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns></returns>
        int Update(IEnumerable<TEntity> entities);

        /// <summary>
        /// 批量删除集合
        /// </summary>
        /// <param name="entitiyIds">实体ID集合</param>
        /// <returns></returns>
        int DeleteByIds(IEnumerable<object> entitiyIds);

        /// <summary>
        /// 批量删除集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns></returns>
        int Delete(IEnumerable<TEntity> entities);

        /// <summary>
        /// 批量删除集合
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns></returns>
        int Delete(Expression<Func<TEntity, bool>> filter);

        #endregion

        #region 异步方法

        #region 添加
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task InsertAsync(TEntity entity);

        /// <summary>
        /// 批量添加集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns></returns>
        Task<BulkWriteResult<TEntity>> InsertAsync(IEnumerable<TEntity> entities);
        #endregion

        #region 更新
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<UpdateResult> UpdateAsync(TEntity entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="updateFields">仅更新的字段，为NULL时更新所有字段</param>
        /// <returns></returns>
        Task<UpdateResult> UpdateAsync(TEntity entity, string[] updateFields);

        /// <summary>
        /// 批量更新集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns></returns>
        Task<BulkWriteResult<TEntity>> UpdateAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// 批量更新集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="updateFields">仅更新的字段，为NULL时更新所有字段</param>
        /// <returns></returns>
        Task<BulkWriteResult<TEntity>> UpdateAsync(IEnumerable<TEntity> entities, string[] updateFields);
        #endregion

        #region 删除
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<DeleteResult> DeleteAsync(TEntity entity);

        /// <summary>
        /// 批量删除集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns></returns>
        Task<BulkWriteResult<TEntity>> DeleteAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// 批量删除集合
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns></returns>
        Task<BulkWriteResult<TEntity>> DeleteAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 批量删除集合
        /// </summary>
        /// <param name="entitiyIds">实体ID集合</param>
        /// <returns></returns>
        Task<BulkWriteResult<TEntity>> DeleteByIdsAsync(IEnumerable<object> entitiyIds);
        #endregion

        #endregion
    }
}
