using ProductFeedback.API.Entities;

namespace ProductFeedback.API.Services
{
    public interface ISuggestionsRepository
    {
        Task<IEnumerable<Suggestion>> GetSuggestions();

        Task CreateSuggestion(Suggestion suggestion);
    }
}
