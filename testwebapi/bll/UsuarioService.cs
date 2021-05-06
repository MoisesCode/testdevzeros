using System.Collections.Generic;
using System.Linq;
using System;
using entity;
using dal;

namespace bll
{
    public class UsuarioService
    {
        private TestWebContext testWebContext;
        public UsuarioService(TestWebContext testWebContext)
        {
            this.testWebContext = testWebContext;
        }

        public GuardarUsuarioResponse Guardar(Usuario usuario)
        {
            try
            {
                Usuario usuarioBuscado = testWebContext.Usuarios.Find(usuario.Id);
                if (usuarioBuscado != null)
                {
                    return new GuardarUsuarioResponse("Usuario ya registrado.");
                }
                testWebContext.Usuarios.Add(usuario);
                testWebContext.SaveChanges();
                return new GuardarUsuarioResponse(usuario, "Usuario guardado correctamente");
            }
            catch (Exception e)
            {
                return new GuardarUsuarioResponse($"Ocurrió un error {e.Message}");
            }
        }

        public List<Usuario> Consultar()
        {
            return testWebContext.Usuarios.ToList();
        }

        public Usuario ConsultarId(string id)
        {
            return testWebContext.Usuarios.Find(id);
        }

        public Usuario buscarByCorreoContrasena(string correo, string contrasena){
            try
            {
                return testWebContext.Usuarios.Where(u => u.Correo == correo && u.Contrasena == contrasena).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public EliminarUsuarioResponse Eliminar(Usuario usuario)
        {
            testWebContext.Usuarios.Remove(usuario);
            testWebContext.SaveChanges();
            return new EliminarUsuarioResponse(usuario, "Usuario eliminado correctamente.");
        }

        public EditarUsuarioResponse Editar(Usuario usuario)
        {
            testWebContext.Usuarios.Update(usuario);
            testWebContext.SaveChanges();
            return new EditarUsuarioResponse(usuario, "Usuario modificado correctamente.");
        }

        public class GuardarUsuarioResponse
        {
            public Usuario Usuario { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }
            public GuardarUsuarioResponse(Usuario usuario, string mensaje)
            {
                Mensaje = mensaje;
                Usuario = usuario;
                Error = false;
            }
            public GuardarUsuarioResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
        public class EliminarUsuarioResponse
        {
            public Usuario Usuario { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }
            public EliminarUsuarioResponse(Usuario usuario, string mensaje)
            {
                Mensaje = mensaje;
                Usuario = usuario;
                Error = false;
            }
            public EliminarUsuarioResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }

        public class EditarUsuarioResponse
        {
            public Usuario Usuario { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }
            public EditarUsuarioResponse(Usuario usuario, string mensaje)
            {
                Mensaje = mensaje;
                Usuario = usuario;
                Error = false;
            }
            public EditarUsuarioResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
    }
}