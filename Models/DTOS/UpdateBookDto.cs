using System.ComponentModel.DataAnnotations;

namespace GoodRepository.Models.DTOS
{
    public record CreateBookDto(
        [property: Required, StringLength(200)] string Title,
        [property: Required, StringLength(100)] string Author,
        [property: Range(1000, 2100)] int Year
    );
}
