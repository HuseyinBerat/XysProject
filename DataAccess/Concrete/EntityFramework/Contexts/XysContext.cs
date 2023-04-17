using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class XysContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=XysProject;Trusted_Connection=true");
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Sirket> Sirketler{ get; set; }

        public DbSet<OperasyonRolleri> OperasyonRolleri { get; set; }

        public DbSet<KullaniciOperasyonRolleri> KullaniciOperasyonRolleri { get; set; }
    }
}
