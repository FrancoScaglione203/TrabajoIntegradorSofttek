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


        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(AgregarTrabajoDto dto)
        {
            var trabajo = new Trabajo(dto);
            await _unitOfWork.TrabajoRepository.Insert(trabajo);
            await _unitOfWork.Complete();
            return Ok(true);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, AgregarTrabajoDto dto)
        {
            var result = await _unitOfWork.TrabajoRepository.Update(new Trabajo(dto, id));
            await _unitOfWork.Complete();
            return Ok(true);

        }

        [HttpPut("DeleteLogico/{id}")]
        public async Task<IActionResult> DeleteLogico([FromRoute] int id)
        {
            var result = await _unitOfWork.TrabajoRepository.DeleteLogico(id);
            await _unitOfWork.Complete();
            return Ok(true);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.TrabajoRepository.Delete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }
    }
}
