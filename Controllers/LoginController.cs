﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofttek.Helpers;
using TrabajoIntegradorSofttek.Services;
using TrabajoIntegradorSofttek.DTOs;
using System.Security.Claims;

namespace TrabajoIntegradorSofttek.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private TokenJwtHelper _tokenJwtHelper;
        private readonly IUnitOfWork _unitOfWork;
        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AuthenticateDto dto)
        {
            var usuarioCredentials = await _unitOfWork.UsuarioRepository.AuthenticateCredentials(dto);
            if (usuarioCredentials is null) return Unauthorized("Las credenciales son incorrectas");

            var token = _tokenJwtHelper.GenerateToken(usuarioCredentials);       

            var usuario = new UsuarioLoginDto()
            {
                Nombre = usuarioCredentials.Nombre,
                RoleId = usuarioCredentials.RoleId,
                Dni = usuarioCredentials.Dni,
                Token = token
            };


            return Ok(usuario);

        }
    }
}