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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<User>();
            user.ToTable("tb_user");
            user.HasKey(x => x.id);
            user.Property(x => x.id).HasColumnName("id").ValueGeneratedOnAdd();
            user.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            user.Property(x => x.DataNascimento).HasColumnName("data_nascimento");
        }
    }

}