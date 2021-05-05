using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace entity
{
    public class Interesado
    {
        public Interesado()
        {
            Facturas = new List<Factura>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public List<Factura> Facturas { get; set; }
    }
}
