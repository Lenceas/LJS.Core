using SqlSugar;
using System;

namespace LJS.Core.Model.Models
{
    /// <summary>
    /// 菜单表
    /// </summary>
    public class Menu : BaseEntity
    {
        #region 构造函数
        public Menu()
        {
        }

        public Menu(string menuName, long parentMenuId = 0, int menuLevel = 0) : base()
        {
            MenuName = menuName;
            ParentMenuId = parentMenuId;
            MenuLevel = menuLevel;
            Status = 1;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// 父级菜单
        /// </summary>
        public long ParentMenuId { get; set; }

        /// <summary>
        /// 菜单层级
        /// </summary>
        public int MenuLevel { get; set; }

        /// <summary>
        /// 路由
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string MenuUrl { get; set; }

        /// <summary>
        /// 状态:1:正常,0:锁定
        /// </summary>
        public int Status { get; set; }
        #endregion
    }
}
