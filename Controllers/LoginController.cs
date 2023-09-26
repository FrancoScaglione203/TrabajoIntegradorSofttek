﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofttek.Helpers;
using TrabajoIntegradorSofttek.Services;
using TrabajoIntegradorSofttek.DTOs;
using System.Security.Claims;
using TrabajoIntegradorSofttek.Infraestructure;

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

        /// <summary>
        /// Login con cuil y clave de Usuario
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Retorna 200 si se loguea o 401 si algun dato es incorrecto</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AuthenticateDto dto)
        {
            var usuarioCredentials = await _unitOfWork.UsuarioRepository.AuthenticateCredentials(dto);
            if (usuarioCredentials is null) return ResponseFactory.CreateErrorResponse(401, "Las credenciales son incorrectas");

            var token = _tokenJwtHelper.GenerateToken(usuarioCredentials);       

            var usuario = new UsuarioLoginDto()
            {
                Nombre = usuarioCredentials.Nombre,
                RoleId = usuarioCredentials.RoleId,
                Dni = usuarioCredentials.Dni,
                Cuil = usuarioCredentials.Cuil,
                Token = token
            };


            return ResponseFactory.CreateSuccessResponse(200, usuario);

        }
    }
}