using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class OurServiceDtoForCRUD : IDto
    {
        public int ServiceId { get; set; }
        public int ImageId { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }

    }
}
