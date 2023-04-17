using Azure.Core;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IKullaniciService _kullaniciService;
        ITokenHelper _tokenhelper;

        public AuthManager(IKullaniciService kullaniciService, ITokenHelper tokenhelper)
        {
            _kullaniciService = kullaniciService;
            _tokenhelper = tokenhelper;
        }

        public IDataResult<Core.Utilities.Security.Jwt.AccessToken> CreateAccessToken(Kullanici kullanici)
        {
           var claims= _kullaniciService.GetOperasyonRolleri(kullanici);
           var accessToken= _tokenhelper.CreateToken(kullanici, claims.Data);
            return new SuccessDataResult<Core.Utilities.Security.Jwt.AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<Kullanici> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _kullaniciService.GetByUserName(userForLoginDto.UserName);
            if (userToCheck == null) 
            {
                return new ErrorDataResult<Kullanici>(Messages.UserNotFound);

            }
            if(!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.Data.PasswordHash,userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<Kullanici>(Messages.PasswordError);
            }
            return new SuccessDataResult<Kullanici>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public IDataResult<Kullanici> Register(UserforRegisterDto userforRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userforRegisterDto.Password,out passwordHash,out passwordSalt);
            var user = new Kullanici
            {
                EklenmeTarihi = DateTime.Now, EPostaOnayDurumu = true, KvkkOnaylandiMi = true, Bloke = true, EPosta = "", ProfilFotografi = "", SifreDegistirildiMi = true, SubeIdListesi = "", SonKullanmaTarihi = DateTime.Now, SifreGuncellemeTarihi = DateTime.Now, SonGirisTarihi = DateTime.Now, Status = true, SeciliSubeId = 1, ProfilId = 1, SirketIdListesi = "", SirketId = 1,
                Ad = userforRegisterDto.FirstName,
                Soyad = userforRegisterDto.LastName,
                UserName = userforRegisterDto.UserName,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };
            _kullaniciService.Add(user);
            return new SuccessDataResult<Kullanici>(user, Messages.UserRegistered);
        }
                




        public IResult UserExists(string userName)
        {
            if (_kullaniciService.GetByUserName(userName).Data !=null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }
            return new SuccessResult();
        }

    }
}
