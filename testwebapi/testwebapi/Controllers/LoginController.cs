using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using entity;
using dal;
using bll;
using static Models.UsuarioModel;

namespace testwebapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UsuarioService usuarioService;
        public LoginController(TestWebContext context)
        {
            usuarioService = new UsuarioService(context);
        }

        [HttpPost()]
        public ActionResult<UsuarioViewModel> getUser(UsuarioInputModel usuarioInputModel)
        {
            Usuario response = usuarioService.buscarByCorreoContrasena(usuarioInputModel.Correo,usuarioInputModel.Contrasena);
            if (response == null)
            {
                ModelState.AddModelError("Acceso denegado", "Usuario y/o contraseña incorrectos");
                var detallesProblema = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return BadRequest(detallesProblema);
            }
            return Ok(response);
        }
    }
}