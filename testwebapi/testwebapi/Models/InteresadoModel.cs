using entity;

namespace Models
{
    public class InteresadoModel {
        public class InteresadoViewModel : InteresadoInputModel
        {
            public InteresadoViewModel(Interesado interesado)
            {
                Id = interesado.Id;
                Nombre = interesado.Nombre;
                Celular = interesado.Celular;
                Facturas = interesado.Facturas;
            }
        }
        public class InteresadoInputModel : Interesado { }
    }
}
