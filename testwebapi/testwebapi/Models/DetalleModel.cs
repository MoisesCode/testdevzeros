using entity;

namespace Models
{
    public class DetalleModel {
        public class DetalleViewModel : DetalleInputModel
        {
            public DetalleViewModel(Detalle detalle)
            {
                Id = detalle.Id;
                FacturaId = detalle.FacturaId;
                IdProducto = detalle.IdProducto;
                PrecioProducto = detalle.PrecioProducto;
                Cantidad = detalle.Cantidad;
                Total = detalle.Total;
                Producto = detalle.Producto;
            }
        }
        public class DetalleInputModel : Detalle { }
    }
}
