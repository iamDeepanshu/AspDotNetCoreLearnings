using JWTImplementation.Interfaces;
using JWTImplementation.Models;
using JWTImplementation.RequestModels;
using Microsoft.AspNetCore.Mvc;



namespace JWTImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        // POST api/<AuthController>
        [HttpPost]
        public string Login([FromBody] LoginRequest loginModel)
        {
            var result = _authService.Login(loginModel);
            return result;
        }

        // PUT api/<AuthController>/5
        [HttpPost("addUser")]
        public User AddUser([FromBody] User value)
        {
            var user = _authService.AddUser(value);
            return user;
        }


    }
}
