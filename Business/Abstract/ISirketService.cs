using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISirketService
    {
        IDataResult<Sirket> GetById(int sirketId);
        IDataResult<List<Sirket>> GetList();
        IResult Add(Sirket sirket);
        IResult Delete(Sirket sirket);
        IResult Update(Sirket sirket);

    }
}
