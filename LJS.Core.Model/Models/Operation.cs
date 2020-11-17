using SqlSugar;
using System;

namespace LJS.Core.Model.Models
{
    /// <summary>
    /// 操作表
    /// </summary>
    public class Operation : BaseEntity
    {
        #region 构造函数
        public Operation()
        {
        }

        public Operation(string operationName) : base()
        {
            OperationName = operationName;
            Status = 1;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 操作名称
        /// </summary>
        public string OperationName { get; set; }

        /// <summary>
        /// 状态:1:正常,0:锁定
        /// </summary>
        public int Status { get; set; }
        #endregion
    }
}
