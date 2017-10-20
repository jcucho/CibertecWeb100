using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
using Cibertec.UnitOfWork;

namespace Cibertec.WebApi.Controllers
{
    [Produces("application/json")]
    //[Authorize]
    public class BaseController : Controller
    {
        protected IUnitOfWork _unit;
        public BaseController(IUnitOfWork unit)
        {
            _unit = unit;            
        }
    }
}