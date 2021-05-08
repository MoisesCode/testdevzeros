using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entity;
using dal;
using bll;
using static Models.DetalleModel;

namespace testwebapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetalleController : ControllerBase
    {
        private readonly DetalleService detalleService;
        public DetalleController(TestWebContext context)
        {
            detalleService = new DetalleService(context);
        }

        [HttpGet("{id}")]
        public IEnumerable<DetalleViewModel> getByNit(string id)
        {
            return detalleService.ConsultarId(id).ConvertAll(d => new DetalleViewModel(d));
        }
    }
}
