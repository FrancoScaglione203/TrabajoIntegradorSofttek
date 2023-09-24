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
        public async Task<ActionResult<IEnumerable<Role>>> GetAll()
        {
            var Roles = await _unitOfWork.RoleRepository.GetAll();

            return Roles;
        }


        /// <summary>
        /// Agrega un Role a la base de datos
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Retorna True y Cod 200 cuando se inserto</returns>
        [HttpPost]
        [Route("Role")]
        public async Task<IActionResult> Insert(RoleDto dto)
        {

            var Role = new Role(dto);
            await _unitOfWork.RoleRepository.Insert(Role);
            await _unitOfWork.Complete();
            return Ok(true);
        }

        /// <summary>
        /// Edita el role que se indica por el parametro id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="role"></param>
        /// <returns>Retorna true y 200 cuando finaliza</returns>
        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, Role role)
        {
            var result = await _unitOfWork.RoleRepository.Update(role);

            await _unitOfWork.Complete();
            return Ok(true);
        }

        /// <summary>
        /// Elimina un Role de forma fisica por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna true finalizada la eliminacion</returns>
        [HttpDelete("DeleteFisico/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.RoleRepository.Delete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }

    }
}