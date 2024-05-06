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
    public class CargoCostumerManager : ICargoCostumerService
    {
        private readonly ICargoCostumerDal cargoCostumerDal;

        public CargoCostumerManager(ICargoCostumerDal cargoCostumerDal)
        {
            this.cargoCostumerDal = cargoCostumerDal;
        }

        public void TDelete(int id)
        {
           cargoCostumerDal.Delete(id);
        }

        public List<CargoCostumer> TgetAllList()
        {
           return cargoCostumerDal.getAllList();
        }

        public CargoCostumer TGetById(int id)
        {
           return cargoCostumerDal.GetById(id);
        }

        public void TInsert(CargoCostumer entity)
        {
           cargoCostumerDal.Insert(entity);
        }

        public void TUpdate(CargoCostumer entity)
        {
            cargoCostumerDal.Update(entity);
        }
    }
}
