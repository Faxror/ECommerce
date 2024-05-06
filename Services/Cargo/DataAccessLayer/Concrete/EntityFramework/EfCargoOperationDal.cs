using ECommerce.Cargo.DataAccessLayer.Abstrack;
using ECommerce.Cargo.DataAccessLayer.Concrete.Repositories;
using ECommerce.Cargo.DataAccessLayer.Context;
using ECommerce.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Cargo.DataAccessLayer.Concrete.EntityFramework
{
    public class EfCargoOperationDal : GenericRepository<CargoOperation>, ICargoOperationDal
    {
        public EfCargoOperationDal(CargoContext context) : base(context) 
        {
            
        }
    }
}
