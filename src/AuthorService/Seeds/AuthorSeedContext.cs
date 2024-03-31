using AuthorService.Data;
using AuthorService.Entities;

namespace AuthorService.Seeds
{
    public static class AuthorSeedContext
    {
        public static async Task SeedAsync(AuthorDbContext context)
        {
            if (!context.Set<Author>().Any())
            {
                var authors = new List<Author>()
                {
                    new(){Id = 1, Name = "Thomas man",CreatedDate = DateTime.UtcNow},
                    new(){Id = 2, Name = "Mark Twain",CreatedDate = DateTime.UtcNow},
                    new(){Id = 3, Name = "Ahmet Hasim.",CreatedDate = DateTime.UtcNow},
                };

                await context.Set<Author>().AddRangeAsync(authors);
                await context.SaveChangesAsync();
            }
        }
    }
}
