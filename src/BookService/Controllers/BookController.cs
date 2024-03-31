using BookService.Data;
using BookService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(BookDbContext context) : ControllerBase
    {
        private readonly BookDbContext _context = context;

        [HttpGet("GetBooksToId")]
        public async Task<IActionResult> GetBooksToId([FromQuery] int authorId)
        {
            var response = await _context.Set<Book>().FirstOrDefaultAsync(b => b.AuthorId == authorId);
            return Ok(response);
        }
    }
}
