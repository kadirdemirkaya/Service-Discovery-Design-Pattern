using BookService.Data;
using BookService.Entities;

namespace BookService.Seeds
{
    public static class BookSeedContext
    {
        public static async Task SeedAsync(BookDbContext context)
        {
            if (!context.Set<Book>().Any())
            {
                var Books = new List<Book>()
                {
                   new(){Id = 1,AuthorId = 1,Title = "TITLE1"},
                   new(){Id = 2,AuthorId = 2,Title = "TITLE2"},
                   new(){Id = 3,AuthorId = 3,Title = "TITLE3"}
                };

                await context.Set<Book>().AddRangeAsync(Books);
                await context.SaveChangesAsync();
            }
        }
    }
}
