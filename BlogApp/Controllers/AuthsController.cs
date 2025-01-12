using BlogApp.BL.Dtos.UserDtos;
using BlogApp.BL.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController(IAuthService _service) : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            return Ok(await _service.LoginAsync(dto));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(CreateUserDto dto)
        {
            await _service.RegisterAsync(dto);
            return Created();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SendEmail(string email)
        {
            await _service.Send(email);
            return Created();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Verifaction(string email,int code)
        {
            await _service.VerifyEmailAsync(email, code);
            return Created();
        }
    }
}
