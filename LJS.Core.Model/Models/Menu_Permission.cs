using SqlSugar;
using System;

namespace LJS.Core.Model.Models
{
    /// <summary>
    /// 菜单权限关联表
    /// </summary>
    public class Menu_Permission : BaseEntity
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public long MenuId { get; set; }

        /// <summary>
        /// 权限ID
        /// </summary>
        public long PermissionId { get; set; }
    }
}
