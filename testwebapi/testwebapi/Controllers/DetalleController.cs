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
        public ActionResult<DetalleViewModel> getByNit(string id)
        {
            Detalle detalle = detalleService.ConsultarId(id);
            if(detalle == null) return NotFound();
            DetalleViewModel detalleViewModel = new DetalleViewModel(detalle);
            return detalleViewModel;
        }
    }
}
