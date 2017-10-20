﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

namespace Cibertec.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Customer")]
    public class CustomerController : BaseController
    {
        public CustomerController(IUnitOfWork unit): base(unit)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_unit.Customers.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult getById(int id)
        {
            return Ok(_unit.Customers.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Customers.Insert(customer));
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Customer customer)
        {
            if (ModelState.IsValid && _unit.Customers.Update(customer))
                return Ok(new { Message = "The customer is updated" });
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Customer customer)
        {
            if (customer.Id > 0)
                return Ok(_unit.Customers.Delete(customer));
            return BadRequest(new { Message = "Incorrect data" });
        }
    }
}