using Usuario.Data;
using Usuario.Model;
using Microsoft.EntityFrameworkCore;

namespace Usuario.Repository
{
    public class UsuarioRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UsuarioRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> BuscaUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> BuscaUser(int id)
        {
            return await _context.Users.Where(x => x.id == id).FirstOrDefaultAsync();
        }

        public void AdicionaUser(User user)
        {
            _context.Add(user);
        }

        public void AtualizaUser(User user)
        {
            _context.Update(user);
        }

        public void DeletaUser(User user)
        {
            _context.Remove(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}