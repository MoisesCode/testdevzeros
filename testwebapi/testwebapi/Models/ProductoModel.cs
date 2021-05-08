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
                Fecha = producto.Fecha;
                Descuento = producto.Descuento;
                Cantidad = producto.Cantidad;
                Iva = producto.Iva;
                NitProveedor = producto.NitProveedor;
            }
        }
        public class ProductoInputModel : Producto { }
    }
}