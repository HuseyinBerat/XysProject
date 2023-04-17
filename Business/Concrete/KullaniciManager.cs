using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class KullaniciManager : IKullaniciService
    {
        private IKullaniciDal _kullaniciDal;

        public KullaniciManager(IKullaniciDal kullaniciDal)
        {
            _kullaniciDal= kullaniciDal;
        }
        public IResult Add(Kullanici kullanici)
        {
            _kullaniciDal.Add(kullanici);
            return new SuccessResult(Messages.KullaniciEklendi);
        }

        public IResult Delete(Kullanici kullanici)
        {
            _kullaniciDal.Delete(kullanici);
            return new SuccessResult(Messages.KullaniciSilindi);
        }

        public IDataResult<Kullanici> GetById(int kullaniciId)
        {
            return new SuccessDataResult<Kullanici>( _kullaniciDal.Get(k=>k.KullaniciId== kullaniciId));
        }

        public IDataResult<Kullanici> GetByUserName(string userName)
        {
            return new SuccessDataResult<Kullanici>(_kullaniciDal.Get(k=>k.UserName== userName));
        }

        public IDataResult<List<Kullanici>> GetList()
        {
            return new SuccessDataResult<List<Kullanici>>( _kullaniciDal.GetList().ToList());
        }

        public IDataResult<List<Kullanici>> GetListBySirket(int sirketId)
        {
            return new SuccessDataResult<List<Kullanici>>(_kullaniciDal.GetList(k=>k.SirketId== sirketId).ToList());
        }

        public IDataResult<List<OperasyonRolleri>> GetOperasyonRolleri(Kullanici kullanici)
        {
            return new SuccessDataResult<List<OperasyonRolleri>>(_kullaniciDal.GetOperasyonRolleri(kullanici));
        }

        public IResult Update(Kullanici kullanici)
        {
            _kullaniciDal.Update(kullanici);
            return new SuccessResult(Messages.KullaniciGuncellendi);
        }

    }
}
