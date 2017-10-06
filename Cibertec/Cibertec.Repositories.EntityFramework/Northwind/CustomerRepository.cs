using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cibertec.Repositories.EntityFramework.Northwind
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context): base(context)
        {
        }
        public Customer searchByNames(string firstname, string lastname)
        {
            return _context.Set<Customer>().FirstOrDefault(x => x.FirstName == firstname && x.LastName == lastname);
        }
    }
}
