using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            detalleService = new DetalleService(testWebContext);
        }

        public GuardarFacturaResponse Guardar(Factura factura)
        {
            try
            {
                Factura facturaBuscado = testWebContext.Facturas.Find(factura.Id);
                if (facturaBuscado != null)
                {
                    return new GuardarFacturaResponse("Factura ya registrada.");
                }
                ejecutarSave(factura);
                return new GuardarFacturaResponse(factura, "Factura guardada correctamente");
            }
            catch (Exception e)
            {
                return new GuardarFacturaResponse($"Ocurrió un error {e.Message}");
            }
        }

        public string generarId()
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);
            var value = random.Next(1, 200);
            return value.ToString();
        }
        public void ejecutarSave(Factura factura)
        {
            if(factura.Tipo == "Compra")
            {
                testWebContext.Facturas.Add(factura);
                testWebContext.SaveChanges();
                foreach (var item in factura.Detalles)
                {
                    testWebContext.Productos.Add(item.Producto);
                    testWebContext.SaveChanges();
                }
            }else{
                factura.IdInteresado = factura.Interesado.Id;
                testWebContext.Facturas.Add(factura);
                foreach (var item in factura.Detalles)
                {
                    item.IdProducto = item.Producto.Id;
                }
                testWebContext.SaveChanges();
            }
        }

        public List<Factura> Consultar()
        {
            List<Factura> facturas = new List<Factura>();
            foreach (var item in testWebContext.Facturas.ToList())
            {
                foreach (var detalle in testWebContext.Detalles.Where(d => d.FacturaId == item.Id).ToList())
                {
                    item.AgregarDetalle(testWebContext.Productos.Where( p => p.Id == detalle.IdProducto).FirstOrDefault());
                    facturas.Add(item);
                }
            }
            return facturas;
        }

        public Factura ConsultarByProductoId(string id)
        {
            Producto producto = testWebContext.Productos.Find(id);
            Detalle detalle = testWebContext.Detalles.Find(producto.Id);
            Factura factura = testWebContext.Facturas.Find(detalle.FacturaId);

            return factura;
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