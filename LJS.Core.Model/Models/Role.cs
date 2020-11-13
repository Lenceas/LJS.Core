using SqlSugar;
using System;

namespace LJS.Core.Model.Models
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class Role : BaseEntity
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string RoleName { get; set; }

        /// <summary>
        /// 父级角色
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public long? ParentRoleId { get; set; }

        /// <summary>
        /// 状态:1:正常,0:锁定
        /// </summary>
        public int Status { get; set; }
    }
}
