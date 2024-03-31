using AuthorService.Data;
using AuthorService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Steeltoe.Common.Discovery;

namespace AuthorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController(DiscoveryHttpClientHandler discoveryHttpClientHandler, AuthorDbContext context) : ControllerBase
    {
        private readonly AuthorDbContext _context = context;
        private readonly DiscoveryHttpClientHandler _discoveryHttpClientHandler = discoveryHttpClientHandler;

        [HttpGet("GetBooksToAuthor")]
        public async Task<IActionResult> GetBooksToAuthor([FromQuery] int authorId)
        {
            var author = await _context.Set<Author>().FirstOrDefaultAsync(a => a.Id == authorId);

            using HttpClient httpClient = new(_discoveryHttpClientHandler, false);
            var response = await httpClient.GetStringAsync($"https://BookService/api/book/GetBooksToId?authorId={authorId}");
            if (response is null)
                return BadRequest();
            var bookModel = JsonConvert.DeserializeObject<BookModel>(response);
            return Ok(bookModel);
        }
    }
}
