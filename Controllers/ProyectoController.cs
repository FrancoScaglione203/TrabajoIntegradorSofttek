using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DTOs;
using TrabajoIntegradorSofttek.Services;

namespace TrabajoIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public ProyectoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        [Route("Proyectos")]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetAll()
        {
            var proyectos = await _unitOfWork.ProyectoRepository.GetAll();

            return proyectos;
        }

        [HttpGet("ProyectoById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var proyecto = await _unitOfWork.ServicioRepository.GetById(id);
            if (proyecto == null)
            {
                return NotFound();
            }
            await _unitOfWork.Complete();
            return Ok(proyecto);
        }


        [HttpGet]
        [Route("ProyectosEstado/{estado}")]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetEstado([FromRoute] int estado)
        {
            var proyectos = await _unitOfWork.ProyectoRepository.GetEstado(estado);

            return Ok(proyectos);
        }


        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(AgregarProyectoDto dto)
        {
            var proyecto = new Proyecto(dto);
            await _unitOfWork.ProyectoRepository.Insert(proyecto);
            await _unitOfWork.Complete();
            return Ok(true);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, AgregarProyectoDto dto)
        {
            var result = await _unitOfWork.ProyectoRepository.Update(new Proyecto(dto, id));
            await _unitOfWork.Complete();
            return Ok(true);

        }


        [HttpPut("DeleteLogico/{id}")]
        public async Task<IActionResult> DeleteLogico([FromRoute] int id)
        {
            var result = await _unitOfWork.ProyectoRepository.DeleteLogico(id);
            await _unitOfWork.Complete();
            return Ok(true);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.ProyectoRepository.Delete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }

    }
}