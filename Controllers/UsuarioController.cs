using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DTOs;
using TrabajoIntegradorSofttek.Services;
using Microsoft.AspNetCore.Authorization;
using TrabajoIntegradorSofttek.Infraestructure;
using TrabajoIntegradorSofttek.Helpers;

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

        
        [HttpGet] 
        [Route("Usuarios")]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();
            int pageToShow = 1;

            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateUsuarios = PaginateHelper.Paginate(usuarios, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateUsuarios);
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

        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(AgregarUsuarioDto dto)
        {
            if (await _unitOfWork.UsuarioRepository.UsuarioEx(dto.Cuil)) return ResponseFactory.CreateErrorResponse(409, $"Ya existe un usuario registrado con el cuil:{dto.Cuil}");
            var usuario = new Usuario(dto);
            await _unitOfWork.UsuarioRepository.Insert(usuario);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Usuario registrado con exito!");
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, AgregarUsuarioDto dto)
        {
            var result = await _unitOfWork.UsuarioRepository.Update(new Usuario(dto, id));
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }

        }

        [Authorize(Policy = "Admin")]
        [HttpPut("DeleteLogico/{id}")]
        public async Task<IActionResult> DeleteLogico([FromRoute] int id)
        {
            var result = await _unitOfWork.UsuarioRepository.DeleteLogico(id);
            await _unitOfWork.Complete();
            return Ok(true);

        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("DeleteFisico/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.UsuarioRepository.Delete(id);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }
        }

    }
}