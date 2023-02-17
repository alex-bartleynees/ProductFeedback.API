using ProductFeedback.API.Entities;

namespace ProductFeedback.API.Models
{
    public class CommentToReturnDto
    {   
        public int Id { get; set; }
        public int SuggestionId { get; set; }
        public string Content { get; set; } = string.Empty;

        public User User { get; set; }
    }
}
