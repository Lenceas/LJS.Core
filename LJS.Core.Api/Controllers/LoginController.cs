using AutoMapper;
using LJS.Core.Common;
using LJS.Core.Common.AppConfig;
using LJS.Core.Common.Helper;
using LJS.Core.IServices;
using LJS.Core.Model;
using LJS.Core.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static LJS.Core.Extensions.CustomApiVersion;

namespace LJS.Core.Api.Controllers
{
    /// <summary>
    /// 登录接口
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [CustomRoute(ApiVersions.v3)]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;

        public LoginController(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name">登录账号</param>
        /// <param name="pwd">登录密码</param>
        /// <returns></returns>
        [HttpGet("Token")]
        public async Task<MessageModel<string>> Login(string name, string pwd)
        {
            var data = new MessageModel<string>();
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pwd))
            {
                data.status = 202;
                data.msg = "账号或密码不能为空";
                return data;
            }
            pwd = MD5Helper.MD5Encrypt32(pwd);
            var user = await _userServices.Query(t => t.LoginName == name && t.LoginPwd == pwd && t.IsDeleted == false && t.Status == 1);
            if (user.Count > 0)
            {
                data.success = true;
                data.msg = "登录成功";
            }
            else
            {
                data.status = 202;
                data.msg = "账号或密码错误";
            }
            return data;
        }

        /// <summary>
        /// 获取JWT的方法
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetJwtToken")]
        public string GetJwtToken()
        {
            SecurityToken securityToken = new JwtSecurityToken(
                issuer: AppSettings.app(new string[] { "Audience", "Issuer" }),
                audience: AppSettings.app(new string[] { "Audience", "Audience" }),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AppSecretConfig.Audience_Secret_String)), SecurityAlgorithms.HmacSha256),
                expires: DateTime.Now.AddMinutes(1),
                claims: new Claim[] { }
                );
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
