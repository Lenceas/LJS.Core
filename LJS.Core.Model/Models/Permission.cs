using SqlSugar;
using System;

namespace LJS.Core.Model.Models
{
    /// <summary>
    /// 权限表
    /// </summary>
    public class Permission : BaseEntity
    {
        #region 构造函数
        public Permission()
        {
        }

        public Permission(string permissionName, long parentPermissionId = 0) : base()
        {
            PermissionName = permissionName;
            ParentPermissionId = parentPermissionId;
            Status = 1;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 权限名称
        /// </summary>
        public string PermissionName { get; set; }

        /// <summary>
        /// 父级权限
        /// </summary>
        public long ParentPermissionId { get; set; }

        /// <summary>
        /// 状态:1:正常,0:锁定
        /// </summary>
        public int Status { get; set; }
        #endregion
    }
}
