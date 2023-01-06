using System.ComponentModel.DataAnnotations;

namespace ProductFeedback.API.Models
{
    public class SuggestionForUpdateDto
    {
        [Required(ErrorMessage = "You must provide a title.")]
        [MaxLength(100)]
        public string Title { get; set; }

        public int Upvotes { get; set; }

        public string Category { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public SuggestionForUpdateDto(string title, int upvotes, string category, string status, string description)
        {
            Title = title;
            Upvotes = upvotes;
            Category = category;
            Status = status;
            Description = description;
        }
    }
}
