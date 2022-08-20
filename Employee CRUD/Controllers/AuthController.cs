using Employee_CRUD.Interfaces;
using Employee_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogin _login;

        public AuthController(ILogin login)
        {
            _login = login;
        }
        [HttpPost("Login")]
        public async Task<LoginModel.AuthenticatedResponse> UserAccessLogin(LoginModel login)
        {
            return await _login.UserAccessLogin(login);
        }
    }
}
