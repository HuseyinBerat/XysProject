using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Sirket:IEntity
    {
    //    public List<Kullanici> _kullanicilar;

    //public virtual List<Kullanici> Kullanicilar
    //{
    //    get { return _kullanicilar ?? (_kullanicilar = new List<Kullanici>()); }
    //    protected set { _kullanicilar = value; }
    //}

    public int SirketId { get; set; }

    public string SirketAd { get; set; }

    public DateTime? BaslangicTarihi { get; set; }

    public DateTime? BitisTarihi { get; set; }

    public int SehirId { get; set; }

    public string LogoDosyaAdi { get; set; }

    public string DomainName { get; set; }

    public string OptikDomainName { get; set; }
    public bool KayitEkranindaGoruntulensinmi { get; set; }
    public bool BayiMi { get; set; }
    public int? BolgeBayiId { get; set; }
    public string SecretKey { get; set; }

    public int SubeSayisi { get; set; }

    public int OgrenciSayisi { get; set; }

    public int OgretmenSayisi { get; set; }

    }
}
