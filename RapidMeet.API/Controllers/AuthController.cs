using Microsoft.AspNetCore.Mvc;
using RapidMeet.Application.DTOs.Auth;
using RapidMeet.Application.Interfaces;
using RapidMeet.Domain.Entities;

namespace RapidMeet.API.Controllers
{
   
        [ApiController]
        [Route("api/[controller]")]
        public class AuthController : ControllerBase
        {
            private readonly IUserService _userService;

            public AuthController(IUserService userService)
            {
                _userService = userService;
            }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO request)
        {
            var user = new User
            {
                Email = request.Email,
                Name = request.UserName,
            };

            var result = await _userService.RegisterAsync(user, request.Password);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequestDTO request)
        {
            var result = await _userService.LoginAsync(request);
            return Ok(result);
        }

    }


}
