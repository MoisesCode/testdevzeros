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
        public decimal Cantidad { get; set; }
        public string Descripcion { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public string NitProveedor { get; set; }
        public decimal Precio { get; set; }

        private void AsignarIva()
        {
            Iva = 0.19m;
        }
    }
}
