using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace entity
{
    public class Detalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [ForeignKey("FacturaId")]
        public string FacturaId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Total { get; set; }
        public Producto Producto { get; set; }

        public void CalcularTotal()
        {
            Total = Cantidad * (Producto.Precio * Producto.Iva) + Producto.Precio;
        }
    }
}
