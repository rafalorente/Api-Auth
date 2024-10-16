using ApiAuth.Models;
using ApiAuth.Repositories;
using ApiAuth.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] UserModel userModel)
        {

            var user =  UserRepository.GetUser(userModel.Username, userModel.Password);


            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos"});
            }

            var token = TokenService.GenerateToken(user);

            //Retorna dados
            return new { user = user, token = token};


            //Testes foram feitos usando o Postman.
            // https://localhost:5001/v1/login
        }
    }
}
