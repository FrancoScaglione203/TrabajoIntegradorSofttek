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

        /// <summary>
        /// Devuelve todos los trabajos
        /// </summary>
        /// <returns>Retorna una lista de la clase Trabajo</returns>
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

        /// <summary>
        /// Devuelve el trabajo con el id ingresado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna 200 si se obtuvo trabajo por id o 500 si no existe trabajo con ese id</returns>
        [HttpGet("TrabajoById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var trabajo = await _unitOfWork.TrabajoRepository.GetById(id);
            if (trabajo == null)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se encontro ningun trabajo con ese id ");
            }
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, trabajo);
        }

        /// <summary>
        /// Agrega un trabajo a la base de datos
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Retorna 201 y agrega a base de datos</returns>
        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(AgregarTrabajoDto dto)
        {
            var trabajo = new Trabajo(dto);
            await _unitOfWork.TrabajoRepository.Insert(trabajo);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Trabajo registrado con exito!");
        }

        /// <summary>
        /// Actualiza el trabajo seleccionado por id por el trabajoDto que se envia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns>Retorna 200 si se actualizo con exito o 500 hubo un error</returns>
        [Authorize(Policy = "Admin")]
        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, AgregarTrabajoDto dto)
        {
            var result = await _unitOfWork.TrabajoRepository.Update(new Trabajo(dto, id));
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo editar el trabajo");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }

        }

        /// <summary>
        /// Cambia a false el estado de la propiedad Activo del trabajo seleccionado por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna 200 si se modifico con exito o 500 si hubo un error</returns>
        [Authorize(Policy = "Admin")]
        [HttpPut("DeleteLogico/{id}")]
        public async Task<IActionResult> DeleteLogico([FromRoute] int id)
        {
            var result = await _unitOfWork.TrabajoRepository.DeleteLogico(id);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el trabajo");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
            }

        }

        /// <summary>
        /// Elimina fisicamente servicio seleccionado por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna 200 si se elimino con exito o 500 si hubo algun error</returns>
        [Authorize(Policy = "Admin")]
        [HttpDelete("DeleteFisico/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.TrabajoRepository.Delete(id);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el trabajo");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
            };
        }
    }
}
