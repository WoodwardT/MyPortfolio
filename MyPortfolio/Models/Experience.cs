using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public string? Duration { get; set; }
        public string? description { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateAt { get; set; }
    }
}