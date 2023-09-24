using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DTOs;
using TrabajoIntegradorSofttek.Services;
using Microsoft.AspNetCore.Authorization;
using TrabajoIntegradorSofttek.Infraestructure;

namespace TrabajoIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Devuelve todos los roles
        /// </summary>
        /// <returns>Retorna lista de roles</returns>
        [HttpGet]
        [Route("Roles")]
        public async Task<IActionResult> GetAll()
        {
            var Roles = await _unitOfWork.RoleRepository.GetAll();

            return ResponseFactory.CreateSuccessResponse(200, Roles);
        }


        /// <summary>
        /// Agrega un Role a la base de datos
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Retorna 409 si ya existe rol con descripcion ingresada y Cod 201 cuando se inserto correctamente</returns>
        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Insert(RoleDto dto)
        {
            if (await _unitOfWork.RoleRepository.RoleEx(dto.Name)) return ResponseFactory.CreateErrorResponse(409, $"Ya existe un role registrado con el nombre:{dto.Name}");
            var Role = new Role(dto);
            await _unitOfWork.RoleRepository.Insert(Role);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Role registrado con exito!");
        }

        /// <summary>
        /// Edita el role que se indica por el parametro id con los parametros que se mandan por RoleDto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="role"></param>
        /// <returns>Retorna 200 si se actualizo con exito o 500 si hubo un error</returns>
        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, Role role)
        {
            var result = await _unitOfWork.RoleRepository.Update(role);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo editar el role");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }
        }

        /// <summary>
        /// Elimina un Role de forma fisica por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna 200 si se elimino con exito o 500 si hubo algun error</returns>
        [HttpDelete("DeleteFisico/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.RoleRepository.Delete(id);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el role");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
            }
        }

    }
}