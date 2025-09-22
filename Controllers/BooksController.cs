using GoodRepository.Models.DTOS;
using GoodRepository.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoodRepository.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id:guid}")]
        public IActionResult GetOne(Guid id)
        {
            var book = _service.GetById(id);
            return book == null
                ? NotFound(new { error = "Book not found", status = 404 })
                : Ok(book);
        }

        [HttpGet("femaleAuthors")]
        public IActionResult GetBooksWithFemaleAuthor()
        {
            return Ok(_service.GetAllBooksWithFemaleAuthor());
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateBookDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var book = _service.Create(dto);
            return CreatedAtAction(nameof(GetOne), new { id = book.Id }, book);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update(Guid id, [FromBody] UpdateBookDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var updated = _service.Update(id, dto);
            return updated == null
                ? NotFound(new { error = "Book not found", status = 404 })
                : Ok(updated);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var success = _service.Delete(id);
            return success
                ? NoContent()
                : NotFound(new { error = "Book not found", status = 404 });
        }
    }
}
