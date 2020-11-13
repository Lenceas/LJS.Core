using SqlSugar;
using System;

namespace LJS.Core.Model.Models
{
    public class Operation_Permission : BaseEntity
    {
        /// <summary>
        /// 操作ID
        /// </summary>
        public long OperationId { get; set; }

        /// <summary>
        /// 权限ID
        /// </summary>
        public long PermissionId { get; set; }
    }
}
