﻿using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;


namespace Cibertec.WebApi.Controllers
{
    public class OrderItemController : BaseController
    {
        public OrderItemController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.OrderItems.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult getById(int id)
        {
            return Ok(_unit.OrderItems.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrderItem orderItem)
        {
            if (ModelState.IsValid)
                return Ok(_unit.OrderItems.Insert(orderItem));
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Put([FromBody] OrderItem orderItem)
        {
            if (ModelState.IsValid && _unit.OrderItems.Update(orderItem))
                return Ok(new { Message = "The order Item is updated" });
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] OrderItem orderItem)
        {
            if (orderItem.Id > 0)
                return Ok(_unit.OrderItems.Delete(orderItem));
            return BadRequest(new { Message = "Incorrect data" });
        }
    }
}