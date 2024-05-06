using ECommerce.Cargo.DataAccessLayer.Abstrack;
using ECommerce.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Cargo.BusinessLayer.Concrete
{
    public class CargoCompanyManager : ICargoCompanyDal
    {
        private readonly ICargoCompanyDal cargoCompanyDal;

        public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
        {
            this.cargoCompanyDal = cargoCompanyDal;
        }

        public void Delete(int id)
        {
            cargoCompanyDal.Delete(id);
        }

        public List<CargoCompany> getAllList()
        {
           return cargoCompanyDal.getAllList();
        }

        public CargoCompany GetById(int id)
        {
          return cargoCompanyDal.GetById(id);
        }

        public void Insert(CargoCompany entity)
        {
           cargoCompanyDal.Insert(entity);
        }

        public void Update(CargoCompany entity)
        {
            cargoCompanyDal.Update(entity);
        }
    }
}
