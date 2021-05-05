using System.ComponentModel.DataAnnotations;
using System;

namespace entity
{
    public class Producto
    {
        [Key]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public Proveedor Proveedor { get; set; }

    }
}
