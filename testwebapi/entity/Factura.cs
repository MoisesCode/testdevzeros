using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System;

namespace entity
{
    public class Factura
    {
        public Factura()
        {
            Detalles = new List<Detalle>();
            Interesado = new Interesado();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public Interesado Interesado { get; set; }
        public List<Detalle> Detalles { get; set; }

        public List<Detalle> AgregarDetalle(decimal cantidad, Producto producto)
        {
            Detalle detalle = new Detalle();
            detalle.Producto = producto;
            detalle.Cantidad = cantidad;
            detalle.CalcularTotal();
            CalcularTotal();
            return Detalles;
        }

        public void CalcularTotal()
        {
            Total = Detalles.Sum(d => d.Total);
        }
    }
}
