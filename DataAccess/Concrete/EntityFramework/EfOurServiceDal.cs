using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Dtos;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOurServiceDal : EfEntityRepositoryBase<OurService,HadiHizmetContext> , IOurServiceDal
    {
        public List<OurServiceDtoForCRUD> GetServiceDetails()
        {
            using (HadiHizmetContext context = new HadiHizmetContext())
            {
              
                var result = from i in context.OurServiceImages
                             join s in context.OurServices
                             on i.OurServiceId equals s.Id
                             select new OurServiceDtoForCRUD
                             {
                                 Title = s.Title,
                                 Date = i.Date,
                                 Description = s.Description,
                                 ImageId = i.ImageId,
                                 ImagePath = i.ImagePath
                             };
                return result.ToList();
            }
        }

        public OurServiceDtoForCRUD GetServiceDetailsById(int id)
        {
            using (HadiHizmetContext context = new HadiHizmetContext())
            {
                var result = from s in context.OurServices
                             join i in context.OurServiceImages
                             on s.Id equals i.OurServiceId
                             where s.Id == id
                             select new OurServiceDtoForCRUD
                             {
                                 Date = i.Date,
                                 Description = s.Description,
                                 ImageId = i.ImageId,
                                 ImagePath = i.ImagePath,
                                 ServiceId = s.Id,
                                 Title = s.Title
                             };
                return result.FirstOrDefault();
            }
        }
    }
}