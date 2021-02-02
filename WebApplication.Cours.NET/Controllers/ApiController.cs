using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Cours.NET.Data;

namespace WebApplication.Cours.NET.Controllers
{
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class ApiController : ControllerBase {
        private readonly LibraryDbContext libraryDbContext;

        public ApiController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        [HttpGet("/api/[controller]/GetInfos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("/api/[controller]/infos/{nb}")]
        public ActionResult<List<Book>> GetInfos(int nb=0)
        {
            if (nb < 1)
                return NotFound();
            return new List<Book>() { new Book() { Name = "Test", Content="Lorem ipsum", Price=9.99f } };
        }
        [Route("/api/[controller]/call")]
        public ActionResult<int> Call()
        {
            return Ok(libraryDbContext.Books.Count());
        }
        public async Task<ActionResult<Book>> AsyncCall()
        {
            return await libraryDbContext.Books.Where(x => x.Price > 0).FirstAsync();
        }
    }
}
