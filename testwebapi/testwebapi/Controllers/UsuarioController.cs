using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entity;
using dal;
using bll;
using static Models.UsuarioModel;

namespace testwebapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService usuarioService;
        public UsuarioController(TestWebContext context)
        {
            usuarioService = new UsuarioService(context);
        }

        [HttpPost]
        public ActionResult<UsuarioViewModel> Post(UsuarioInputModel usuarioInputModel)
        {
            Usuario usuario = MapToUsuario(usuarioInputModel);
            var response = usuarioService.Guardar(usuario);
            if (response.Error)
            {
                ModelState.AddModelError("Error al registrar el Usuario", response.Mensaje);
                var detallesProblema = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return BadRequest(detallesProblema);
            }
            return Ok(new UsuarioViewModel(response.Usuario));
        }

        private Usuario MapToUsuario(UsuarioInputModel usuarioInputModel)
        {
            Usuario usuario = new Usuario
            {
                Id = usuarioInputModel.Id,
                Nombre = usuarioInputModel.Nombre,
                Correo = usuarioInputModel.Correo,
                Contrasena = usuarioInputModel.Contrasena,
                Celular = usuarioInputModel.Celular,
                Rol = usuarioInputModel.Rol,
            };
            return usuario;
        }

        [HttpGet]
        public IEnumerable<UsuarioViewModel> Gets()
        {
            var response = usuarioService.Consultar().ConvertAll(i => new UsuarioViewModel(i));
            return response;
        }

        [HttpPut("{id}")]
        public ActionResult<string> Put(Usuario usuario, string id)
        {
            Usuario usuarioConsulta = usuarioService.ConsultarId(id);
            if (usuarioConsulta == null)
            {
                return BadRequest("No se encontro el Usuario.");
            }
            else
            {
                var mensaje = usuarioService.Editar(usuario).Mensaje;
                return Ok(mensaje);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(string id)
        {
            Usuario usuario = usuarioService.ConsultarId(id);
            if (usuario == null)
            {
                return BadRequest("Usuario no encontrado");
            }
            else
            {
                var mensaje = usuarioService.Eliminar(usuario).Mensaje;
                return Ok(mensaje);
            }
        }
    }
}
