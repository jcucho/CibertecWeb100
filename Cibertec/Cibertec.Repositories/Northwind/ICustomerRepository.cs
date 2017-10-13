using Cibertec.Models;

namespace Cibertec.Repositories.Northwind
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        Customer searchByNames(string firstName, string lastName);
    }
}
