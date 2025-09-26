using FacturacionAPI.DataModels;
using FacturacionAPI.DataModels.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
        public IActionResult Post([FromBody] factura value)
        {
            try
            {
                if (value == null)
                {
                    return BadRequest("Formato inválido");
                }
                else
                {
                    _repository.Save(value);
                    return Ok("Creado con éxito");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            try
            {
                _repository.Delete(id);
                return Ok("Eliminado con éxito");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }

    }
}
