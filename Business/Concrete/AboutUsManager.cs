using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class AboutUsManager : IAboutUsService
    {
        IAboutUsDal _aboutUsDal;
        public AboutUsManager(IAboutUsDal aboutUsDal)
        {
            _aboutUsDal = aboutUsDal;
        }

        //Herkes Görecek
        [CacheAspect]
        public IDataResult<AboutUs> Get()
        {
            return new SuccessDataResult<AboutUs>(_aboutUsDal.GetAll().FirstOrDefault());
        }

        [CacheAspect]
        [SecuredOperation("admin")]
        public IDataResult<AboutUs> GetById(int id)
        {
            return new SuccessDataResult<AboutUs>(_aboutUsDal.GetById(a => a.Id == id));
        }


        [TransactionScopeAspect]
        [CacheRemoveAspect("IAboutUsService.Get")]
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(AboutUsValidator))]
        public IResult Update(AboutUs aboutUs)
        {
            _aboutUsDal.Update(aboutUs);
            return new SuccessResult("Hakkımızda bilgisi güncellendi!");
        }
    }
}
