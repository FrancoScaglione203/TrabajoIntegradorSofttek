using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DTOs;
using TrabajoIntegradorSofttek.Services;
using Microsoft.AspNetCore.Authorization;
using TrabajoIntegradorSofttek.Helpers;
using TrabajoIntegradorSofttek.Infraestructure;

namespace TrabajoIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public ServicioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Devuelve todos los Servicios
        /// </summary>
        /// <returns>Retorna una lista de la clase Servicio</returns>
        [HttpGet]
        [Route("Servicios")]
        public async Task<IActionResult> GetAll()
        {
            var servicios = await _unitOfWork.ServicioRepository.GetAll();
            int pageToShow = 1;

            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateServicios = PaginateHelper.Paginate(servicios, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateServicios);
        }

        /// <summary>
        /// Devuelve todos los servicios activos
        /// </summary>
        /// <returns>Retorna lista de servicios con Activo=true</returns>
        [HttpGet]
        [Route("ServiciosActivos")]
        public async Task<IActionResult> GetActivos()
        {
            var servicios = await _unitOfWork.ServicioRepository.GetActivos();
            int pageToShow = 1;

            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateServicios = PaginateHelper.Paginate(servicios, pageToShow, url);
            
            return ResponseFactory.CreateSuccessResponse(200, paginateServicios);
        }

        /// <summary>
        /// Devuelve el usuario con el id ingresado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna 200 si se obtuvo servicio por id o 500 si no existe servicio con ese id</returns>
        [HttpGet("ServicioById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var servicio = await _unitOfWork.ServicioRepository.GetById(id);
            if (servicio == null)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se encontro ningun servicio con ese id ");
            }
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, servicio);
        }

        /// <summary>
        /// Agrega un Servicio a la base de datos
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Retorna 201 si agrego con exito o 409 si hubo un error</returns>
        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(AgregarServicioDto dto)
        {
            if (await _unitOfWork.ServicioRepository.ServicioEx(dto.Descripcion)) return ResponseFactory.CreateErrorResponse(409, $"Ya existe un servicio registrado con la descripcion:{dto.Descripcion}");
            var servicio = new Servicio(dto);
            await _unitOfWork.ServicioRepository.Insert(servicio);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Servicio registrado con exito!");
        }

        /// <summary>
        /// Actualiza el servicio seleccionado por id por el servicioDto que se envia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns>Retorna 200 si se actualizo con exito o 500 si hubo un error</returns>
        [Authorize(Policy = "Admin")]
        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, AgregarServicioDto dto)
        {
            var result = await _unitOfWork.ServicioRepository.Update(new Servicio(dto, id));
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo editar el servicio");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }
        }

        /// <summary>
        /// Cambia a false el estado de la propiedad Activo del servicio seleccionado por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna 200 si se modifico con exito o 500 si hubo un error</returns>
        [Authorize(Policy = "Admin")]
        [HttpPut("DeleteLogico/{id}")]
        public async Task<IActionResult> DeleteLogico([FromRoute] int id)
        {
            var result = await _unitOfWork.ServicioRepository.DeleteLogico(id);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el servicio");
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
            var result = await _unitOfWork.ServicioRepository.Delete(id);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el servicio");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
            }
        }
    }
}