using System.ComponentModel.DataAnnotations;
using System;

namespace entity
{
    public class Detalle
    {
        [Key]
        public string Id { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Total { get; set; }
        public Producto Producto { get; set; }
    }
}
