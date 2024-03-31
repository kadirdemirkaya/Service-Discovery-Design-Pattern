using BookService.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookService.Data
{
    public class BookDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
    }
}
