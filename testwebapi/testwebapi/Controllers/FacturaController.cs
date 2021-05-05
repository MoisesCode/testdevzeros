using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entity;
using dal;
using bll;
using static Models.FacturaModel;

namespace testwebapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaService facturaService;
        public FacturaController(TestWebContext context)
        {
            facturaService = new FacturaService(context);
        }

        [HttpPost]
        public ActionResult<FacturaViewModel> Post(FacturaInputModel facturaInputModel)
        {
            Factura Factura = MapToFactura(facturaInputModel);
            var response = facturaService.Guardar(Factura);
            if (response.Error)
            {
                ModelState.AddModelError("Error al registrar el Factura", response.Mensaje);
                var detallesProblema = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return BadRequest(detallesProblema);
            }
            return Ok(response.Factura);
        }
        private Factura MapToFactura(FacturaInputModel facturaInputModel)
        {
            Factura factura = new Factura
            {
                Id = facturaInputModel.Id,
                Descuento = facturaInputModel.Descuento,
                Total = facturaInputModel.Total,
                Interesado = facturaInputModel.Interesado,
                Detalles = facturaInputModel.Detalles
            };
            return factura;
        }

        [HttpGet]
        public IEnumerable<FacturaViewModel> Gets()
        {
            var response = facturaService.Consultar().ConvertAll(i => new FacturaViewModel(i));
            return response;
        }

        [HttpPut("{id}")]
        public ActionResult<string> Put(Factura factura, string id)
        {
            Factura FacturaConsulta = facturaService.ConsultarId(id);
            if (FacturaConsulta == null)
            {
                return BadRequest("No se encontro el Factura.");
            }
            else
            {
                var mensaje = facturaService.Editar(factura).Mensaje;
                return Ok(mensaje);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(string id)
        {
            Factura Factura = facturaService.ConsultarId(id);
            if (Factura == null)
            {
                return BadRequest("Factura no encontrado");
            }
            else
            {
                var mensaje = facturaService.Eliminar(Factura).Mensaje;
                return Ok(mensaje);
            }
        }
    }
}
