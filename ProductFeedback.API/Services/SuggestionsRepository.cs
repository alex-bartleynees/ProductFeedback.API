using Microsoft.EntityFrameworkCore;
using ProductFeedback.API.DbContexts;
using ProductFeedback.API.Entities;
using ProductFeedback.API.Models;
using System.Collections.Generic;

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

        public async Task<Suggestion> GetSuggestionById(int suggestionId)
        {
            return await _context.Suggestions
                .Where(s => s.Id == suggestionId)
                .Include(c => c.Comments)
                .ThenInclude(c => c.User)
                .Include(x => x.Comments)
                .ThenInclude(r => r.Replies)
                .ThenInclude(r => r.User)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<int>> CreateSuggestion(Suggestion suggestion)
        {
            await _context.AddAsync(suggestion);
            await _context.SaveChangesAsync();

            return new List<int>() { suggestion.Id };
        }

        public async Task<IEnumerable<int>> AddCommentToSuggestion(SuggestionComment comment)
        {
            await _context.AddAsync(comment);
            await _context.SaveChangesAsync();

            return new List<int>() {comment.Id};
        }

        public async Task<IEnumerable<int>> AddReplyToComment(SuggestionCommentReply reply)
        {
            await _context.AddAsync(reply);
            await _context.SaveChangesAsync();

            return new List<int>() { reply.Id };
        }

        public async void DeleteSuggestion(int suggestionId)
        {
            var entityToDelete = _context.Suggestions.FirstOrDefault(s => s.Id == suggestionId);
            if (entityToDelete != null)
            {
                _context.Suggestions.Remove(entityToDelete);
            }
           
            await SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
