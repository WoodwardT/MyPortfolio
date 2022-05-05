using System.ComponentModel.DataAnnotations;
namespace MyPortfolio.Models
{
    public class About
    {
        public int Id { get; set; }

        [Required]
        public string? Pic { get; set; }
        public string? Slug { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateAt { get; set; }
    }
}
