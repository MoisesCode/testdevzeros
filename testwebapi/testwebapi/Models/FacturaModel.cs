using entity;

namespace Models
{
    public class FacturaModel {
        public class FacturaViewModel : FacturaInputModel
        {
            public FacturaViewModel(Factura factura)
            {
                Id = factura.Id;
                Tipo = factura.Tipo;
                IdInteresado = factura.IdInteresado;
                Total = factura.Total;
                Descuento = factura.Descuento;
                Interesado = factura.Interesado;
                Detalles = factura.Detalles;
            }
        }
        public class FacturaInputModel : Factura { }
    }
}
