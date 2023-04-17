using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Kullanici:IEntity
    {
        //private List<KullaniciYetki> _yetkiler;
        //public virtual List<KullaniciYetki> Yetkiler
        //{
        //    get { return _yetkiler ?? (_yetkiler = new List<KullaniciYetki>()); }   Yetkilendirme backend yerine API de yapıldı
        //    protected set { _yetkiler = value; }
        //}

        public int KullaniciId { get; set; }

        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public bool Status { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string ProfilFotografi { get; set; }

        public string EPosta { get; set; }

        public bool EPostaOnayDurumu { get; set; }

        public bool Bloke { get; set; }

        public int SirketId { get; set; }
        public DateTime EklenmeTarihi { get; set; }s
        public DateTime SonGirisTarihi { get; set; }
        public int SeciliSubeId { get; set; }

        public DateTime SifreGuncellemeTarihi { get; set; }
        public bool SifreDegistirildiMi { get; set; }
        public bool KvkkOnaylandiMi { get; set; }

        public int ProfilId { get; set; }

        public string SirketIdListesi { get; set; }

        public string SubeIdListesi { get; set; }

        public DateTime? SonKullanmaTarihi { get; set; }

        //public int[] YetkiliOlduguSirketler
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(SirketIdListesi) == false)
        //        {
        //            return SirketIdListesi
        //                       .Split(',')
        //                       .Select(n => Convert.ToInt32(n))
        //                       .ToArray();
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}

        //public int[] YetkiliOlduguSubeler
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(SubeIdListesi) == false)
        //        {
        //            return SubeIdListesi
        //                       .Split(',')
        //                       .Select(n => Convert.ToInt32(n))
        //                       .ToArray();
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}
    }
}
