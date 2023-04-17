using Azure.Core;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessToken = Core.Utilities.Security.Jwt.AccessToken;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Kullanici> Register(UserforRegisterDto userforRegisterDto);
        IDataResult<Kullanici> Login(UserForLoginDto userForLoginDto);

        IResult UserExists(string username);

        IDataResult<AccessToken> CreateAccessToken(Kullanici kullanici);
    }
}
