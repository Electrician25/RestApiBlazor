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
                    Email = "vanya2649@mail.ru",
                    Password = "34gve54rhg4"
                },
                new User()
                {
                    Email = "KIRilL4a9@mail.ru",
                    Password = "i94bju40b"
                }
            });
        }
    }
}