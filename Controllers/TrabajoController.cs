using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DTOs;
using Microsoft.AspNetCore.Authorization;
using TrabajoIntegradorSofttek.Services;
using TrabajoIntegradorSofttek.Helpers;
using TrabajoIntegradorSofttek.Infraestructure;

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
        public async Task<IActionResult> GetAll()
        {
            var trabajos = await _unitOfWork.TrabajoRepository.GetAll();
            int pageToShow = 1;

            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateTrabajos = PaginateHelper.Paginate(trabajos, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateTrabajos);
        }

        [HttpGet("TrabajoById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var trabajo = await _unitOfWork.TrabajoRepository.GetById(id);
            if (trabajo == null)
            {
                return NotFound();
            }
            await _unitOfWork.Complete();
            return Ok(trabajo);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(AgregarTrabajoDto dto)
        {
            var trabajo = new Trabajo(dto);
            await _unitOfWork.TrabajoRepository.Insert(trabajo);
            await _unitOfWork.Complete();
            return Ok(true);
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, AgregarTrabajoDto dto)
        {
            var result = await _unitOfWork.TrabajoRepository.Update(new Trabajo(dto, id));
            await _unitOfWork.Complete();
            return Ok(true);

        }

        [Authorize(Policy = "Admin")]
        [HttpPut("DeleteLogico/{id}")]
        public async Task<IActionResult> DeleteLogico([FromRoute] int id)
        {
            var result = await _unitOfWork.TrabajoRepository.DeleteLogico(id);
            await _unitOfWork.Complete();
            return Ok(true);

        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("DeleteFisico/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.TrabajoRepository.Delete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }
    }
}
