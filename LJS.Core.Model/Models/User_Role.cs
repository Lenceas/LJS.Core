using SqlSugar;
using System;

namespace LJS.Core.Model.Models
{
    /// <summary>
    /// 用户角色关联表
    /// </summary>
    public class User_Role : BaseEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleId { get; set; }
    }
}
