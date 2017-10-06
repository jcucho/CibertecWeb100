using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Cibertec.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //inyeccion de dependencias
        protected DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }

        public bool Delete(T entity)
        {
            _context.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetList()
        {
            return _context.Set<T>();
        }

        public bool Insert(T entity)
        {
            _context.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public bool Update(T entity)
        {
            _context.Update(entity);
            return _context.SaveChanges() > 0;
        }

        int IRepository<T>.Insert(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
