using Cibertec.Models;
using System.Collections.Generic;

namespace Cibertec.Repositories.Northwind
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        IEnumerable<Supplier> PagedList(int startRow, int endRow);
        int Count();

    }
}
