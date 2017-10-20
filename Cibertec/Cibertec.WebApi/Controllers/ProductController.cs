using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

namespace Cibertec.WebApi.Controllers
{
    [Route("api/Product")]
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult getById(int id)
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
                return Ok(new { Message = "The Products is updated" });
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Product product)
        {
            if (product.Id > 0)
                return Ok(_unit.Products.Delete(product));
            return BadRequest(new { Message = "Incorrect data" });
        }
    }
}