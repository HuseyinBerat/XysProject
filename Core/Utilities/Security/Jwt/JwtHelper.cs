using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get;}
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection(key: "TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

       public AccessToken CreateToken(Kullanici kullanici, List<OperasyonRolleri> operasyonRolleri)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt= CreateJwtSecurityToken(_tokenOptions,kullanici,signingCredentials,operasyonRolleri);
            var jwtSecurityTokenHandler =new JwtSecurityTokenHandler();
            var token=jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration= _accessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,Kullanici kullanici,SigningCredentials signingCredentials,List<OperasyonRolleri> operasyonRolleri)
        {
            var jwt = new JwtSecurityToken
                (issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration ,
                notBefore: DateTime.Now,
                claims: SetClaims(kullanici,operasyonRolleri),
                signingCredentials: signingCredentials
                );
            return jwt;
        }
        private IEnumerable<Claim> SetClaims(Kullanici kullanici,List<OperasyonRolleri> operasyonRolleri)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(kullanici.KullaniciId.ToString());
            claims.AddEmail(kullanici.EPosta);
            claims.AddName($"{kullanici.Ad} {kullanici.Soyad}");
            claims.AddRoles(operasyonRolleri.Select(c=>c.Name).ToArray());
            return claims;
        }
    }
}
           
        
