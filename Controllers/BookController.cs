using Microsoft.AspNetCore.Mvc;
using BibliothequeC_.Data;
using BibliothequeC_.Models;

namespace BibliothequeC_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly BookDb _dbContext;

        public BookController(BookDb dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = _dbContext.Books.ToList();
            return books;
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _dbContext.Books.Find(id);

            if (book == null)
                return NotFound();

            return book;
        }

        [HttpPost]
        public ActionResult<Book> PostBook(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book inputBook)
        {
            if (id != inputBook.Id)
            {
                return BadRequest();
            }

            var book = _dbContext.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            book.Name = inputBook.Name;
            book.Author = inputBook.Author;
            book.NbPages = inputBook.NbPages;

            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _dbContext.Books.Find(id);

            if (book == null)
                return NotFound();

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}