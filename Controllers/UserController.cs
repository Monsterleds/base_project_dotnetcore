using curso.api.Filters;
using curso.api.Models;
using curso.api.Models.User;
using curso.api.Configurations;
using curso.api.Business.Entities;
using curso.api.Business.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace curso.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtAuthenticationService _authenticationService;
        public UserController(IUserRepository userRepository, IJwtAuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
        }

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidFieldViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(GenericErrorViewModel))]
        [HttpPost]
        [Route("session")]
        [ValidationModelStateCustomized]
        public IActionResult Loggin(LoginViewModelInput loginViewModelInput)
        {
            User user = _userRepository.FindOne(loginViewModelInput.Email);
             
            if (user == null || user.Password != loginViewModelInput.Password) {
                return BadRequest(new { errors = "Email or password is incorrect." });
            }

            var token = _authenticationService.GenerateToken(user);

            return Ok(new {
                Token = token,
                User = user,
            });
        }

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao cadastrar", Type = typeof(RegisterViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidFieldViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(GenericErrorViewModel))]
        [HttpPost]
        public IActionResult Register(RegisterViewModelInput registerViewModelInput)
        {

            // var pendentsMigration = context.Database.GetPendingMigrations();

            // if (pendentsMigration.Count() > 0) {
            //     context.Database.Migrate();
            // }

            var user = new User();
            user.Email = registerViewModelInput.Email;
            user.Name = registerViewModelInput.Name;
            user.Password = registerViewModelInput.Password;

            _userRepository.Add(user);
            _userRepository.Commit();

            return Created("", registerViewModelInput);
        }
    }
}
