using System;
using entity;

namespace Models
{
    public class ProductoModel {
        public class ProductoViewModel : ProductoInputModel
        {
            public int Id { get; set; }
            public ProductoViewModel(Producto producto)
            {
                Id = producto.Id;
                Nombre = producto.Nombre;
                Descripcion = producto.Descripcion;
                Precio = producto.Precio;
                Fecha = producto.Fecha;
                Descuento = producto.Descuento;
                Cantidad = producto.Cantidad;
                Iva = producto.Iva;
                NitProveedor = producto.NitProveedor;
            }
        }
        public class ProductoInputModel
        {
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public decimal Cantidad { get; set; }
            public decimal Descuento { get; set; }
            public decimal Iva { get; set; }
            public string NitProveedor { get; set; }
            public decimal Precio { get; set; }
            public DateTime Fecha { get; set; }
        }
    }
}