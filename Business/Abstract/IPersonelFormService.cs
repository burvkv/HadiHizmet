using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPersonelFormService
    {
        IDataResult<List<PersonelForm>> GetAll();
        IDataResult<PersonelForm> GetByPhone(string phone);
        IResult SendForm(PersonelForm personelForm);
        IResult Delete(PersonelForm personelForm);
    }
}
