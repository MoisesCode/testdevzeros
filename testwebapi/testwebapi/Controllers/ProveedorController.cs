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

        [HttpGet("{id}")]
        public ActionResult<ProveedorViewModel> getByNit(string id)
        {
            Proveedor proveedor = proveedorService.ConsultarId(id);
            if(proveedor == null) return NotFound();
            ProveedorViewModel proveedorViewModel = new ProveedorViewModel(proveedor);
            return proveedorViewModel;
        }

        [HttpPut("{id}")]
        public ActionResult<ProveedorViewModel> Put(string id, Proveedor proveedor)
        {
            Proveedor proveedorConsulta = proveedorService.ConsultarId(id);
            if (proveedorConsulta == null)
            {
                return BadRequest("No se encontro el Proveedor.");
            }
            Proveedor response = proveedorService.Editar(proveedorConsulta, proveedor).Proveedor;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<ProveedorViewModel> Delete(string id)
        {
            Proveedor proveedor = proveedorService.ConsultarId(id);
            if (proveedor == null)
            {
                return BadRequest("Proveedor no encontrado");
            }
            Proveedor response = proveedorService.Eliminar(proveedor).Proveedor;
            return Ok(response);
        }
    }
}