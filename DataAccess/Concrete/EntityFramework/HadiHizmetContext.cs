using Core.Entity.Concrete;
using Entities.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class HadiHizmetContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-AR35RQF;database=HadiHizmet;Trusted_Connection=true");
        }

        public DbSet<OurService> OurServices { get; set; }
        public DbSet<OurServiceImage> OurServiceImages { get; set; }
        public DbSet<AboutUs> AboutUsInfos { get; set; }      
        public DbSet<PersonelForm> PersonelForms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
    }

}
