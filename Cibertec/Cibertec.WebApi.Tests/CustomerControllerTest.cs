using Cibertec.Mocked;
using Cibertec.Models;
using Cibertec.UnitOfWork;
using Cibertec.WebApi.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;
using Cibertec.Repositories.Dapper.Northwind;

namespace Cibertec.WebApi.Tests
{
    
    public class CustomerControllerTest
    {
        private readonly CustomerController _customerController;
        private readonly IUnitOfWork _uniMocked;

        public CustomerControllerTest()
        {
            var unitMocked = new UnitOfWorkMocked();
            _uniMocked = unitMocked.GetInstance();
            _customerController = new CustomerController(_uniMocked);
            //_customerController = new CustomerController(new NorthwindUnitOfWork(ConfigSettings.NorthwindConnectionString));
        }
        //[Fact(DisplayName ="[CustomerController] Get List")]
        //public void Test_Get_All()
        //{
        //    var result = _customerController.GetList() as OkObjectResult;
        //    Assert.True(result != null);
        //    Assert.True(result.Value != null);
        //    var model = result.Value as List<Customer>;
        //    Assert.True(model.Count > 0);
        //}

        [Fact(DisplayName = "[CustomerController] Get List")]
        public void Get_All_Test()
        {
            var result = _customerController.GetList() as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
            var model = result.Value as List<Customer>;
            model.Count.Should().BeGreaterThan(0);        
        }

        [Fact(DisplayName = "[CustomerController] Insert")]
        public void Insert_Customer_Test()
        {
            var customer = new Customer
            {   Id = 101,
                City = "Lima",
                Country = "Peru",
                FirstName = "Juan",
                LastName = "Cucho",
                Phone = "998357111"
            };
            var result = _customerController.Post(customer) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToInt32(result.Value);
            model.Should().Be(101);
        }

        [Fact(DisplayName = "[CustomerController] Update")]
        public void Update_Customer_Test()
        {
            var customer = new Customer
            {
                Id = 1,
                City = "Lima",
                Country = "Peru",
                FirstName = "Juan",
                LastName = "Cucho",
                Phone = "998357111"
            };

            var result = _customerController.Put(customer) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value?.GetType().GetProperty("Message").GetValue(result.Value);
            model.Should().Be("The customer is updated");

            var currentCustomer = _uniMocked.Customers.GetById(1);
            currentCustomer.Should().NotBeNull();
            currentCustomer.Id.Should().Be(customer.Id);
            currentCustomer.City.Should().Be(customer.City);
            currentCustomer.Country.Should().Be(customer.Country);
            currentCustomer.FirstName.Should().Be(customer.FirstName);
            currentCustomer.LastName.Should().Be(customer.LastName);
            currentCustomer.Phone.Should().Be(customer.Phone);
        }

        [Fact(DisplayName = "[CustomerController] Delete")]
        public void Delete_Customer_Test()
        {
            var customer = new Customer
            {
                Id = 1
            };
            var result = _customerController.Delete(customer) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToBoolean(result.Value);
            model.Should().BeTrue();

            var currentCustomer = _uniMocked.Customers.GetById(1);
            currentCustomer.Should().BeNull();
        }
    }


}
