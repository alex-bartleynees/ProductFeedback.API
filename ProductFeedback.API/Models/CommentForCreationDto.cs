using ProductFeedback.API.Entities;

namespace ProductFeedback.API.Models
{
    public class CommentForCreationDto
    {
        public int SuggestionId { get; set; }
        public string Content { get; set; } = string.Empty;

        public int UserId { get; set; }
    }
}
