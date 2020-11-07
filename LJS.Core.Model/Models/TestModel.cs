using SqlSugar;
using System;
namespace LJS.Core.Model.Models
{
    /// <summary>
    /// 测试模型
    /// </summary>
    [SugarTable("TestModel")]
    public class TestModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDataType = "nvarchar", Length = 2000, ColumnDescription = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool? IsDeleted { get; set; }
    }
}
