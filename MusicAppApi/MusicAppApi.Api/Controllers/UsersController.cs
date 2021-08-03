using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicAppApi.Services;
using MusicAppApi.Entities;
using Microsoft.AspNetCore.Authorization;


namespace MusicAppApi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User user)
        {
            try
            {
                var u = await  _userRepository.GetByCredentials(user.Username, user.Password);

                if (u == null)
                    return NotFound(new { message = "Username or password is invalid" });
                
                var token = TokenService.GenerateToken(u);

                u.Password = "";

                return new 
                {
                    user = u,
                    token = token
                };

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                List<User> users = await _userRepository.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {   
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserById([FromQuery] int id)
        {
            try
            {
                var user = await _userRepository.GetById(id);

                if (user == null)
                    return NotFound(new { message = "User not found"});

                return Ok(user);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SaveUser([FromBody] User user) {
            try
            {
                if (user.Id != 0)
                    return StatusCode(400);
    
                await _userRepository.Add(user);

                return StatusCode(201, user); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }       
        }
    }
}
