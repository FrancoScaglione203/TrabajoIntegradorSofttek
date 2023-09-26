using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DTOs;
using TrabajoIntegradorSofttek.Services;
using TrabajoIntegradorSofttek.Helpers;
using TrabajoIntegradorSofttek.Infraestructure;
using Microsoft.AspNetCore.Authorization;

namespace TrabajoIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public ProyectoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Devuelve todos los proyectos
        /// </summary>
        /// <returns>Retorna una lista de la clase Proyecto</returns>
        [Authorize(Policy = "AdminConsultor")]
        [HttpGet]
        [Route("Proyectos")]
        public async Task<IActionResult> GetAll()
        {
            var proyectos = await _unitOfWork.ProyectoRepository.GetAll();
            int pageToShow = 1;

            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateProyectos = PaginateHelper.Paginate(proyectos, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateProyectos);
        }

        /// <summary>
        /// Devuelve lista de proyectos con Estado igual a IdEstado enviado por parametro
        /// </summary>
        /// <param name="idEstado"></param>
        /// <returns>Retorna lista de proyectos con Estado = idEstado</returns>
        [Authorize(Policy = "AdminConsultor")]
        [HttpGet]
        [Route("ProyectosByEstado/{idEstado}")]
        public async Task<IActionResult> GetEstado([FromRoute] int idEstado)
        {
            var proyectos = await _unitOfWork.ProyectoRepository.GetEstado(idEstado);
            int pageToShow = 1;

            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateProyectos = PaginateHelper.Paginate(proyectos, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateProyectos);
        }

        /// <summary>
        /// Devuelve el proyecto con el id ingresado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna 200 si se obtuvo servicio por id o 500 si no existe servicio con ese id</returns>
        [Authorize(Policy = "AdminConsultor")]
        [HttpGet("ProyectoById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var proyecto = await _unitOfWork.ServicioRepository.GetById(id);
            if (proyecto == null)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se encontro ningun proyectoo con ese id ");
            }
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, proyecto);
        }

        /// <summary>
        /// Agrega un proyecto a la base de datos
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Retorna 201 si agrego con exito o 409 si hubo un error</returns>
        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(ProyectoDto dto)
        {
            if (await _unitOfWork.ProyectoRepository.ProyectoEx(dto.Nombre)) return ResponseFactory.CreateErrorResponse(409, $"Ya existe un proyecto registrado con el nombre:{dto.Nombre}");
            var proyecto = new Proyecto(dto);
            await _unitOfWork.ProyectoRepository.Insert(proyecto);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Proyecto registrado con exito!");
        }

        /// <summary>
        /// Actualiza el servicio seleccionado por id por el proyectoDto que se envia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns>Retorna 200 si se actualizo con exito o 500 si hubo un error</returns>
        [Authorize(Policy = "Admin")]
        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, ProyectoDto dto)
        {
            var result = await _unitOfWork.ProyectoRepository.Update(new Proyecto(dto, id));
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo editar el proyecto");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            };
        }

        /// <summary>
        /// Cambia a true el estado de la propiedad Activo del trabajo seleccionado por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna 200 si se modifico con exito o 500 si hubo un error</returns>
        [Authorize(Policy = "Admin")]
        [HttpPut("AltaLogico/{id}")]
        public async Task<IActionResult> AltaLogico([FromRoute] int id)
        {
            var result = await _unitOfWork.ProyectoRepository.AltaLogico(id);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo activar el trabajo");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Activado");
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
            var result = await _unitOfWork.ProyectoRepository.DeleteLogico(id);
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
        /// Elimina fisicamente trabajo seleccionado por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna 200 si se elimino con exito o 500 si hubo algun error</returns>
        [Authorize(Policy = "Admin")]
        [HttpDelete("DeleteFisico/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.ProyectoRepository.Delete(id);

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
    }
}