using System.Threading.Tasks;
using DoggyDatingApp.API.Data;
using DoggyDatingApp.API.DTOs;
using DoggyDatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoggyDatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        public AuthController(IAuthRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register (UserForRegisterDTO user) {
            user.Username = user.Username.ToLower();

            if (await _repository.UserExists(user.Username)) {
                return BadRequest("Username already exists.");
            }

             var userToCreate = new User {
                  Username = user.Username
             };

             await _repository.Register(userToCreate, user.Password);

             return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForRegisterDTO user) { 

            var authorizedUser = await _repository.Login(user.Username, user.Password);

            if (authorizedUser == null) {
                return Unauthorized();
            }

            return Ok(user);
        }
    }

}