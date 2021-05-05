using entity;

namespace Models
{
    public class FacturaModel {
        public class FacturaViewModel : FacturaInputModel
        {
            public FacturaViewModel(Factura factura)
            {
                Id = factura.Id;
                Descuento = factura.Descuento;
                Total = factura.Total;
                Interesado = factura.Interesado;
                Detalles = factura.Detalles;
            }
        }
        public class FacturaInputModel : Factura { }
    }
}
