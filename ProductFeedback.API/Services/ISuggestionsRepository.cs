using ProductFeedback.API.Entities;
using ProductFeedback.API.Models;

namespace ProductFeedback.API.Services
{
    public interface ISuggestionsRepository
    {
        Task<IEnumerable<Suggestion>> GetSuggestions();

        Task CreateSuggestion(Suggestion suggestion);

        Suggestion? UpdateSuggestion(int suggestionId, SuggestionForUpdateDto suggestion);

        void DeleteSuggestion(int suggestionId);
    }
}
