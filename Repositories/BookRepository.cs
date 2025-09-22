using GoodRepository.Controllers;
using GoodRepository.Models;

namespace GoodRepository.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books = new()
        {
            new Book { Id = Guid.NewGuid(), Title = "Clean Code", Author = "Robert C. Martina", Year = 2008 },
            new Book { Id = Guid.NewGuid(), Title = "Pragmatic Programmer", Author = "Andrew Hunt", Year = 1999 }
        };

        public IEnumerable<Book> GetAll() => _books;

        public Book? GetById(Guid id) => _books.FirstOrDefault(b => b.Id == id);

        public void Add(Book book) => _books.Add(book);

        public void Update(Book book)
        {
            var index = _books.FindIndex(b => b.Id == book.Id);
            if (index != -1) _books[index] = book;
        }

        public void Delete(Guid id) => _books.RemoveAll(b => b.Id == id);
    }
}
