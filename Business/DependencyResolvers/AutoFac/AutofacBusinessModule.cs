using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.AutoFac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<KullaniciManager>().As<IKullaniciService>();
            builder.RegisterType<EfKullaniciDal>().As<IKullaniciDal>();

            builder.RegisterType<SirketManager>().As<ISirketService>();
            builder.RegisterType<EfSirketDal>().As<ISirketDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}
