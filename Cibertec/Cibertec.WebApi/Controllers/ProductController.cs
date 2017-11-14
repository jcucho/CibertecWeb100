﻿using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

namespace Cibertec.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/product")]
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.Products.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Products.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Products.Insert(product));
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            if (ModelState.IsValid && _unit.Products.Update(product))
                return Ok(new { Message = "The product is updated" });
            return BadRequest(ModelState);
        }

        //[HttpDelete]
        //public IActionResult Delete([FromBody] Product product)
        //{
        //    if (product.Id > 0)
        //        return Ok(_unit.Products.Delete(product));
        //    return BadRequest(new { Message = "Incorrect data." });
        //}
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            var product = _unit.Products.GetById(id);
            if (product.Id > 0)
                return Ok(_unit.Products.Delete(product));
            return BadRequest(new { Message = "Incorrect data." });
        }

        [HttpGet]
        [Route("count")]
        public IActionResult GetCount()
        {
            return Ok(_unit.Products.Count());
        }

        [HttpGet]
        [Route("list/{page}/{rows}")]
        public IActionResult GetList(int page, int rows)
        {
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return Ok(_unit.Products.PagedList(startRecord, endRecord));
        }
    }
}