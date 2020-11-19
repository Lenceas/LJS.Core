using SqlSugar;
using System;

namespace LJS.Core.Model.Models
{
    /// <summary>
    /// 操作权限关联表
    /// </summary>
    public class OperationPermission : BaseEntity
    {
        #region 构造函数
        public OperationPermission()
        { 
        }

        public OperationPermission(long operationId, long permissionId) : base()
        {
            OperationId = operationId;
            PermissionId = permissionId;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 操作ID
        /// </summary>
        public long OperationId { get; set; }

        /// <summary>
        /// 权限ID
        /// </summary>
        public long PermissionId { get; set; }
        #endregion
    }
}
