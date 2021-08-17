using Core.DataAccess;
using Entities.Dtos;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IOurServiceDal : IEntityRepository<OurService>
    {
        List<OurServiceDtoForCRUD> GetServiceDetails();
        OurServiceDtoForCRUD GetServiceDetailsById(int id);

    }
}
