using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace entity
{
    public class Usuario : Entity<int>
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Celular { get; set; }
        public string Rol { get; set; }
    }
}
