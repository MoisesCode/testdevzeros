using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entity;
using dal;
using bll;
using static Models.ProductoModel;

namespace testwebapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService productoService;
        public ProductoController(TestWebContext context)
        {
            productoService = new ProductoService(context);
        }

        [HttpPost]
        public ActionResult<ProductoViewModel> Post(ProductoInputModel productoInputModel)
        {
            Producto producto = MapToProducto(productoInputModel);
            var response = productoService.Guardar(producto);
            if (response.Error)
            {
                ModelState.AddModelError("Error al registrar el Producto", response.Mensaje);
                var detallesProblema = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return BadRequest(detallesProblema);
            }
            return Ok(response.Producto);
        }
        private Producto MapToProducto(ProductoInputModel productoInputModel)
        {
            Producto producto = new Producto
            {
                Id = productoInputModel.Id,
                Nombre = productoInputModel.Nombre,
                Precio = productoInputModel.Precio,
                Descripcion = productoInputModel.Descripcion,
                Descuento = productoInputModel.Descuento,
                Cantidad = productoInputModel.Cantidad,
                Iva = productoInputModel.Iva,
                NitProveedor = productoInputModel.NitProveedor,
            };
            return producto;
        }

        [HttpGet]
        public IEnumerable<ProductoViewModel> Gets()
        {
            var response = productoService.Consultar().ConvertAll(i => new ProductoViewModel(i));
            return response;
        }

        [HttpPut("{id}")]
        public ActionResult<string> Put(Producto producto, string id)
        {
            Producto productoConsulta = productoService.ConsultarId(id);
            if (productoConsulta == null)
            {
                return BadRequest("No se encontro el Producto.");
            }
            else
            {
                var mensaje = productoService.Editar(producto).Mensaje;
                return Ok(mensaje);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(string id)
        {
            Producto Producto = productoService.ConsultarId(id);
            if (Producto == null)
            {
                return BadRequest("Producto no encontrado");
            }
            else
            {
                var mensaje = productoService.Eliminar(Producto).Mensaje;
                return Ok(mensaje);
            }
        }
    }
}
