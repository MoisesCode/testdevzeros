using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace entity
{
    public class Producto
    {
        public Producto()
        {
            AsignarIva();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Nombre { get; set; }
        [Column(TypeName="decimal(18,2)")]
        public decimal Cantidad { get; set; }
        public string Descripcion { get; set; }
        [Column(TypeName="decimal(18,2)")]
        public decimal Descuento { get; set; }
        [Column(TypeName="decimal(18,2)")]
        public decimal Iva { get; set; }
        public string NitProveedor { get; set; }
        [Column(TypeName="decimal(18,2)")]
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }

        private void AsignarIva()
        {
            Iva = 0.19m;
        }
        public void calcularPrecio()
        {
            Precio = Precio + (Precio * Iva);
        }
    }
}
