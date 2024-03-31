using AuthorService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthorService.Data
{
    public class AuthorDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Author> Authors { get; set; }
    }
}
