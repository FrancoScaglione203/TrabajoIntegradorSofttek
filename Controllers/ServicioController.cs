using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DTOs;
using TrabajoIntegradorSofttek.Services;
using Microsoft.AspNetCore.Authorization;
using TrabajoIntegradorSofttek.Helpers;
using TrabajoIntegradorSofttek.Infraestructure;

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
        public async Task<IActionResult> GetAll()
        {
            var servicios = await _unitOfWork.ServicioRepository.GetAll();
            int pageToShow = 1;

            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateServicios = PaginateHelper.Paginate(servicios, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateServicios);
        }


        [HttpGet]
        [Route("ServiciosActivos")]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetActivos()
        {
            var servicios = await _unitOfWork.ServicioRepository.GetActivos();

            return Ok(servicios);
        }

        [HttpGet("ServicioById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var servicio = await _unitOfWork.ServicioRepository.GetById(id);
            if (servicio == null)
            {
                return NotFound();
            }
            await _unitOfWork.Complete();
            return Ok(servicio);
        }


        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(AgregarServicioDto dto)
        {
            var servicio = new Servicio(dto);
            await _unitOfWork.ServicioRepository.Insert(servicio);
            await _unitOfWork.Complete();
            return Ok(true);
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, AgregarServicioDto dto)
        {
            var result = await _unitOfWork.ServicioRepository.Update(new Servicio(dto, id));
            await _unitOfWork.Complete();
            return Ok(true);

        }

        [Authorize(Policy = "Admin")]
        [HttpPut("DeleteLogico/{id}")]
        public async Task<IActionResult> DeleteLogico([FromRoute] int id)
        {
            var result = await _unitOfWork.ServicioRepository.DeleteLogico(id);
            await _unitOfWork.Complete();
            return Ok(true);

        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("DeleteFisico/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.ServicioRepository.Delete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }
    }
}