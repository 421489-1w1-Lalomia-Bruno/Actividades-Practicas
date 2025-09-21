using FacturacionAPI.DataModels.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FacturacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private IFacturaRepository _repository;

        public FacturaController(IFacturaRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<FacturaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }

        }


        // POST api/<FacturaController>
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return null;
        }

    }
}
