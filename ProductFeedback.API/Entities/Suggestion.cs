using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductFeedback.API.Entities
{
    public class Suggestion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public int Upvotes { get; set; }

        [MaxLength(50)]
        public string Category { get; set; }


        [MaxLength(50)]
        public string Status { get; set; }


        [MaxLength(500)]
        public string Description { get; set; }

        public ICollection<SuggestionComment> Comments { get; set; } = new List<SuggestionComment>();

        public Suggestion() { }
        public Suggestion (string title, string category, string status, string description)
        {
            Title = title;
            Category = category;
            Status = status;
            Description = description;
        }
    }
}
