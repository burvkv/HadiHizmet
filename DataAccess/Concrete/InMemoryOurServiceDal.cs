using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryOurServiceDal 
    {
        List<OurService> _ourServices;
        public InMemoryOurServiceDal()
        {
            _ourServices = new List<OurService> {
            new OurService{Description = "asd", Id=1}
            };
        }

        public void Delete(OurService entity)
        {
            throw new NotImplementedException();
        }

        public List<OurService> GetAll()
        {
            return _ourServices.ToList();
        }

        public OurService GetById(Expression<Func<OurService, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(OurService entity)
        {
            throw new NotImplementedException();
        }

        public void Update(OurService entity)
        {
            throw new NotImplementedException();
        }
    }
}
