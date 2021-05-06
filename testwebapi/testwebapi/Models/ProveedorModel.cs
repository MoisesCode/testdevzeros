using entity;

namespace Models
{
    public class ProveedorModel {
        public class ProveedorViewModel : ProveedorInputModel
        {
            public ProveedorViewModel(Proveedor proveedor)
            {
                Nit = proveedor.Nit;
                Nombre = proveedor.Nombre;
                Celular = proveedor.Celular;
                Productos = proveedor.Productos;
            }
        }
        public class ProveedorInputModel : Proveedor { }
    }
}
