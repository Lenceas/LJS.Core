using SqlSugar;
using System;

namespace LJS.Core.Model.Models
{
    /// <summary>
    /// 角色权限关联表
    /// </summary>
    public class Role_Permission : BaseEntity
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleId { get; set; }

        /// <summary>
        /// 权限ID
        /// </summary>
        public long PermissionId { get; set; }
    }
}
