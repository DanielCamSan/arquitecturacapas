
using GoodRepository.Models;

using GoodRepository.Models.DTOS;
using GoodRepository.Repositories;

namespace GoodRepository.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;

        public BookService(IBookRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Book> GetAll() => _repo.GetAll();

        public Book? GetById(Guid id) {
            var book = _repo.GetById(id);
            return book;
        }

        public IEnumerable<Book> GetAllBooksWithFemaleAuthor()
        {
            var allBooks = _repo.GetAll();
            return allBooks.Where(b => b.Author.EndsWith("a"));
        }
        public Book Create(CreateBookDto dto)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = dto.Title.Trim(),
                Author = dto.Author.Trim(),
                Year = dto.Year
            };
            _repo.Add(book);
            return book;
        }

        public Book? Update(Guid id, UpdateBookDto dto)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return null;

            existing.Title = dto.Title.Trim();
            existing.Author = dto.Author.Trim();
            existing.Year = dto.Year;
            _repo.Update(existing);

            return existing;
        }

        public bool Delete(Guid id)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return false;
            _repo.Delete(id);
            return true;
        }
    }
}
