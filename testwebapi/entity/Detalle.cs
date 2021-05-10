using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace entity
{
    public class Detalle : Entity<int>
    {
        [ForeignKey("FacturaId")]
        public int FacturaId { get; set; }
        [Column(TypeName="decimal(18,2)")]
        public decimal Cantidad { get; set; }
        [Column(TypeName="decimal(18,2)")]
        public decimal Total { get; set; }
        [Column(TypeName="decimal(18,2)")]
        public decimal Descuento { get; set; }
        [Column(TypeName="decimal(18,2)")]
        public decimal PrecioProducto { get; set; }
        [ForeignKey("IdProducto")]
        public int IdProducto { get; set; }
        [NotMapped]
        public Producto Producto { get; set; }

        public void CalcularTotal()
        {
            Total = Cantidad * (Producto.Precio * Producto.Iva) + Producto.Precio;
        }
    }
}
