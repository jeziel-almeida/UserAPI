using Microsoft.EntityFrameworkCore;
using Usuario.Model;

namespace Usuario.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        //Criar tabela no bd
        public DbSet<User> Users { get; set; }
    }

}