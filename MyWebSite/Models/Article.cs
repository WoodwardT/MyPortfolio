using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Auther { get; set; }

        public string? Body { get; set; }

        public string? Slug { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
