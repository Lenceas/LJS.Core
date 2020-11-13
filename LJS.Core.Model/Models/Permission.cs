using SqlSugar;
using System;

namespace LJS.Core.Model.Models
{
    /// <summary>
    /// 权限表
    /// </summary>
    public class Permission : BaseEntity
    {
        /// <summary>
        /// 权限名称
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string PermissionName { get; set; }

        /// <summary>
        /// 父级权限
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public long? ParentPermissionId { get; set; }

        /// <summary>
        /// 状态:1:正常,0:锁定
        /// </summary>
        public int Status { get; set; }
    }
}
