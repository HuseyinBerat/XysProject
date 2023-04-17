using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfKullaniciDal : EfEntityRepositoryBase<Kullanici, XysContext>, IKullaniciDal
    {
        public List<OperasyonRolleri> GetOperasyonRolleri(Kullanici kullanici)
        {
           using (var context = new XysContext()) 
            {
                var result = from operasyonRolleri in context.OperasyonRolleri join kullaniciOperasyonRolleri in context.KullaniciOperasyonRolleri
                             on operasyonRolleri.Id equals kullaniciOperasyonRolleri.OperasyonRoluId
                             where kullaniciOperasyonRolleri.KullaniciId == kullanici.KullaniciId
                             select new OperasyonRolleri { Id = operasyonRolleri.Id, Name = operasyonRolleri.Name, };
                return result.ToList();
            }
        }
    }
}
