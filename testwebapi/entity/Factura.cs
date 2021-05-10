using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System;

namespace entity
{
    public class Factura : Entity<int>
    {
        public Factura()
        {
            Detalles = new List<Detalle>();
            Interesado = new Interesado();
        }

        public string Tipo { get; set; }
        [Column(TypeName="decimal(18,2)")]
        public decimal Descuento { get; set; }
        [Column(TypeName="decimal(18,2)")]
        public decimal Total { get; set; }
        [NotMapped]
        public Interesado Interesado { get; set; }
        [ForeignKey("IdInteresado")]
        public int IdInteresado { get; set; }
        public List<Detalle> Detalles { get; set; }

        public void AgregarDetalle(Producto producto)
        {
            Detalle detalle = new Detalle();
            detalle.Producto = producto;
            detalle.Cantidad = producto.Cantidad;
            detalle.CalcularTotal();
            Detalles.Add(detalle);
            calcularTotal();
        }

        public void calcularTotal()
        {
            Descuento = Detalles.Sum(d => d.Descuento);
            Total = Detalles.Sum( d => d.Total) - Descuento;
        }
    }
}
