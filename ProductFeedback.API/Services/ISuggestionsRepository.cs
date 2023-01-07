using ProductFeedback.API.Entities;
using ProductFeedback.API.Models;

namespace ProductFeedback.API.Services
{
    public interface ISuggestionsRepository
    {
        Task<IEnumerable<Suggestion>> GetSuggestions();

        Task<Suggestion> GetSuggestionById(int suggestionId);

        Task CreateSuggestion(Suggestion suggestion);

        void DeleteSuggestion(int suggestionId);

        Task<bool> SaveChangesAsync();
    }
}
