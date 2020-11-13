using SqlSugar;
using System;

namespace LJS.Core.Model.Models
{
    /// <summary>
    /// 操作表 CRUD
    /// </summary>
    public class Operation : BaseEntity
    {
        /// <summary>
        /// 操作名称
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string OperationName { get; set; }

        /// <summary>
        /// 状态:1:正常,0:锁定
        /// </summary>
        public int Status { get; set; }
    }
}
