using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace entity
{
    public class Proveedor
    {
        public Proveedor()
        {
            Productos = new List<Producto>();
        }

        [Key]
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Celular { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
