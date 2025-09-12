using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Practica01_.Domain;

namespace WebAPIProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        static readonly List<Bill> lst = new List<Bill>();

        [HttpGet]
        public IActionResult Get()
        {
            lst.Add(new Bill() { Id=1});
            return Ok(lst);
        }
    }
}
