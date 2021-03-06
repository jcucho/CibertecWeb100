using Cibertec.Models;
using Cibertec.Repositories.Dapper.Northwind;
using System;
using System.Linq;
using Xunit;

namespace Cibertec.Repositories.DapperTests
{
    public class CustomerRepositoryTest
    {
        private readonly CustomerRepository repo;

        public CustomerRepositoryTest()
        {
            repo = new CustomerRepository("Server=JUAN-PC\\MSSQLSERVER14;Database=Northwind_Lite; Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        [Fact(DisplayName = "[CustomerRepository Dapper]Get All")]
        public void Customer_Repository_GetAll()
        {
            var result = repo.GetList();
            Assert.True(result.Count() > 0);
        }

        [Fact(DisplayName = "[CustomerRepository Dapper]Insert")]
        public void Customer_Repository_Insert()
        {
            var customer = GetNewCustomer();
            var result = repo.Insert(customer);
            Assert.True(result > 0);
        }
        [Fact(DisplayName = "[CustomerRepository Dapper]Delete")]
        public void Customer_Repository_Delete()
        {
            var customer = GetNewCustomer();
            var result = repo.Insert(customer);
            Assert.True(repo.Delete(customer));
        }

        private Customer GetNewCustomer()
        {
            return new Customer
            {
                City = "Lima",
                Country = "Peru",
                FirstName = "Julio",
                LastName = "Velarde",
                Phone = "555-555-555"
            };
        }

        [Fact(DisplayName = "[CustomerRepository Dapper]Update")]
        public void Customer_Repository_Update()
        {
            var customer = repo.GetById(10);
            Assert.True(customer != null);
            customer.FirstName = $"Today {DateTime.Now.ToShortDateString()}";
            Assert.True(repo.Update(customer));
        }

        [Fact(DisplayName = "[CustomerRepository Dapper]Get By Id")]
        public void Customer_Repository_Get_By_Id()
        {
            var customer = repo.GetById(10);
            Assert.True(customer != null);
        }
    }
}
