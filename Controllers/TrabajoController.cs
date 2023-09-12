using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DTOs;

namespace TrabajoIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajoController : ControllerBase
    {
        [HttpGet]
        [Route("Trabajos")]
        public IActionResult Trabajos()
        {
            return Ok("Todos los trabajos");
        }


        [HttpPost]
        [Route("Agregar")]
        public IActionResult AgregarTrabajo(TrabajoDto trabajo)
        {
            return Unauthorized("No se pudo agregar trabajo");
        }


        [HttpPut]
        [Route("Editar")]
        public IActionResult EditarTrabajo(TrabajoDto trabajo)
        {
            return Ok(trabajo);
        }


        [HttpDelete]
        [Route("Eliminar")]
        public IActionResult EliminarTrabajo(int id)
        {
            return Ok($"Se elimino el elemento {id} correctamente");
        }
    }
}
