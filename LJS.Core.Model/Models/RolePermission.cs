﻿using SqlSugar;
using System;

namespace LJS.Core.Model.Models
{
    /// <summary>
    /// 角色权限关联表
    /// </summary>
    public class RolePermission : BaseEntity
    {
        #region 构造函数
        public RolePermission()
        {
        }

        public RolePermission(long roleId, long permissionId) : base()
        {
            RoleId = roleId;
            PermissionId = permissionId;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleId { get; set; }

        /// <summary>
        /// 权限ID
        /// </summary>
        public long PermissionId { get; set; }
        #endregion
    }
}
