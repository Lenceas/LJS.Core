using SqlSugar;
using System;

namespace LJS.Core.Model.Models
{
    /// <summary>
    /// 菜单表
    /// </summary>
    public class Menu : BaseEntity
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string MenuName { get; set; }

        /// <summary>
        /// 父级菜单
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public long? ParentMenuId { get; set; }

        /// <summary>
        /// 路由
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Url { get; set; }

        /// <summary>
        /// 状态:1:正常,0:锁定
        /// </summary>
        public int Status { get; set; }
    }
}
