using Microsoft.EntityFrameworkCore;
using BasicBoard.Models;

namespace BasicBoard.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Note> Notes { get; set; }
    }
}
