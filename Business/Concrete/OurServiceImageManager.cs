using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspect.Autofac;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class OurServiceImageManager : IOurServiceImageService
    {
        IOurServiceImageDal _ourServiceImageDal;
        IFileHelper _fileHelper;
        public OurServiceImageManager(IOurServiceImageDal ourServiceImageDal, IFileHelper fileHelper)
        {
            _ourServiceImageDal = ourServiceImageDal;
            _fileHelper = fileHelper;
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(OurServiceImageValidator))]
        [CacheRemoveAspect("IOurServiceImageService.Get")]
        [TransactionScopeAspect]
        public IResult Add(OurServiceImage ourServiceImage, IFormFile file)
        {
           
            
                IResult result = BusinessRules.Run(IsOverflowServicemageCount(file.FileName.Length));
                if (result != null)
                {
                    return new ErrorResult(result.Message);
                }

                var imageResult = _fileHelper.Upload(file);
                if (!imageResult.Success)
                {
                    return new ErrorResult(Messages.ServiceImageDenied);
                }

                ourServiceImage.ImagePath = imageResult.Message;
                ourServiceImage.Date = DateTime.Now;
                _ourServiceImageDal.Insert(ourServiceImage);
            
            
           
            
            return new SuccessResult(Messages.ServiceImageAdded);
        }

        [TransactionScopeAspect]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IOurServiceImageService.Get")]
        public IResult Remove(OurServiceImage ourServiceImage)
        {
            try
            {
                var imageDelete = _ourServiceImageDal.GetById(o => o.ImageId == ourServiceImage.ImageId);
                if (imageDelete == null)
                {
                    return new ErrorResult("Fotoğraf bulunamadı.");
                }
                _ourServiceImageDal.Delete(ourServiceImage);
                _fileHelper.Remove(ourServiceImage.ImagePath);
                return new SuccessResult("Fotoğraf silindi!");
            }
            catch (Exception)
            {
                return new ErrorResult("Fotoğraf silinemedi.");
            }
        }


        [SecuredOperation("admin")]
        [CacheAspect]
        public IDataResult<List<OurServiceImage>> GetAll()
        {
            return new SuccessDataResult<List<OurServiceImage>>(_ourServiceImageDal.GetAll(), "Tüm fotoğraflar listelendi");
        }

        //Herkes
        [CacheAspect]
        public IDataResult<List<OurServiceImage>> GetByServiceId(int serviceId)
        {
            return new SuccessDataResult<List<OurServiceImage>>(_ourServiceImageDal.GetAll(i => i.OurServiceId == serviceId).ToList(), "Tüm fotoğraflar listelendi");
        }


        [CacheAspect]
        [SecuredOperation("admin")]
        public IDataResult<OurServiceImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<OurServiceImage>(_ourServiceImageDal.GetById(i => i.ImageId == imageId), "Fotoğraf getirildi.");
        }


        [TransactionScopeAspect]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IOurServiceImageService.Get")]
        public IResult Update(OurServiceImage ourServiceImage, IFormFile file)
        {
           
                var imageUpdate = _ourServiceImageDal.GetById(o => o.ImageId == ourServiceImage.ImageId);
                if (imageUpdate == null)
                {
                    return new ErrorResult("Fotoğraf bulunamadı.");
                }

                var updatedFile = _fileHelper.Update(file, imageUpdate.ImagePath);
                if (!updatedFile.Success)
                {
                    return new ErrorResult("Güncelleme başarısız.");
                }
                ourServiceImage.ImagePath = updatedFile.Message;
                _ourServiceImageDal.Update(ourServiceImage);
            
            
            return new SuccessResult("Güncelleme işlemi başarılı!");
        }

        private IResult IsOverflowServicemageCount(int serviceId)
        {
            var result = _ourServiceImageDal.GetAll(im => im.OurServiceId == serviceId);

            if (result.Count > 10)
            {
                return new ErrorResult(Messages.ServiceImageLimitExceeded);
            }

            return new SuccessResult();

        }

        private IResult ShowDefaultImage(int serviceId)
        {

            try
            {
                string path = @"\images\default.jpg";
                var result = _ourServiceImageDal.GetAll(s => s.OurServiceId == serviceId).Any();
                if (result)
                {
                    List<OurServiceImage> serviceImages = new List<OurServiceImage>();
                    serviceImages.Add(new OurServiceImage
                    {
                        OurServiceId = serviceId,
                        Date = DateTime.Now,
                        ImagePath = path
                    });
                    return new SuccessDataResult<List<OurServiceImage>>(serviceImages);
                }

            }
            catch (Exception)
            {
                return new ErrorDataResult<List<OurServiceImage>>();
            }

            return new SuccessDataResult<List<OurServiceImage>>(_ourServiceImageDal.GetAll(c => c.OurServiceId == serviceId).ToList());
        }
    }
}
