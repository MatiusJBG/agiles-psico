using Core.Entities;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Servidor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // Método auxiliar para pruebas
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(new { message = "El controlador está funcionando correctamente" });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username))
            {
                return BadRequest(new { message = "El nombre de usuario es requerido" });
            }

            var response = _authService.Login(request);
            return Ok(response);
        }
    }
}
