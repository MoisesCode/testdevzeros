using entity;

namespace Models
{
    public class ProveedorModel {
        public class ProveedorViewModel : ProveedorInputModel
        {
            public ProveedorViewModel(Proveedor proveedor)
            {
                Id = proveedor.Id;
                Nit = proveedor.Nit;
                Nombre = proveedor.Nombre;
                Celular = proveedor.Celular;
                Productos = proveedor.Productos;
            }
        }
        public class ProveedorInputModel : Proveedor { }
    }
}
