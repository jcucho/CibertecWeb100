using Cibertec.Models;
using Cibertec.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Cibertec.RepositoriesTests
{
    public class CustomerRepositoryTest
    {
        private readonly DbContext _context;

        public CustomerRepositoryTest()
        {
            _context = new NorthwindDbContext();
        }

        //[Fact(DisplayName = "[CustomerRepository] Get All")]
        //public void Customer_Repository_GetAll()
        //{
        //    var repo = new Repository<Customer>(_context);
        //    var result = repo.GetList();
        //    //result.
        //    Assert.True(result.Count() > 0);
        //}
    }
}
