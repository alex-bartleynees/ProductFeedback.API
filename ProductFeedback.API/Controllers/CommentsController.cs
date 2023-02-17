using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductFeedback.API.Entities;
using ProductFeedback.API.Models;
using ProductFeedback.API.Services;

namespace ProductFeedback.API.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        private readonly ISuggestionsRepository _suggestionsRepository;

        public CommentsController(ISuggestionsRepository suggestionsRepository)
        {
            _suggestionsRepository = suggestionsRepository ??
                throw new ArgumentNullException(nameof(suggestionsRepository));
        }

        [HttpPost]
        public async Task<ActionResult<Suggestion>> AddCommentToSuggestion(CommentForCreationDto comment)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commentEntity = new SuggestionComment(comment.Content)
            {
                UserId = comment.UserId,
                SuggestionId = comment.SuggestionId
            };

            var result = await _suggestionsRepository.AddCommentToSuggestion(commentEntity);
            var id = result.FirstOrDefault();
            commentEntity.Id = (int)id;

            var commentToReturn = new CommentToReturnDto()
            {
                Id = commentEntity.Id,
                SuggestionId = commentEntity.SuggestionId,
                Content = commentEntity.Content,
                User = new User("James Skinner", "hummingbird1", "./assets/user-images/image-james.jpg")
            };

            return Ok(commentToReturn);
        }

        [HttpPost("reply")]
        public async Task<ActionResult<Suggestion>> AddReplyToComment(ReplyForCreationDto reply)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var replyEntity = new SuggestionCommentReply(reply.Content, reply.ReplyingTo)
            {
                UserId = reply.UserId,
                SuggestionCommentId = reply.SuggestionCommentId
            };

            var result = await _suggestionsRepository.AddReplyToComment(replyEntity);
            var id = result.FirstOrDefault();
            replyEntity.Id = (int)id;

            var replyToReturn = new ReplyToReturnDto()
            {
                Id = replyEntity.Id,
                SuggestionId = reply.SuggestionId,
                SuggestionCommentId = (int)replyEntity.SuggestionCommentId,
                Content = replyEntity.Content,
                ReplyingTo = reply.ReplyingTo,
                User = new User("James Skinner", "hummingbird1", "./assets/user-images/image-james.jpg")
            };

            return Ok(replyToReturn);
        }
    }
}
