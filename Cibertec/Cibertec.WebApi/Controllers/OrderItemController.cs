using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

namespace Cibertec.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/orderitem")]
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
        public IActionResult GetById(int id)
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
                return Ok(new { Message = "The OrderItem is updated" });
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
            var orderItem = _unit.OrderItems.GetById(id);
            if (orderItem.Id > 0)
                return Ok(_unit.OrderItems.Delete(orderItem));
            return BadRequest(new { Message = "Incorrect data." });
        }

        [HttpGet]
        [Route("count")]
        public IActionResult GetCount()
        {
            return Ok(_unit.OrderItems.Count());
        }

        [HttpGet]
        [Route("list/{page}/{rows}")]
        public IActionResult GetList(int page, int rows)
        {
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return Ok(_unit.OrderItems.PagedList(startRecord, endRecord));
        }
    }
}