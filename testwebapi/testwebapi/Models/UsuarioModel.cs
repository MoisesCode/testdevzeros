using entity;

namespace Models
{
    public class UsuarioModel {
        public class UsuarioViewModel : UsuarioInputModel
        {
            public UsuarioViewModel(Usuario usuario)
            {
                Id = usuario.Id;
                Nombre = usuario.Nombre;
                Correo = usuario.Correo;
                Contrasena = usuario.Contrasena;
                Celular = usuario.Celular;
                Rol = usuario.Rol;
            }
        }
        public class UsuarioInputModel : Usuario { }
    }
}
