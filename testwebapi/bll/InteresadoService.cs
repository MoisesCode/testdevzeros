using System.Collections.Generic;
using System;
using dal;
using entity;
using System.Linq;

namespace bll
{
    public class InteresadoService
    {
        private TestWebContext testWebContext;
        private UsuarioService usuarioService;
        private Usuario usuario;
        public InteresadoService(TestWebContext testWebContext)
        {
            this.testWebContext = testWebContext;
        }

        public GuardarInteresadoResponse Guardar(Interesado interesado)
        {
            try
            {
                Interesado interesadoBuscado = testWebContext.Interesados.Find(interesado.Id);
                if (interesadoBuscado != null)
                {
                    return new GuardarInteresadoResponse("Interesado ya registrado.");
                }
                testWebContext.Interesados.Add(interesado);
                testWebContext.SaveChanges();
                crearUsuario(interesado);
                return new GuardarInteresadoResponse(interesado, "Interesado guardado correctamente");
            }
            catch (Exception e)
            {
                return new GuardarInteresadoResponse($"Ocurrió un error {e.Message}");
            }
        }
        public void crearUsuario(Interesado interesado)
        {
            usuarioService = new UsuarioService(testWebContext);
            usuario = new Usuario();

            usuario.Id = interesado.Id;
            usuario.Nombre = interesado.Nombre;
            usuario.Correo = interesado.Correo;
            usuario.Contrasena =interesado.Contrasena;
            usuario.Celular = interesado.Celular;
            usuario.Rol = "interesado";

            Interesado interesadoBuscado = ConsultarId(interesado.Id).Interesado;
            usuarioService.Guardar(usuario);
        }
        public List<Interesado> Consultar()
        {
            return testWebContext.Interesados.ToList();
        }
        public ConsultarInteresadoResponse ConsultarId(string id)
        {
            try
            {
                Interesado interesadoBuscado = testWebContext.Interesados.Find(id);
                if (interesadoBuscado != null)
                {
                    return new ConsultarInteresadoResponse(interesadoBuscado, "Interesado encontrado");
                }
                return new ConsultarInteresadoResponse("Interesado no encontrado");
            }
            catch (Exception e)
            {
                return new ConsultarInteresadoResponse($"Ocurrió un error {e.Message}");
            }
        }
        public EliminarInteresadoResponse Eliminar(Interesado interesado)
        {
            testWebContext.Interesados.Remove(interesado);
            testWebContext.SaveChanges();
            return new EliminarInteresadoResponse(interesado, "Interesado eliminado correctamente.");
        }
        public EditarInteresadoResponse Editar(Interesado interesadoOld, Interesado interesado)
        {
            testWebContext.Interesados.Remove(interesadoOld);
            testWebContext.Interesados.Add(interesado);
            testWebContext.SaveChanges();
            return new EditarInteresadoResponse(interesado, "Interesado modificado correctamente.");
        }

        public class GuardarInteresadoResponse
        {
            public Interesado Interesado { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }
            public GuardarInteresadoResponse(Interesado interesado, string mensaje)
            {
                Mensaje = mensaje;
                Interesado = interesado;
                Error = false;
            }
            public GuardarInteresadoResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
        public class EliminarInteresadoResponse
        {
            public Interesado Interesado { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }
            public EliminarInteresadoResponse(Interesado interesado, string mensaje)
            {
                Mensaje = mensaje;
                Interesado = interesado;
                Error = false;
            }
            public EliminarInteresadoResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }

        public class EditarInteresadoResponse
        {
            public Interesado Interesado { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }
            public EditarInteresadoResponse(Interesado interesado, string mensaje)
            {
                Mensaje = mensaje;
                Interesado = interesado;
                Error = false;
            }
            public EditarInteresadoResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }

        public class ConsultarInteresadoResponse
        {
            public Interesado Interesado { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }
            public ConsultarInteresadoResponse(Interesado interesado, string mensaje)
            {
                Mensaje = mensaje;
                Interesado = interesado;
                Error = false;
            }
            public ConsultarInteresadoResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
    }
}