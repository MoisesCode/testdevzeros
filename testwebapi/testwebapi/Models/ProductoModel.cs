using entity;

namespace Models
{
    public class ProductoModel {
        public class ProductoViewModel : ProductoInputModel
        {
            public ProductoViewModel(Producto producto)
            {
                Id = producto.Id;
                Nombre = producto.Nombre;
                Descripcion = producto.Descripcion;
                Precio = producto.Precio;
                Descuento = producto.Descuento;
                Cantidad = producto.Cantidad;
                Iva = producto.Iva;
                DetalleId = producto.DetalleId;
                NitProveedor = producto.NitProveedor;
            }
        }
        public class ProductoInputModel : Producto { }
    }
}