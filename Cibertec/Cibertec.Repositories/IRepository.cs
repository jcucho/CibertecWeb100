using System.Collections.Generic;

namespace Cibertec.Repositories
{
    public interface IRepository<T> where T : class
    {
        //CRUD
        bool Delete(T entity);
        bool Update(T entity);
        bool Insert(T entity);
        IEnumerable<T> GetList();
        T GetById(int id);

    }
}