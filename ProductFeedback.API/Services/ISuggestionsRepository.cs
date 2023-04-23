using ProductFeedback.API.Entities;
using ProductFeedback.API.Models;

namespace ProductFeedback.API.Services
{
    public interface ISuggestionsRepository
    {
        Task<IEnumerable<Suggestion>> GetSuggestions();

        Task<Suggestion> GetSuggestionById(int suggestionId);

        Task<IEnumerable<int>> CreateSuggestion(Suggestion suggestion);

        Task<IEnumerable<int>> AddCommentToSuggestion(SuggestionComment comment);

        Task<IEnumerable<int>> AddReplyToComment(SuggestionCommentReply reply);

        Task<User> GetUser(int userId);

        void DeleteSuggestion(int suggestionId);

        Task<bool> SaveChangesAsync();
    }
}
