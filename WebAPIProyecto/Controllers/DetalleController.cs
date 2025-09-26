using FacturacionAPI.DataModels.Repositories;
using FacturacionAPI.DataModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FacturacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleController : ControllerBase
    {
        private IDetalleRepository _repository;

        public DetalleController(IDetalleRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<DetalleController>
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


        // POST api/<DetalleController>
        [HttpPost]
        public IActionResult Post([FromBody] detallesFactura value)
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
