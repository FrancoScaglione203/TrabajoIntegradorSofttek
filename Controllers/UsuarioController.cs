﻿using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Devuelve todos los usuarios
        /// </summary>
        /// <returns>Retorna lista de clase Usuario</returns>
        [Authorize(Policy = "AdminConsultor")]
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

        /// <summary>
        /// Devulve usuario solicitado por parametro id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna 200 si se obtuvo usuario por id o 500 si no existe usuario con ese id</returns>
        [Authorize(Policy = "AdminConsultor")]
        [HttpGet("UsuarioById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetById(id);
            if (usuario == null)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se encontro ningun usuario con ese id ");
            }
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, usuario);
        }

        /// <summary>
        /// Agrega un usuario a la base de datos
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Retorna 201 si agrego con exito o 409 si hubo un error</returns>
        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(UsuarioDto dto)
        {
            if (await _unitOfWork.UsuarioRepository.UsuarioEx(dto.Cuil)) return ResponseFactory.CreateErrorResponse(409, $"Ya existe un usuario registrado con el cuil:{dto.Cuil}");
            var usuario = new Usuario(dto);
            await _unitOfWork.UsuarioRepository.Insert(usuario);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Usuario registrado con exito!");
        }

        /// <summary>
        /// Actualiza el servicio seleccionado por id por el UsuarioDto que se envia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns>Retorna 200 si se actualizo con exito o 500 si ingresaron id invalido</returns>
        [Authorize(Policy = "Admin")]
        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, UsuarioDto dto)
        {
            var result = await _unitOfWork.UsuarioRepository.Update(new Usuario(dto, id));
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo actualizar el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }

        }

        /// <summary>
        /// Cambia a true el estado de la propiedad Activo del usuario seleccionado por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna 200 si se modifico con exito o 500 si hubo un error</returns>
        [Authorize(Policy = "Admin")]
        [HttpPut("AltaLogico/{id}")]
        public async Task<IActionResult> AltaLogico([FromRoute] int id)
        {
            var result = await _unitOfWork.UsuarioRepository.AltaLogico(id);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo activar el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Activado");
            }

        }

        /// <summary>
        /// Cambia a false el estado de la propiedad Activo del usuario seleccionado por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna 200 si se modifico con exito o 500 si hubo un error</returns>
        [Authorize(Policy = "Admin")]
        [HttpPut("DeleteLogico/{id}")]
        public async Task<IActionResult> DeleteLogico([FromRoute] int id)
        {
            var result = await _unitOfWork.UsuarioRepository.DeleteLogico(id);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
            }

        }

        /// <summary>
        /// Elimina fisicamente usuario seleccionado por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna 200 si se elimino con exito o 500 si hubo algun error</returns>
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
                return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
            }
        }

    }
}