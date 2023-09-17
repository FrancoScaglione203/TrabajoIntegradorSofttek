using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DTOs;
using TrabajoIntegradorSofttek.Services;

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


        [HttpGet]
        [Route("Proyectos")]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetAll()
        {
            var proyectos = await _unitOfWork.ProyectoRepository.GetAll();

            return proyectos;
        }


        [HttpPost]
        [Route("Agregar")]
        public IActionResult Agregar(ProyectoDto proyecto)
        {
            return Unauthorized("No se pudo agregar proyecto");
        }


        [HttpPut]
        [Route("Editar")]
        public IActionResult EditarProyecto(ProyectoDto proyecto)
        {
            return Ok(proyecto);
        }


        [HttpDelete]
        [Route("Eliminar")]
        public IActionResult EliminarProyecto(int id)
        {
            return Ok($"Se elimino el elemento {id} correctamente");  //Para mandar un parametro tengo que poner el signo pesos al inicio y
        }                                                             //el parametro entre corchetes

    }
}