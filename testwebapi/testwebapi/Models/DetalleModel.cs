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
                Cantidad = detalle.Cantidad;
                Total = detalle.Total;
                Producto = detalle.Producto;
            }
        }
        public class DetalleInputModel : Detalle { }
    }
}
