﻿using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin=_authService.Login(userForLoginDto);
            if(!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
           var result= _authService.CreateAccessToken(userToLogin.Data);
            if(result.Success) 
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public IActionResult Register(UserforRegisterDto userforRegisterDto) 
        {
            var userExists = _authService.UserExists(userforRegisterDto.UserName);
            if(!userExists.Success) 
            {
                return BadRequest(userExists.Message);
            }
            var registerResult=_authService.Register(userforRegisterDto);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success) { return Ok(result.Data); }else { return BadRequest(result.Message); }
        }


    }
}
