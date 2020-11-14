using System;

namespace LJS.Core.Model.ViewModels
{
    /// <summary>
    /// 用户信息展示类
    /// </summary>
    public class UserViewModels
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
    }
}
