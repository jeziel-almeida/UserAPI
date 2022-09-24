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
        public async Task<IActionResult> Get()
        {
            var users = await _repository.BuscaUsers();
            return users.Any() ? Ok(users) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _repository.BuscaUser(id);
            return user != null ? Ok(user) : NotFound("Usuário não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            _repository.AdicionaUser(user);
            return await _repository.SaveChangesAsync()
                    ? Ok("Usuário adicionado com sucesso")
                    : BadRequest("Erro ao salvar usuário");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User user)
        {
            var userBanco = await _repository.BuscaUser(id);
            if (userBanco == null) return NotFound("Usuário não encontrado");

            userBanco.Nome = user.Nome ?? userBanco.Nome;
            userBanco.DataNascimento = user.DataNascimento != new DateTime()
            ? user.DataNascimento : userBanco.DataNascimento;

            _repository.AtualizaUser(userBanco);

            return await _repository.SaveChangesAsync()
                    ? Ok("Usuário atualizado com sucesso")
                    : BadRequest("Erro ao atualizar usuário");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userBanco = await _repository.BuscaUser(id);
            if (userBanco == null) return NotFound("Usuário não encontrado");

            _repository.DeletaUser(userBanco);

            return await _repository.SaveChangesAsync()
                    ? Ok("Usuário deletado com sucesso")
                    : BadRequest("Erro ao deletar usuário");
        }
    }
}