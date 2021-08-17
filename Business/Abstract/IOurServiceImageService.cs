using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOurServiceImageService 
    {
        IDataResult<List<OurServiceImage>> GetByServiceId(int serviceId);
        IDataResult<OurServiceImage> GetByImageId(int imageId);
        IDataResult<List<OurServiceImage>> GetAll();
        IResult Add(OurServiceImage ourServiceImage, IFormFile file);
        IResult Remove(OurServiceImage ourServiceImage);
        IResult Update(OurServiceImage ourServiceImage, IFormFile file);
    }
}
