using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace entity
{
    public class Proveedor
    {
        [Key]
        public string Id { get; set; }
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Celular { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
