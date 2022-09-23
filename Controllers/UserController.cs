using Microsoft.AspNetCore.Mvc;
using Usuario.Model;
using Usuario.Repository;

namespace Usuario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            _repository.AdicionaUser(user);
            return await _repository.SaveChangesAsync()
                    ? Ok("Usuário adicionado com sucesso")
                    : BadRequest("Erro ao salvar usuário");
        }
    }
}