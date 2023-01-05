using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductFeedback.API.Entities
{
    public class SuggestionCommentReply
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        public string ReplyingTo { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        public int UserId { get; set; }

        [ForeignKey("SuggestionCommentId")]
        public SuggestionComment? Comment { get; set; }
        public int? SuggestionCommentId { get; set; }

        public SuggestionCommentReply(string content, string replyingTo) { 
            Content = content;
            ReplyingTo = replyingTo;
        }
    }
}
