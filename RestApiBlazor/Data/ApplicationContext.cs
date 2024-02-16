using Microsoft.EntityFrameworkCore;
using RESTapi.Users;

namespace RESTapi.Data
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<User> Users => Set<User>();

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { Database.EnsureCreated(); }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User()
                {
                    Name = "Vanya",
                    Email = "vanya2649@mail.ru"
                },
                new User()
                {
                    Name = "Kirill",
                    Email = "KIRilL4a9@mail.ru"
                }
            });
        }
    }
}