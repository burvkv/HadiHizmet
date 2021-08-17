using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.Concrete
{
    public class OurService : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }


    }
}
