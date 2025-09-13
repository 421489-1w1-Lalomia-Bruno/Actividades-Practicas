using FacturacionBack.Data.Interfaces;
using FacturacionBack.Data.Repositories;
using FacturacionBack.Domain;
using FacturacionBack.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillDetailController : ControllerBase
    {
        private IBillDetailRepository _bds;

        public BillDetailController()
        {
            _bds = new BillDetailRepository();
        }

        [HttpGet("/billDetail")]
        public IActionResult Get()
        {
            List<BillDetail> lst = null;
            try
            {
                lst = _bds.GetAll();
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpGet("/billDetail/{id}")]
        public IActionResult Get(int id)
        {
            BillDetail billD = _bds.GetById(id);
            try
            {
                if (billD == null)
                {
                    return BadRequest("Id inválido");
                }

                return Ok(billD);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpPost("/billDetail")]

        public IActionResult Post([FromBody] BillDetail billD)
        {
            try
            {
                if (billD == null)
                {
                    return BadRequest("Factura vacía");
                }
                if (_bds.Save(billD))
                    return Ok("Factura registrada");
                else
                    return StatusCode(500, "Factura vacía");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpPut("/billDetail/{id}")]
        public IActionResult Put(int id, [FromBody] BillDetail billD)
        {
            try
            {
                if (billD == null)
                {
                    return BadRequest("Factura vacía");
                }

                BillDetail billD1 = _bds.GetById(id);

                billD1.Id = billD.Id;
                billD1.IdProduct = billD.IdProduct;
                billD1.Amount = billD.Amount;
                billD1.IdBill = billD.IdBill;
                
                bool result = _bds.Save(billD1);
                bool delet = _bds.Delete(billD.Id); //no sirve para id identity

                if (result)
                    return Ok("Factura registrada");
                else
                    return StatusCode(500, "Error Interno");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpDelete("/billDetail/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_bds.Delete(id))
                {
                    return Ok("Eliminado con éxito");
                }
                else
                    return NotFound("No se pudo eliminar");

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }
    }
}
