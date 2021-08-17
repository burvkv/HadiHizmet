using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class OurServiceImage:IEntity
    {
        [Key]
        public int ImageId { get; set; }
        public int OurServiceId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }


    }
}
