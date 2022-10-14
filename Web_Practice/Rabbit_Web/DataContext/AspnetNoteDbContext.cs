using Microsoft.EntityFrameworkCore;
using Rabbit_Web.Models;

namespace Rabbit_Web.DataContext
{

    public class AspnetNoteDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=AspnetNoteDb;User ID=sa;Password=1234;");
        }
    }
}
