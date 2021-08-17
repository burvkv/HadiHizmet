using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Dtos;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OurServiceManager : IOurServiceService
    {
        IOurServiceDal _ourServiceDal;
        IOurServiceImageService _serviceImageService;
        public OurServiceManager(IOurServiceDal ourServiceDal)
        {
            _ourServiceDal = ourServiceDal;
        }


        [TransactionScopeAspect]
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(OurServiceValidator))]
        [CacheRemoveAspect("IOurServiceService.Get")]
        public IResult Insert(OurService entity)
        {
            _ourServiceDal.Insert(entity);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IOurServiceService.Get")]
        public IResult Delete(OurService entity)
        {
            _ourServiceDal.Delete(entity);
            return new SuccessResult();
        }


        [TransactionScopeAspect]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IOurServiceService.Get")]
        public IResult Update(OurService entity)
        {
            _ourServiceDal.Update(entity);
            return new SuccessResult();
        }

        //Herkes
        [CacheAspect]
        public IDataResult<List<OurService>> GetAll()
        {
            return new SuccessDataResult<List<OurService>>(_ourServiceDal.GetAll());
        }

        [SecuredOperation("admin")]
        [CacheAspect]
        public IDataResult<OurService> GetById(int id)
        {
            return new SuccessDataResult<OurService>(_ourServiceDal.GetById(o => o.Id == id));
        }


        [CacheAspect]
        public IDataResult<List<OurServiceDtoForCRUD>> GetServiceDetails()
        {
            return new SuccessDataResult<List<OurServiceDtoForCRUD>>(_ourServiceDal.GetServiceDetails());
            
        }

        [CacheAspect]
        public IDataResult<OurServiceDtoForCRUD> GetServiceDetailsById(int id)
        {
            return new SuccessDataResult<OurServiceDtoForCRUD>(_ourServiceDal.GetServiceDetailsById(id));

        }

    }
}
