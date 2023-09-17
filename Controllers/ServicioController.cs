using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DTOs;
using TrabajoIntegradorSofttek.Services;

namespace TrabajoIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public ServicioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        [Route("Servicios")]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetAll()
        {
            var servicios = await _unitOfWork.ServicioRepository.GetAll();

            return servicios;
        }


        [HttpPost]
        [Route("Agregar")]
        public IActionResult AgregarServicio(ServicioDto servicio)
        {
            return Unauthorized("No se pudo agregar servicio");
        }


        [HttpPut]
        [Route("Editar")]
        public IActionResult EditarServicio(ServicioDto servicio)
        {
            return Ok(servicio);
        }


        [HttpDelete]
        [Route("Eliminar")]
        public IActionResult EliminarServicio(int id)
        {
            return Ok($"Se elimino el elemento {id} correctamente");
        }
    }
}