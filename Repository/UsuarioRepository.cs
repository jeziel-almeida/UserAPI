using Usuario.Data;
using Usuario.Model;

namespace Usuario.Repository
{
    public class UsuarioRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UsuarioRepository(UserContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<User>> BuscaUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> BuscaUser(int id)
        {
            throw new NotImplementedException();
        }

        public void AdicionaUser(User user)
        {
            _context.Add(user);
        }

        public void AtualizaUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeletaUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}