using GoodRepository.Models;
using GoodRepository.Models.DTOS;

namespace GoodRepository.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetAllBooksWithFemaleAuthor();
        Book? GetById(Guid id);
        Book Create(CreateBookDto dto);
        Book? Update(Guid id, UpdateBookDto dto);
        bool Delete(Guid id);
    }
}