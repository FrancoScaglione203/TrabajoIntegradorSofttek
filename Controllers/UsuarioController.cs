using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DTOs;
using TrabajoIntegradorSofttek.Services;
using Microsoft.AspNetCore.Authorization;

namespace TrabajoIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Policy = "Admin")]
        [HttpGet] 
        [Route("Usuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();
            return usuarios;
        }

        [HttpGet("UsuarioById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            await _unitOfWork.Complete();
            return Ok(usuario);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(AgregarUsuarioDto dto)
        {
            var usuario = new Usuario(dto);
            await _unitOfWork.UsuarioRepository.Insert(usuario);
            await _unitOfWork.Complete();
            return Ok(true);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, AgregarUsuarioDto dto)
        {
            var result = await _unitOfWork.UsuarioRepository.Update(new Usuario(dto, id));
            await _unitOfWork.Complete();
            return Ok(true);
            
        }


        [HttpPut("DeleteLogico/{id}")]
        public async Task<IActionResult> DeleteLogico([FromRoute] int id)
        {
            var result = await _unitOfWork.UsuarioRepository.DeleteLogico(id);
            await _unitOfWork.Complete();
            return Ok(true);

        }


        [HttpDelete("DeleteFisico/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.UsuarioRepository.Delete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }

    }
}