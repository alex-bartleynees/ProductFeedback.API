using Microsoft.EntityFrameworkCore;
using ProductFeedback.API.DbContexts;
using ProductFeedback.API.Entities;

namespace ProductFeedback.API.Services
{
    public class SuggestionsRepository : ISuggestionsRepository
    {
        private readonly SuggestionContext _context;

        public SuggestionsRepository(SuggestionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Suggestion>> GetSuggestions()
        {
            return await _context.Suggestions
                .Include(c => c.Comments)
                .ThenInclude(c => c.User)
                .Include(x => x.Comments)
                .ThenInclude(r => r.Replies)
                .ThenInclude(r => r.User)
                .ToListAsync();

        }
    }
}
