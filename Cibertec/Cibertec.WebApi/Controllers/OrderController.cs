﻿using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

namespace Cibertec.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/order")]
    public class OrderController : BaseController
    {
        public OrderController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.Orders.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Orders.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Orders.Insert(order));
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Order order)
        {
            if (ModelState.IsValid && _unit.Orders.Update(order))
                return Ok(new { Message = "The Order is updated" });
            return BadRequest(ModelState);
        }

        //[HttpDelete]
        //public IActionResult Delete([FromBody] OrderItem orderItem)
        //{
        //    if (orderItem.Id > 0)
        //        return Ok(_unit.OrderItems.Delete(orderItem));
        //    return BadRequest(new { Message = "Incorrect data." });
        //}
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            var order = _unit.Orders.GetById(id);
            if (order.Id > 0)
                return Ok(_unit.Orders.Delete(order));
            return BadRequest(new { Message = "Incorrect data." });
        }

        [HttpGet]
        [Route("count")]
        public IActionResult GetCount()
        {
            return Ok(_unit.Orders.Count());
        }

        [HttpGet]
        [Route("list/{page}/{rows}")]
        public IActionResult GetList(int page, int rows)
        {
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return Ok(_unit.Orders.PagedList(startRecord, endRecord));
        }
    }
}