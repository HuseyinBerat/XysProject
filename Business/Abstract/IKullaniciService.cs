using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IKullaniciService
    {
        IDataResult<Kullanici> GetById(int kullaniciId);

        IDataResult<List<Kullanici>> GetListBySirket(int sirketId);
        IDataResult<List<Kullanici>> GetList();

        IDataResult<List<OperasyonRolleri>> GetOperasyonRolleri(Kullanici kullanici);

        IDataResult<Kullanici> GetByUserName(string userName);

        IResult Add(Kullanici kullanici);
        IResult Delete(Kullanici kullanici);
        IResult Update(Kullanici kullanici);
    }
}
