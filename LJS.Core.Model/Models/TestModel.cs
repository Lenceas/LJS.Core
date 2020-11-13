using SqlSugar;
using System;
namespace LJS.Core.Model.Models
{
    /// <summary>
    /// 测试模型
    /// </summary>
    [SugarTable("TestModel")]
    public class TestModel : BaseEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDataType = "nvarchar", Length = 20, ColumnDescription = "名称")]
        public string Name { get; set; }
    }
}
