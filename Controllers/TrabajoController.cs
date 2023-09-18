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


        [HttpDelete]
        [Route("Eliminar")]
        public IActionResult EliminarTrabajo(int id)
        {
            return Ok($"Se elimino el elemento {id} correctamente");
        }
    }
}
