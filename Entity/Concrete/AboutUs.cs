using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class AboutUs:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string CompanyName { get; set; }
        public string AboutUsText { get; set; }
        public string Since { get; set; }

    }
}
