using Cibertec.WebApi.Controllers;
using Xunit;
using Cibertec.Repositories.Dapper.Northwind;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Cibertec.Models;
using FluentAssertions;

namespace Cibertec.WebApi.Tests
{
    
    public class CustomerControllerTest
    {
        private readonly CustomerController _customerController;

        public CustomerControllerTest()
        {
            _customerController = new CustomerController(new NorthwindUnitOfWork(ConfigSettings.NorthwindConnectionString));
        }

        [Fact]
        public void Test_Get_All()
        {
            var result = _customerController.GetList() as OkObjectResult;
            Assert.True(result != null);
            Assert.True(result.Value != null);
            var model = result.Value as List<Customer>;
            Assert.True(model.Count > 0);
        }

        [Fact]
        public void Test_Get_All_Fluent()
        {
            var result = _customerController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Customer>;
            model.Count.Should().BeGreaterThan(0);

        }
    }
}
