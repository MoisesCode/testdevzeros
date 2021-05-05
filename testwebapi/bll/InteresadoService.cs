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

        public InteresadoService(TestWebContext testWebContext)
        {
            this.testWebContext = testWebContext;
        }

        public GuardarInteresadoResponse Guardar(Interesado interesado)
        {
            try
            {
                interesado.Id = "121";
                Interesado interesadoBuscado = testWebContext.Interesados.Find(interesado.Id);
                if (interesadoBuscado != null)
                {
                    return new GuardarInteresadoResponse("Interesado ya registrado.");
                }
                testWebContext.Interesados.Add(interesado);
                testWebContext.SaveChanges();
                return new GuardarInteresadoResponse(interesado, "Interesado guardado correctamente");
            }
            catch (Exception e)
            {
                return new GuardarInteresadoResponse($"Ocurrió un error {e.Message}");
            }
        }

        public List<Interesado> Consultar()
        {
            return testWebContext.Interesados.ToList();
        }
        public Interesado ConsultarId(string id)
        {
            return testWebContext.Interesados.Find(id);
        }
        public EliminarInteresadoResponse Eliminar(Interesado interesado)
        {
            testWebContext.Interesados.Remove(interesado);
            testWebContext.SaveChanges();
            return new EliminarInteresadoResponse(interesado, "Interesado eliminado correctamente");
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
    }
}