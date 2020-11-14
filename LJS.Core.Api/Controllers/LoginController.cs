using LJS.Core.Common;
using LJS.Core.Common.AppConfig;
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
    [CustomRoute(ApiVersions.v3)]
    public class LoginController : ControllerBase
    {
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
