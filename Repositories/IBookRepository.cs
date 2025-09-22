using GoodRepository.Controllers;
using GoodRepository.Models;

namespace GoodRepository.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book? GetById(Guid id);
        void Add(Book book);
        void Update(Book book);
        void Delete(Guid id);
    }
}
