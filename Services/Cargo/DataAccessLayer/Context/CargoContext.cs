using ECommerce.Cargo.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Cargo.DataAccessLayer.Context
{
    public class CargoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1488; initial Catalog=ECommerceCargoDb;  User=sa; Password=123456aA*");
            base.OnConfiguring(optionsBuilder);
        }

      

        public DbSet<CargoCostumer> cargoCostumers { get; set; }
        public DbSet<CargoCompany> cargoCompanies { get; set; }
        public DbSet<CargoDetail> cargoDetails { get; set; }
        public DbSet<CargoOperation> cargoOperations { get; set; }
    }
}
