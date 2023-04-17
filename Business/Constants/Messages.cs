using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string KullaniciEklendi = "KUllanıcı eklendi";
        public static string KullaniciSilindi = "KUllanıcı silindi";
        public static string KullaniciGuncellendi = "KUllanıcı güncellendi";
        public static string SirketEklendi = "Sirket eklendi";
        public static string SirketSilindi = "Sirket silindi";
        public static string SirketGuncellendi = "Sirket güncellendi";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin="Başarılı giriş";
        public static string UserAlreadyExist="Kullanıcı zaten mevcut";
        public static string UserRegistered="Kullanıcı kaydı oluşturuldu";
        public static string AccessTokenCreated="Access Token oluşturuldu";
    }
}

