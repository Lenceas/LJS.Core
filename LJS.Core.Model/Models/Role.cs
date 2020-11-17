using SqlSugar;
using System;

namespace LJS.Core.Model.Models
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class Role : BaseEntity
    {
        #region 构造函数
        public Role()
        {
        }

        public Role(string roleName, long parentRoleId = 0) : base()
        {
            RoleName = roleName;
            ParentRoleId = parentRoleId;
            Status = 1;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 父级角色
        /// </summary>
        public long ParentRoleId { get; set; }

        /// <summary>
        /// 状态:1:正常,0:锁定
        /// </summary>
        public int Status { get; set; }
        #endregion
    }
}
