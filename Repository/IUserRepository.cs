using Usuario.Model;

namespace Usuario.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> BuscaUsers();
        Task<User> BuscaUser(int id);
        void AdicionaUser(User user);
        void AtualizaUser(User user);
        void DeletaUser(User user);

        Task<bool> SaveChangesAsync();
    }
}