using System.ComponentModel.DataAnnotations;

namespace June2023_technical.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Title { get; set; }

        [Required]
        [StringLength(100)]
        public string? Author { get; set; }

        [Range(1000, 2100)]
        public int PublicationYear { get; set; }

        [Required]
        [StringLength(50)]
        public string? Genre { get; set; }

        [Range(0, 1000)]
        public decimal Price { get; set; }
    }
}
