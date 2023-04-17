using Business.Abstract;
using Business.Constants;
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
    public class SirketManager : ISirketService
    {
        private ISirketDal _sirketDal;

        public SirketManager(ISirketDal sirketDal)
        {
            _sirketDal = sirketDal;
        }

        public IResult Add(Sirket sirket)
        {
            _sirketDal.Add(sirket);
            return new SuccessResult(Messages.SirketEklendi);
        }

        public IResult Delete(Sirket sirket)
        {
            _sirketDal.Delete(sirket);
            return new SuccessResult(Messages.SirketSilindi);
        }

        public IDataResult<Sirket> GetById(int sirketId)
        {
            return new SuccessDataResult<Sirket>(_sirketDal.Get(s=>s.SirketId==sirketId));
        }

        public IDataResult<List<Sirket>> GetList()
        {
            return new SuccessDataResult<List<Sirket>>(_sirketDal.GetList().ToList());
        }

        public IResult Update(Sirket sirket)
        {
            _sirketDal.Update(sirket);
            return new SuccessResult(Messages.SirketGuncellendi);
        }
    }
}
