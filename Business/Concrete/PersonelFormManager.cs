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
using System.Text;

namespace Business.Concrete
{
    public class PersonelFormManager : IPersonelFormService
    {
        IPersonelFormDal _personelFormDal;
        public PersonelFormManager(IPersonelFormDal personelFormDal)
        {
            _personelFormDal = personelFormDal;
        }

        [CacheAspect]
        [SecuredOperation("admin")]
        public IDataResult<List<PersonelForm>> GetAll()
        {
            return new SuccessDataResult<List<PersonelForm>>(_personelFormDal.GetAll());
        }
       

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IPersonelFormService.Get")]
        public IDataResult<PersonelForm> GetByPhone(string phone)
        {
            return new SuccessDataResult<PersonelForm>(_personelFormDal.GetById(p => p.Phone == phone));
        }

        //Herkes
        [TransactionScopeAspect]
        [ValidationAspect(typeof(PersonelFormValidator))]
        [CacheRemoveAspect("IPersonelFormService.Get")]
        public IResult SendForm(PersonelForm personelForm)
        {
            _personelFormDal.Insert(personelForm);
            return new SuccessResult("Form başarıyla gönderildi.");
        }


        [TransactionScopeAspect]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IPersonelFormService.Get")]
        public IResult Delete(PersonelForm personelForm)
        {
            _personelFormDal.Delete(personelForm);
            return new SuccessResult("Form başarıyla silindi.");

        }
    }
}
