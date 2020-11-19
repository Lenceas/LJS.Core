using SqlSugar;
using System;

namespace LJS.Core.Model.Models
{
    /// <summary>
    /// 用户角色关联表
    /// </summary>
    public class UserRole : BaseEntity
    {
        #region 构造函数
        public UserRole()
        {
        }

        public UserRole(long userId, long roleId) : base()
        {
            UserId = userId;
            RoleId = roleId;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleId { get; set; }
        #endregion
    }
}
