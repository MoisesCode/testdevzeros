using System.ComponentModel.DataAnnotations;
using System;

namespace entity
{
    public class Usuario
    {
        [Key]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Celular { get; set; }
        public string Rol { get; set; }
    }
}
