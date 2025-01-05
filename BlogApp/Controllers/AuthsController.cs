﻿using BlogApp.BL.Dtos.UserDtos;
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
        public async Task<IActionResult> Login()
        {
            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(CreateUserDto dto)
        {
            await _service.RegisterAsync(dto);
            return Created();
        }
    }
}
