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
                Descuento = producto.Descuento;
                Iva = producto.Iva;
                NitProveedor = producto.NitProveedor;
            }
        }
        public class ProductoInputModel : Producto { }
    }
}