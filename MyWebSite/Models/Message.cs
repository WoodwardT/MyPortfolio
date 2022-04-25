using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyPortfolio.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string? Body { get; set; }

        [Required]
        public string? Email { get; set; }
        public string? FullName { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

    }
}
