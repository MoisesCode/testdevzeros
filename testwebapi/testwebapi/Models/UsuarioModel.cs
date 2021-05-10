using entity;

namespace Models
{
    public class UsuarioModel {
        public class UsuarioViewModel : UsuarioInputModel
        {
            public UsuarioViewModel(Usuario usuario)
            {
                Nombre = usuario.Nombre;
                Correo = usuario.Correo;
                Celular = usuario.Celular;
                Rol = usuario.Rol;
            }
        }
        public class UsuarioInputModel : Usuario { }
    }
}
