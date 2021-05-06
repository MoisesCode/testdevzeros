using System.Collections.Generic;
using System.Linq;
using System;
using entity;
using dal;

namespace bll
{
    public class ProveedorService
    {
        private TestWebContext testWebContext;
        public ProveedorService(TestWebContext testWebContext)
        {
            this.testWebContext = testWebContext;
        }

        public GuardarProveedorResponse Guardar(Proveedor proveedor)
        {
            try
            {
                Proveedor proveedorBuscado = testWebContext.Proveedores.Find(proveedor.Nit);
                if (proveedorBuscado != null)
                {
                    return new GuardarProveedorResponse("Proveedor ya registrado.");
                }
                testWebContext.Proveedores.Add(proveedor);
                testWebContext.SaveChanges();
                return new GuardarProveedorResponse(proveedor, "Proveedor guardado correctamente");
            }
            catch (Exception e)
            {
                return new GuardarProveedorResponse($"Ocurrió un error {e.Message}");
            }
        }

        public List<Proveedor> Consultar()
        {
            return testWebContext.Proveedores.ToList();
        }

        public Proveedor ConsultarId(string id)
        {
            return testWebContext.Proveedores.Find(id);
        }

        public EliminarProveedorResponse Eliminar(Proveedor proveedor)
        {
            testWebContext.Proveedores.Remove(proveedor);
            testWebContext.SaveChanges();
            return new EliminarProveedorResponse(proveedor, "Proveedor eliminado correctamente.");
        }

        public EditarProveedorResponse Editar(Proveedor proveedor)
        {
            testWebContext.Proveedores.Update(proveedor);
            testWebContext.SaveChanges();
            return new EditarProveedorResponse(proveedor, "Proveedor modificado correctamente.");
        }

        public class GuardarProveedorResponse
        {
            public Proveedor Proveedor { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }
            public GuardarProveedorResponse(Proveedor proveedor, string mensaje)
            {
                Mensaje = mensaje;
                Proveedor = proveedor;
                Error = false;
            }
            public GuardarProveedorResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
        public class EliminarProveedorResponse
        {
            public Proveedor Proveedor { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }
            public EliminarProveedorResponse(Proveedor proveedor, string mensaje)
            {
                Mensaje = mensaje;
                Proveedor = proveedor;
                Error = false;
            }
            public EliminarProveedorResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }

        public class EditarProveedorResponse
        {
            public Proveedor Proveedor { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }
            public EditarProveedorResponse(Proveedor proveedor, string mensaje)
            {
                Mensaje = mensaje;
                Proveedor = proveedor;
                Error = false;
            }
            public EditarProveedorResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
    }
}