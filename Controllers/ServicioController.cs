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
        public async Task<IActionResult> Agregar(AgregarServicioDto dto)
        {
            var servicio = new Servicio(dto);
            await _unitOfWork.ServicioRepository.Insert(servicio);
            await _unitOfWork.Complete();
            return Ok(true);
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