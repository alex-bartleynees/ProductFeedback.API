using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductFeedback.API.Entities;
using ProductFeedback.API.Models;
using ProductFeedback.API.Services;

namespace ProductFeedback.API.Controllers
{
    [Route("api/suggestions")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private readonly ISuggestionsRepository _suggestionsRepository;

        public SuggestionsController(ISuggestionsRepository suggestionsRepository)
        {
            _suggestionsRepository = suggestionsRepository ??
                throw new ArgumentNullException(nameof(suggestionsRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suggestion>>> GetSuggestions()
        {
            var suggestionsEntity = await _suggestionsRepository.GetSuggestions();

            if (suggestionsEntity == null)
            {
                return NotFound();
            }

            return Ok(suggestionsEntity);
        }

        [HttpPost]
        public async Task<ActionResult<Suggestion>> CreateSuggestion(SuggestionForCreationDto suggestion)
        {
            var suggestionEntity = new Suggestion(suggestion.Title, suggestion.Category, "" , suggestion.Description) { };

            await _suggestionsRepository.CreateSuggestion(suggestionEntity);

            return Ok(suggestionEntity);
        }
    }
}
