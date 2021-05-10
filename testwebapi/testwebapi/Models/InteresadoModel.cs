using System.Collections.Generic;
using entity;

namespace Models
{
    public class InteresadoModel {
        public class InteresadoViewModel : InteresadoInputModel
        {
            public int Id { get; set; }
            public List<Factura> Facturas { get; set; }

            public InteresadoViewModel(Interesado interesado)
            {
                Id = interesado.Id;
                Nombre = interesado.Nombre;
                Celular = interesado.Celular;
                Correo = interesado.Correo;
                Contrasena = interesado.Contrasena;
                Facturas = interesado.Facturas;
            }
        }
        public class InteresadoInputModel
        {
            public string Nombre { get; set; }
            public string Celular { get; set; }
            public string Correo { get; set; }
            public string Contrasena { get; set; }
        }
    }
}
