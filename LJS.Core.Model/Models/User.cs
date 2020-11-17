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
        #region 构造函数
        public User()
        {
        }

        public User(string loginName, string loginPwd, string realName = null, string remark = null) : base()
        {
            LoginName = loginName;
            LoginPwd = MD5Helper.MD5Encrypt32(loginPwd);
            RealName = realName;
            Remark = remark;
            Status = 1;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 登录账号
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string LoginPwd { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        ///最后登录时间 
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? LastLoginTime { get; set; } = DateTime.Now.ToLocalTime();

        /// <summary>
        ///错误次数 
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int ErrorCount { get; set; }

        /// <summary>
        /// 状态:1:正常,0:锁定
        /// </summary>
        public int Status { get; set; }
        #endregion
    }
}
