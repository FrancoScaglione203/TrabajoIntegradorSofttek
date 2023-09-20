﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DTOs;
using TrabajoIntegradorSofttek.Services;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Policy = "Admin")]
        [HttpGet]
        [Route("Servicios")]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetAll()
        {
            var servicios = await _unitOfWork.ServicioRepository.GetAll();

            return servicios;
        }


        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(AgregarServicioDto dto)
        {
            var servicio = new Servicio(dto);
            await _unitOfWork.ServicioRepository.Insert(servicio);
            await _unitOfWork.Complete();
            return Ok(true);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, AgregarServicioDto dto)
        {
            var result = await _unitOfWork.ServicioRepository.Update(new Servicio(dto, id));
            await _unitOfWork.Complete();
            return Ok(true);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.ServicioRepository.Delete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }
    }
}