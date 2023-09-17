using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DTOs;
using Microsoft.AspNetCore.Authorization;
using TrabajoIntegradorSofttek.Services;

namespace TrabajoIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TrabajoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        [Route("Trabajos")]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Trabajo>>> GetAll()
        {
            var trabajos = await _unitOfWork.TrabajoRepository.GetAll();

            return trabajos;
        }


        [HttpPost]
        [Route("Agregar")]
        public IActionResult AgregarTrabajo(TrabajoDto trabajo)
        {
            return Unauthorized("No se pudo agregar trabajo");
        }


        [HttpPut]
        [Route("Editar")]
        public IActionResult EditarTrabajo(TrabajoDto trabajo)
        {
            return Ok(trabajo);
        }


        [HttpDelete]
        [Route("Eliminar")]
        public IActionResult EliminarTrabajo(int id)
        {
            return Ok($"Se elimino el elemento {id} correctamente");
        }
    }
}
