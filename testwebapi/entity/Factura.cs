using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace entity
{
    public class Factura
    {
        [Key]
        public string Id { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public decimal TotalProductos { get; set; }
        public Interesado Interesado { get; set; }
        public List<Detalle> Detalles { get; set; }
    }
}
