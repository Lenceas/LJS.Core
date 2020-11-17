using SqlSugar;
using System;

namespace LJS.Core.Model
{
    public class BaseEntity
    {
        #region 构造函数
        public BaseEntity()
        {
            IsDeleted = false;
            CreateTime = DateTime.Now.ToLocalTime();
            UpdateTime = DateTime.Now.ToLocalTime();
            Remark = null;
            SortId = 100;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 泛型主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        /// <summary>
        /// 逻辑上的删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Remark { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int SortId { get; set; }
        #endregion
    }
}
