using SqlSugar;
using System;

namespace LJS.Core.Model.Models
{
    /// <summary>
    /// 菜单权限关联表
    /// </summary>
    public class Menu_Permission : BaseEntity
    {
        #region 构造函数
        public Menu_Permission()
        {
        }

        public Menu_Permission(long menuId, long permissionId) : base()
        {
            MenuId = menuId;
            PermissionId = permissionId;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 菜单ID
        /// </summary>
        public long MenuId { get; set; }

        /// <summary>
        /// 权限ID
        /// </summary>
        public long PermissionId { get; set; }
        #endregion
    }
}
