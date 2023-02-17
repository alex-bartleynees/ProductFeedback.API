using ProductFeedback.API.Entities;

namespace ProductFeedback.API.Models
{
    public class ReplyToReturnDto
    {
        public int Id { get; set; }

        public int SuggestionId { get; set; }
        public int SuggestionCommentId { get; set; }
        public string Content { get; set; } = string.Empty;
        public string ReplyingTo { get; set; } = string.Empty;

        public User User { get; set; }
    }
}
