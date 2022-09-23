using Microsoft.AspNetCore.Mvc;
using Usuario.Model;

namespace Usuario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<User> Users()
        {
            return new List<User>
            {
                new User { id = 1, Nome = "João", DataNascimento = new DateTime(1990, 1, 1) },
                new User { id = 2, Nome = "Maria", DataNascimento = new DateTime(1991, 1, 1) },
            };
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Users());
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            var users = Users();
            users.Add(user);
            return Ok(users);
        }
    }
}