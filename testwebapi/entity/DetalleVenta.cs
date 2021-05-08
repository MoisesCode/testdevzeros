using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace entity
{
    public class DetalleVenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [ForeignKey("FacturaId")]
        public string FacturaId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Total { get; set; }
        public decimal Descuento { get; set; }
        [ForeignKey("IdProducto")]
        public string IdProducto { get; set; }
        [NotMapped]
        public Producto Producto { get; set; }

        public void CalcularTotal()
        {
            Total = Cantidad * (Producto.Precio * Producto.Iva) + Producto.Precio;
        }
    }
}
