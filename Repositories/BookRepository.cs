using GoodRepository.Controllers;
using GoodRepository.Models;

namespace GoodRepository.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books = new()
        {
            new Book { Id = Guid.NewGuid(), Title = "Clean Code", Author = "Robert C. Martina", Year = 2008 },
            new Book { Id = Guid.NewGuid(), Title = "Pragmatic Programmer", Author = "Andrew Hunt", Year = 1999 },
            new Book { Id = Guid.NewGuid(), Title = "Refactoring", Author = "Martin Fowler", Year = 1999 },
new Book { Id = Guid.NewGuid(), Title = "Design Patterns", Author = "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides", Year = 1994 },
new Book { Id = Guid.NewGuid(), Title = "Domain-Driven Design", Author = "Eric Evans", Year = 2003 },
new Book { Id = Guid.NewGuid(), Title = "Code Complete", Author = "Steve McConnell", Year = 1993 },
new Book { Id = Guid.NewGuid(), Title = "The Mythical Man-Month", Author = "Frederick P. Brooks Jr.", Year = 1975 },
new Book { Id = Guid.NewGuid(), Title = "Head First Design Patterns", Author = "Eric Freeman & Elisabeth Robson", Year = 2004 },
new Book { Id = Guid.NewGuid(), Title = "Working Effectively with Legacy Code", Author = "Michael Feathers", Year = 2004 },
new Book { Id = Guid.NewGuid(), Title = "Continuous Delivery", Author = "Jez Humble & David Farley", Year = 2010 },
new Book { Id = Guid.NewGuid(), Title = "The Clean Coder", Author = "Robert C. Martin", Year = 2011 },
new Book { Id = Guid.NewGuid(), Title = "Software Engineering at Google", Author = "Titus Winters, Tom Manshreck, Hyrum Wright", Year = 2020 }

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
