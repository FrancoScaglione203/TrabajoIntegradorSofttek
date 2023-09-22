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


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAll()
        {
            var Roles = await _unitOfWork.RoleRepository.GetAll();

            return Roles;
        }



        [HttpPost]
        [Route("Role")]
        public async Task<IActionResult> Insert(RoleDto dto)
        {

            var Role = new Role(dto);
            await _unitOfWork.RoleRepository.Insert(Role);
            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, Role role)
        {
            var result = await _unitOfWork.RoleRepository.Update(role);

            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpDelete("DeleteFisico/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.RoleRepository.Delete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }

    }
}