using System.Collections.Generic;
using System.Linq;
using System;
using entity;
using dal;

namespace bll
{
    public class FacturaService
    {
        private TestWebContext testWebContext;
        private DetalleService detalleService;
        public FacturaService(TestWebContext testWebContext)
        {
            this.testWebContext = testWebContext;
        }

        public GuardarFacturaResponse Guardar(Factura factura)
        {
            try
            {
                Factura FacturaBuscado = testWebContext.Facturas.Find(factura.Id);
                if (FacturaBuscado != null)
                {
                    return new GuardarFacturaResponse("Factura ya registrada.");
                }
                testWebContext.Facturas.Add(factura);
                foreach (var item in factura.Detalles)
                {
                    detalleService.Guardar(item);
                }
                testWebContext.SaveChanges();
                return new GuardarFacturaResponse(factura, "Factura guardada correctamente");
            }
            catch (Exception e)
            {
                return new GuardarFacturaResponse($"Ocurrió un error {e.Message}");
            }
        }

        public List<Factura> Consultar()
        {
            return testWebContext.Facturas.ToList();
        }
        public Factura ConsultarId(string id)
        {
            return testWebContext.Facturas.Find(id);
        }
        public EliminarFacturaResponse Eliminar(Factura factura)
        {
            testWebContext.Facturas.Remove(factura);
            testWebContext.SaveChanges();
            return new EliminarFacturaResponse(factura, "Factura eliminada correctamente.");
        }
        public EditarFacturaResponse Editar(Factura factura)
        {
            testWebContext.Facturas.Update(factura);
            testWebContext.SaveChanges();
            return new EditarFacturaResponse(factura, "Factura modificada correctamente.");
        }




        public class GuardarFacturaResponse
        {
            public Factura Factura { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }
            public GuardarFacturaResponse(Factura factura, string mensaje)
            {
                Mensaje = mensaje;
                Factura = factura;
                Error = false;
            }
            public GuardarFacturaResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
        public class EliminarFacturaResponse
        {
            public Factura Factura { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }
            public EliminarFacturaResponse(Factura factura, string mensaje)
            {
                Mensaje = mensaje;
                Factura = factura;
                Error = false;
            }
            public EliminarFacturaResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
        public class EditarFacturaResponse
        {
            public Factura Factura { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }
            public EditarFacturaResponse(Factura factura, string mensaje)
            {
                Mensaje = mensaje;
                Factura = factura;
                Error = false;
            }
            public EditarFacturaResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
    }
}