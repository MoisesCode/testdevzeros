using System.Collections.Generic;
using System.Linq;
using System;
using entity;
using dal;

namespace bll
{
    public class ProductoService
    {
        private TestWebContext testWebContext;
        public ProductoService(TestWebContext testWebContext)
        {
            this.testWebContext = testWebContext;
        }

        public GuardarProductoResponse Guardar(Producto producto)
        {
            try
            {
                Producto productoBuscado = testWebContext.Productos.Find(producto.Id);
                if (productoBuscado != null)
                {
                    return new GuardarProductoResponse("Producto ya registrado.");
                }
                testWebContext.Productos.Add(producto);
                testWebContext.SaveChanges();
                return new GuardarProductoResponse(producto, "Producto guardado correctamente");
            }
            catch (Exception e)
            {
                return new GuardarProductoResponse($"Ocurrió un error {e.Message}");
            }
        }

        public List<Producto> Consultar()
        {
            return testWebContext.Productos.ToList();
        }

        public Producto ConsultarId(string id)
        {
            return testWebContext.Productos.Find(id);
        }

        public EliminarProductoResponse Eliminar(Producto producto)
        {
            testWebContext.Productos.Remove(producto);
            testWebContext.SaveChanges();
            return new EliminarProductoResponse(producto, "Producto eliminado correctamente.");
        }

        public EditarProductoResponse Editar(Producto producto)
        {
            testWebContext.Productos.Update(producto);
            testWebContext.SaveChanges();
            return new EditarProductoResponse(producto, "Producto modificado correctamente.");
        }

        public class GuardarProductoResponse
        {
            public Producto Producto { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }
            public GuardarProductoResponse(Producto producto, string mensaje)
            {
                Mensaje = mensaje;
                Producto = producto;
                Error = false;
            }
            public GuardarProductoResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
        public class EliminarProductoResponse
        {
            public Producto Producto { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }
            public EliminarProductoResponse(Producto producto, string mensaje)
            {
                Mensaje = mensaje;
                Producto = producto;
                Error = false;
            }
            public EliminarProductoResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }

        public class EditarProductoResponse
        {
            public Producto Producto { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }
            public EditarProductoResponse(Producto producto, string mensaje)
            {
                Mensaje = mensaje;
                Producto = producto;
                Error = false;
            }
            public EditarProductoResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
    }
}
