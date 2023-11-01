using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [MaxLength(50, ErrorMessage = "Długość tytułu nie może przekraczać 50 znaków")]

        public string Title { get; set; }

        public Genre Genre { get; set; }

        [UIHint("LongText")]
        [Required(ErrorMessage = "Opis jest wymagany")]
        public string Description { get; set; }

        [UIHint("Stars")]
        [Range(1, 5, ErrorMessage = "Ocena musi być z przedziału 1-5")]
        public int Rating { get; set; }
        public string? TrailerLink { get; set; }
    }
}
