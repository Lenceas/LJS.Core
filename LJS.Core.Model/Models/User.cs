using LJS.Core.Common.Helper;
using SqlSugar;
using System;

namespace LJS.Core.Model.Models
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User : BaseEntity
    {
        public User()
        {
        }

        public User(string loginName, string loginPwd, string realName = null, string remark = null)
        {
            LoginName = loginName;
            LoginPwd = MD5Helper.MD5Encrypt64(loginPwd);
            RealName = realName;
            Remark = remark;
            ErrorCount = 0;
            Status = 1;
            IsDeleted = false;
            CreateTime = DateTime.Now.ToLocalTime();
            UpdateTime = DateTime.Now.ToLocalTime();
            SortId = 100;
        }


        /// <summary>
        /// 登录账号
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string LoginName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string LoginPwd { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
        public string RealName { get; set; }

        /// <summary>
        ///最后登录时间 
        /// </summary>
        public DateTime LastLoginTime { get; set; } = DateTime.Now.ToLocalTime();

        /// <summary>
        ///错误次数 
        /// </summary>
        public int ErrorCount { get; set; }

        /// <summary>
        /// 状态:1:正常,0:锁定
        /// </summary>
        public int Status { get; set; }
    }
}
