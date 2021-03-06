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
                ModelState.AddModelError("Error al registrar al usuario interesado", response.Mensaje);
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
                Nombre = interesadoInputModel.Nombre,
                Celular = interesadoInputModel.Celular,
                Correo = interesadoInputModel.Correo,
                Contrasena = interesadoInputModel.Contrasena
            };
            return interesado;
        }

        [HttpGet("{id}")]
        public ActionResult<InteresadoViewModel> getByNit(string id)
        {
            var response = interesadoService.ConsultarId(id);
            if (response.Error)
            {
                ModelState.AddModelError("Error al consultar usuario interesado", response.Mensaje);
                var detallesProblema = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return BadRequest(detallesProblema);
            }

            InteresadoViewModel interesadoViewModel = new InteresadoViewModel(response.Interesado);
            return Ok(interesadoViewModel);
        }

        [HttpGet]
        public IEnumerable<InteresadoViewModel> Gets()
        {
            var response = interesadoService.Consultar().ConvertAll(i => new InteresadoViewModel(i));
            return response;
        }

        [HttpPut("{id}")]
        public ActionResult<InteresadoViewModel> Put(string id, Interesado interesado)
        {
            Interesado interesadoConsulta = interesadoService.ConsultarId(id).Interesado;
            if (interesadoConsulta == null)
            {
                return BadRequest("No se encontro al usuario interesado.");
            }
            Interesado response = interesadoService.Editar(interesadoConsulta, interesado).Interesado;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<InteresadoViewModel> Delete(string id)
        {
            Interesado interesado = interesadoService.ConsultarId(id).Interesado;
            if (interesado == null)
            {
                return BadRequest("Interesado no encontrado");
            }
            return Ok(interesadoService.Eliminar(interesado).Interesado);
        }
    }
}