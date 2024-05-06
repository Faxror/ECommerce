using ECommerce.Cargo.BusinessLayer.Abstrack;
using ECommerce.Cargo.DataAccessLayer.Abstrack;
using ECommerce.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Cargo.BusinessLayer.Concrete
{
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal cargoOperationDal;

        public CargoOperationManager(ICargoOperationDal cargoOperationDal)
        {
            this.cargoOperationDal = cargoOperationDal;
        }

        public void TDelete(int id)
        {
            cargoOperationDal.Delete(id);
        }

        public List<CargoOperation> TgetAllList()
        {
           return cargoOperationDal.getAllList();
        }

        public CargoOperation TGetById(int id)
        {
            return cargoOperationDal.GetById(id);
        }

        public void TInsert(CargoOperation entity)
        {
           cargoOperationDal.Insert(entity);
        }

        public void TUpdate(CargoOperation entity)
        {
            cargoOperationDal.Update(entity);
        }
    }
}
