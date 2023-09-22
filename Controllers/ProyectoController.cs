using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DTOs;
using TrabajoIntegradorSofttek.Services;
using TrabajoIntegradorSofttek.Helpers;
using TrabajoIntegradorSofttek.Infraestructure;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> GetAll()
        {
            var proyectos = await _unitOfWork.ProyectoRepository.GetAll();
            int pageToShow = 1;

            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateProyectos = PaginateHelper.Paginate(proyectos, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateProyectos);
        }


        [HttpGet]
        [Route("ProyectosByEstado/{idEstado}")]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetEstado([FromRoute] int idEstado)
        {
            var proyectos = await _unitOfWork.ProyectoRepository.GetEstado(idEstado);

            return Ok(proyectos);
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


        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(AgregarProyectoDto dto)
        {
            var proyecto = new Proyecto(dto);
            await _unitOfWork.ProyectoRepository.Insert(proyecto);
            await _unitOfWork.Complete();
            return Ok(true);
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, AgregarProyectoDto dto)
        {
            var result = await _unitOfWork.ProyectoRepository.Update(new Proyecto(dto, id));
            await _unitOfWork.Complete();
            return Ok(true);

        }

        [Authorize(Policy = "Admin")]
        [HttpPut("DeleteLogico/{id}")]
        public async Task<IActionResult> DeleteLogico([FromRoute] int id)
        {
            var result = await _unitOfWork.ProyectoRepository.DeleteLogico(id);
            await _unitOfWork.Complete();
            return Ok(true);

        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("DeleteFisico/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.ProyectoRepository.Delete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }

    }
}