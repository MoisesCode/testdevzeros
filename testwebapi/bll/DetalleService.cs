﻿using System.Collections.Generic;
using System.Linq;
using System;
using entity;
using dal;

namespace bll
{
    public class DetalleService
    {
        private TestWebContext testWebContext;
        private ProductoService productoService;

        public DetalleService(TestWebContext testWebContext)
        {
            this.testWebContext = testWebContext;
        }

        public GuardarDetalleResponse Guardar(Detalle detalle)
        {
            try
            {
                Detalle detalleBuscado = testWebContext.Detalles.Find(detalle.Id);
                if (detalleBuscado != null)
                {
                    return new GuardarDetalleResponse("Detalle ya registrada.");
                }
                detalle.CalcularTotal();
                testWebContext.Detalles.Add(detalle);
                testWebContext.SaveChanges();
                GuardarProducto(detalle.Producto);
                return new GuardarDetalleResponse(detalle, "Detalle guardada correctamente");
            }
            catch (Exception e)
            {
                return new GuardarDetalleResponse($"Ocurrió un error {e.Message}");
            }
        }
        private void GuardarProducto(Producto producto)
        {
            productoService = new ProductoService(testWebContext);
            productoService.Guardar(producto);
        }

        public class GuardarDetalleResponse
        {
            public Detalle Detalle { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }
            public GuardarDetalleResponse(Detalle detalle, string mensaje)
            {
                Mensaje = mensaje;
                Detalle = detalle;
                Error = false;
            }
            public GuardarDetalleResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
    }
}
