using System.ComponentModel.DataAnnotations.Schema;

namespace ProductFeedback.API.Models
{
    public class ReplyForCreationDto
    {

        public int SuggestionId { get; set; }
        public int SuggestionCommentId { get; set; }
        public string Content { get; set; } = string.Empty;

        public string ReplyingTo { get; set; } = string.Empty;

        public int UserId { get; set; }
    }
}
