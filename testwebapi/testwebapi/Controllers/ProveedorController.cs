using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entity;
using dal;
using bll;
using static Models.ProveedorModel;

namespace testwebapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProveedorController : ControllerBase
    {
        private readonly ProveedorService proveedorService;
        public ProveedorController(TestWebContext context)
        {
            proveedorService = new ProveedorService(context);
        }

        [HttpPost]
        public ActionResult<ProveedorViewModel> Post(ProveedorInputModel proveedorInputModel)
        {
            Proveedor proveedor = MapToProveedor(proveedorInputModel);
            var response = proveedorService.Guardar(proveedor);
            if (response.Error)
            {
                ModelState.AddModelError("Error al registrar el Proveedor", response.Mensaje);
                var detallesProblema = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return BadRequest(detallesProblema);
            }
            return Ok(response.Proveedor);
        }
        private Proveedor MapToProveedor(ProveedorInputModel proveedorInputModel)
        {
            Proveedor proveedor = new Proveedor
            {
                Id = proveedorInputModel.Id,
                Nit = proveedorInputModel.Nit,
                Nombre = proveedorInputModel.Nombre,
                Celular = proveedorInputModel.Celular,
                Productos = proveedorInputModel.Productos,
            };
            return proveedor;
        }

        [HttpGet]
        public IEnumerable<ProveedorViewModel> Gets()
        {
            var response = proveedorService.Consultar().ConvertAll(i => new ProveedorViewModel(i));
            return response;
        }

        [HttpPut("{id}")]
        public ActionResult<string> Put(Proveedor proveedor, string id)
        {
            Proveedor proveedorConsulta = proveedorService.ConsultarId(id);
            if (proveedorConsulta == null)
            {
                return BadRequest("No se encontro el Proveedor.");
            }
            else
            {
                var mensaje = proveedorService.Editar(proveedor).Mensaje;
                return Ok(mensaje);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(string id)
        {
            Proveedor proveedor = proveedorService.ConsultarId(id);
            if (proveedor == null)
            {
                return BadRequest("Proveedor no encontrado");
            }
            else
            {
                var mensaje = proveedorService.Eliminar(proveedor).Mensaje;
                return Ok(mensaje);
            }
        }
    }
}