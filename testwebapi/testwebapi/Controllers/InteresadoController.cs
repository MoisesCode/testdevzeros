using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entity;
using dal;
using bll;
using static Models.InteresadoModel;

namespace testwebapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InteresadoController : ControllerBase
    {
        private readonly InteresadoService interesadoService;
        public InteresadoController(TestWebContext context)
        {
            interesadoService = new InteresadoService(context);
        }

        [HttpPost]
        public ActionResult<InteresadoViewModel> Post(InteresadoInputModel interesadoInputModel)
        {
            Interesado interesado = MapToInteresado(interesadoInputModel);
            var response = interesadoService.Guardar(interesado);
            if (response.Error)
            {
                ModelState.AddModelError("Error al registrar la casa", response.Mensaje);
                var detallesProblema = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return BadRequest(detallesProblema);
            }
            return Ok(response.Interesado);
        }
        private Interesado MapToInteresado(InteresadoInputModel interesadoInputModel)
        {
            Interesado interesado = new Interesado
            {
                Id = interesadoInputModel.Id,
                Nombre = interesadoInputModel.Nombre,
                Celular = interesadoInputModel.Celular,
                Facturas = interesadoInputModel.Facturas,
            };
            return interesado;
        }

        [HttpGet]
        public IEnumerable<InteresadoViewModel> Gets()
        {
            var response = interesadoService.Consultar().ConvertAll(i => new InteresadoViewModel(i));
            return response;
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(string id)
        {
            Interesado interesado = interesadoService.ConsultarId(id);
            if (interesado == null)
            {
                return BadRequest("Interesado no encontrado");
            }
            else
            {
                var mensaje = interesadoService.Eliminar(interesado).Mensaje;
                return Ok(mensaje);
            }
        }
    }
}