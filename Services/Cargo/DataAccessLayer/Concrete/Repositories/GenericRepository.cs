using ECommerce.Cargo.DataAccessLayer.Abstrack;
using ECommerce.Cargo.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Cargo.DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CargoContext _context;

        public GenericRepository(CargoContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var valuse = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(valuse);
            _context.SaveChanges();
        }

        public List<T> getAllList()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            var valuse = _context.Set<T>().Find(id);
            return valuse;
        }

        public void Insert(T entity)
        {
           _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
