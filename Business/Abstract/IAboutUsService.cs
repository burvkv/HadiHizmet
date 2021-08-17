using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAboutUsService
    {
        IDataResult<AboutUs> Get();
        IResult Update(AboutUs aboutUs);
        IDataResult<AboutUs> GetById(int id);
    }
}
