using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductFeedback.API.DbContexts;
using ProductFeedback.API.Entities;
using System.Data;

namespace ProductFeedback.API.Services
{
    public class DapperRepository : ISuggestionsRepository
    {

        private IDbConnection db;
        protected readonly IConfiguration Configuration;
        private readonly SuggestionContext _context;

        public DapperRepository(IConfiguration config, SuggestionContext context)
        {
            Configuration = config;
            this.db = new SqlConnection(Configuration.GetConnectionString("SuggestionDBConnectionString"));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<int>> CreateSuggestion(Suggestion suggestion)
        {
            var title = suggestion.Title;
            var category = suggestion.Category;
            var description = suggestion.Description;
            var upvotes = 0;
            var status = "suggestion";

            var query = @"INSERT INTO [SUGGESTIONS](Title, Category, Description, Upvotes, Status) VALUES(@title, @category, @description, @upvotes, @status)
                        SELECT CAST(SCOPE_IDENTITY() as int)";

            return await db.QueryAsync<int>(query, new {title, category, description, upvotes, status});
        }

        public async void DeleteSuggestion(int suggestionId)
        {
            var first = @"DELETE SuggestionsCommentReply FROM SuggestionsCommentReply
                        INNER JOIN SuggestionsComment 
                        ON SuggestionsComment.Id = SuggestionsCommentReply.SuggestionCommentId
                        WHERE SuggestionsCommentReply.SuggestionCommentId = SuggestionsComment.Id 
                        AND SuggestionsComment.SuggestionId = @suggestionId";
            var command = @"DELETE FROM [Suggestions]
                           WHERE [Id] =  @suggestionID";

            await db.ExecuteAsync(first, new { suggestionId }); 
            await db.ExecuteAsync(command, new {suggestionId});
        }

        public async Task<Suggestion> GetSuggestionById(int suggestionId)
        {
            var query = @"SELECT [Id]
                        ,[Title]
                        ,[Upvotes]
                        ,[Category]
                        ,[Status]
                        ,[Description]
                        from Suggestions
                        WHERE [Id] = @suggestionId";

            return await db.QueryFirstOrDefaultAsync<Suggestion>(query, new {suggestionId});
        }

        public async Task<IEnumerable<Suggestion>> GetSuggestions()
        {
            var query1 = @"SELECT [Id]
                        ,[Title]
                        ,[Upvotes]
                        ,[Category]
                        ,[Status]
                        ,[Description]
                        from Suggestions";

            return await db.QueryAsync<Suggestion>(query1);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public Task<IEnumerable<int>> AddCommentToSuggestion(SuggestionComment comment)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<int>> AddReplyToComment(SuggestionCommentReply reply)
        {
            throw new NotImplementedException();
        }
    }
}
