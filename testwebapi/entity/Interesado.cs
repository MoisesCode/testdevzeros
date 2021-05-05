using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace entity
{
    public class Interesado
    {
        [Key]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Celular { get; set; }
        public List<Factura> Facturas { get; set; }
    }
}
