using Core.Utilities.Results;
using Entities.Dtos;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOurServiceService : IServiceRepository<OurService>
    {
        IDataResult<List<OurServiceDtoForCRUD>> GetServiceDetails();
        IDataResult<OurServiceDtoForCRUD> GetServiceDetailsById(int id);


    }
}
