using System.ComponentModel.DataAnnotations;

namespace GoodRepository.Models
{
    public class Book
    {
        public Guid Id { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Author { get; set; } = string.Empty;

        [Range(1000, 2100)]
        public int Year { get; set; }
    }
}
