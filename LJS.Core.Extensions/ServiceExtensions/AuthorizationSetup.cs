using LJS.Core.Common;
using LJS.Core.Common.AppConfig;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace LJS.Core.Extensions
{
    /// <summary>
    /// 系统 授权服务 配置
    /// </summary>
    public static class AuthorizationSetup
    {
        public static void AddAuthorizationSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var symmetricKeyAsBase64 = AppSecretConfig.Audience_Secret_String;
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            var Issuer = AppSettings.app(new string[] { "Audience", "Issuer" });
            var Audience = AppSettings.app(new string[] { "Audience", "Audience" });

            services.AddAuthentication("Bearer")
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,//是否开启秘钥验证
                        IssuerSigningKey = signingKey,//秘钥
                        ValidateIssuer = true,//是否验证发行人
                        ValidIssuer = Issuer,//发行人
                        ValidateAudience = true,//是否订阅
                        ValidAudience = Audience,//订阅
                        RequireExpirationTime = true,//验证过期时间
                        ValidateLifetime = true,//生命周期
                    };
                });
        }
    }
}